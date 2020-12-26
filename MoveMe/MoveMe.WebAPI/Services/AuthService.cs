using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MoveMe.Model;
using MoveMe.Model.Requests;
using MoveMe.WebAPI.Other;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MoveMe.WebAPI.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<Database.User> _userManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        private readonly ICRUDService<Address, object, AddressUpsertRequest, AddressUpsertRequest> _addressService;
        private readonly ApplicationSettings _appSettings;
        private readonly IMapper _mapper;
        public AuthService(UserManager<Database.User> userManager, RoleManager<IdentityRole<int>> roleManager,
            ICRUDService<Address, object, AddressUpsertRequest, AddressUpsertRequest> addressService,
            IOptions<ApplicationSettings> appSettings, IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _addressService = addressService;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }

        public async Task<User> ChangePassword(int id, PasswordChangeRequest request)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (request.NewPassword == request.ConfirmPassword)
            {
                if (request.IsAdmin == true)
                {
                    var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                    await _userManager.ResetPasswordAsync(user, token, request.NewPassword);
                    return _mapper.Map<User>(user);
                }
                else
                {
                    var result = await _userManager.ChangePasswordAsync(user, request.CurrentPassword, request.NewPassword);
                    if (result.Succeeded)
                    {
                        return _mapper.Map<User>(user);
                    }
                    else
                    {
                        throw new UserException("Current password is not correct");
                    }
                }
            }
            else
            {
                throw new UserException("New password and confirm password are not equal");
            }
        }

        public async Task CreateRole(string role)
        {
            IdentityRole<int> newRole = new IdentityRole<int> { Name = role };
            await _roleManager.CreateAsync(newRole);
        }

        public async Task<User> Deactivate(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            user.Active = !user.Active;
            await _userManager.UpdateAsync(user);
            return _mapper.Map<User>(user);
        }

        public async Task<List<User>> GetAll(UserSearchReqeust request)
        {
            List<Database.User> allUsers;
            if (request?.RoleId.HasValue == true && request?.RoleId != 0 && request?.RoleId != 1)
            {
                var roles = await GetRoles(false);

                var role = await _roleManager.Roles.FirstAsync(x => x.Id == request.RoleId);
                allUsers = await _userManager.GetUsersInRoleAsync(role.Name) as List<Database.User>;
            }
            else
            {
                allUsers = _userManager.Users.Where(x => x.Id != 1).ToList();
            }

            if (!string.IsNullOrWhiteSpace(request?.Name))
            {
                allUsers = allUsers.Where(x =>
                (!string.IsNullOrWhiteSpace(x.Company) && x.Company.ToLower().StartsWith(request.Name)) ||
                (!string.IsNullOrWhiteSpace(x.FirstName) && !string.IsNullOrWhiteSpace(x.LastName) && (x.FirstName + " " + x.LastName).ToLower().StartsWith(request.Name))
                ).ToList();
            }

            if (request?.ShowInactive == false)
            {
                allUsers = allUsers.Where(x => x.Active == true).ToList();
            }

            return _mapper.Map<List<User>>(allUsers);
        }

        public async Task<User> GetById(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            return _mapper.Map<User>(user);
        }

        public async Task<DashboardCounters> GetCounters()
        {
            var model = new DashboardCounters
            {
                NumberOfClients = (await _userManager.GetUsersInRoleAsync("Client") as List<Database.User>).Count,
                NumberOfSuppliers = (await _userManager.GetUsersInRoleAsync("Supplier") as List<Database.User>).Count
            };
            return model;
        }

        public async Task<RoleModel> GetRole(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            var roles = await _userManager.GetRolesAsync(user);

            return new RoleModel
            {
                Role = roles[0]
            };
        }

        public async Task<List<ComboBoxItem>> GetRoles(bool includeAdmin = true)
        {
            var roles = new List<ComboBoxItem>();

            var rolesDb = await _roleManager.Roles.ToListAsync();

            foreach (var role in rolesDb)
            {
                if (includeAdmin || role.Name != "Admin")
                {
                    roles.Add(new ComboBoxItem
                    {
                        Text = role.Name,
                        Value = role.Id
                    });
                }
            }

            return roles;
        }

        public async Task<Login> Login(LoginRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user != null && await _userManager.CheckPasswordAsync(user, request.Password))
            {
                if (user.Active == false)
                {
                    throw new UserException("This account is blocked by admin.");
                }

                var roles = await _userManager.GetRolesAsync(user);
                if (!roles.Any(x => request.Roles.Any(y => y == x)))
                {
                    throw new UserException("Not authorized");
                }

                var token = GenerateToken(user.Id, roles[0]);

                return new Login
                {
                    Token = token,
                    Role = roles.FirstOrDefault()
                };
            }
            else
            {
                throw new UserException("Invalid username or password");
            }
        }

        public async Task<User> Register(RegisterRequest request)
        {
            if (request.Password == request.ConfirmPassword)
            {
                var userCheck = await _userManager.FindByEmailAsync(request.Email);

                if (userCheck != null)
                {
                    throw new UserException("Email already exists");
                }

                var address = _addressService.Insert(new AddressUpsertRequest
                {
                    AdditionalAddress = request.AdditionalAddress,
                    City = request.City,
                    CountryId = request.CountryId,
                    Street = request.Street,
                    ZipCode = request.ZipCode
                });

                var user = new Database.User
                {
                    Email = request.Email,
                    UserName = request.Email,
                    EmailConfirmed = false,
                    Active = true,
                    AddressId = address.AddressId,
                    PhoneNumber = request.PhoneNumber,
                    CreatedAt = request.CreatedAt
                };

                var result = await _userManager.CreateAsync(user, request.Password);

                if (request.RoleId == 1)
                {
                    //Admin
                    await _userManager.AddToRoleAsync(user, "Admin");
                }
                else if (request.RoleId == 2)
                {
                    //Client
                    await _userManager.AddToRoleAsync(user, "Client");
                    user.FirstName = request.FirstName;
                    user.LastName = request.LastName;
                }
                else if (request.RoleId == 3)
                {
                    //Supplier
                    await _userManager.AddToRoleAsync(user, "Supplier");
                    user.Company = request.Company;
                    user.Image = request.Image;
                }

                await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    return _mapper.Map<User>(user);
                }
                else
                {
                    throw new UserException(result.Errors.ToString());
                }
            }
            else
            {
                throw new UserException("Passwords do not match");
            }
        }

        public async Task<User> Update(int id, UserUpdateRequest request)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());

            if (user == null)
            {
                throw new UserException("User is not found");
            }

            var userCheck = await _userManager.FindByEmailAsync(request.Email);

            if (userCheck != null && userCheck != user)
            {
                throw new UserException("Email already exists");
            }

            user.Company = request.Company;
            user.PhoneNumber = request.PhoneNumber;
            user.Email = request.Email;
            user.UserName = request.Email;
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;

            if (request.Image != null)
            {
                user.Image = request.Image;
            }

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return _mapper.Map<User>(user);
            }
            else
            {
                throw new UserException("Bad request");
            }
        }

        private string GenerateToken(int userId, string role)
        {
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("UserID", userId.ToString()),
                    new Claim("Role", role)
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.JWT_Secret)), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescription);
            return tokenHandler.WriteToken(securityToken);
        }
    }
}
