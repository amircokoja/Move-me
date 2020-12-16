using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MoveMe.Model;
using MoveMe.Model.Requests;
using MoveMe.WebAPI.Other;
using MoveMe.WebAPI.Services;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MoveMe.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<Database.User> _userManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        private readonly ICRUDService<Model.Address, object, AddressUpsertRequest, AddressUpsertRequest> _addressService;
        private readonly ApplicationSettings _appSettings;
        private readonly IMapper _mapper;
        public AuthController(UserManager<Database.User> userManager, RoleManager<IdentityRole<int>> roleManager,
            ICRUDService<Model.Address, object, AddressUpsertRequest, AddressUpsertRequest> addressService,
            IOptions<ApplicationSettings> appSettings, IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _addressService = addressService;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }

        [HttpPost("login")]
        public async Task<Login> Login(LoginRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user != null && await _userManager.CheckPasswordAsync(user, request.Password))
            {
                var roles = await _userManager.GetRolesAsync(user);
                if (!roles.Any(x => request.Roles.Any(y => y == x)))
                {
                    throw new UserException("Not authorized");
                }

                //var identity = new ClaimsIdentity(IdentityConstants.ApplicationScheme);
                //identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString(), null));
                //identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));

                //await HttpContext.SignInAsync(IdentityConstants.ApplicationScheme,
                //    new ClaimsPrincipal(identity));

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

        [HttpPost("register")]
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

        [HttpGet]
        public async Task<List<User>> GetAll([FromQuery]UserSearchReqeust request)
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

        [HttpGet("get-roles")]
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

        [HttpPost("craete-role")]
        public async Task<IActionResult> CreateRole(string role)
        {
            IdentityRole<int> newRole = new IdentityRole<int> { Name = role };
            await _roleManager.CreateAsync(newRole);

            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<User> GetById(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            return _mapper.Map<User>(user);
        }

        [HttpPut("{id}")]
        public async Task<User> Update(int id, UserUpdateRequest request)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());

            if (user == null)
            {
                throw new UserException("User is not found");
            }

            _mapper.Map(request, user);
            user.UserName = request.Email;

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

        [HttpPost("changepassword/{id}")]
        public async Task<User> ChangePassword(int id, [FromBody]PasswordChangeRequest request)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());

            if (request.NewPassword == request.ConfirmPassword)
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
            else
            {
                throw new UserException("New password and confirm password are not equal");
            }
        }
    }
}
