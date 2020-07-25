using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MoveMe.Model.Requests;
using MoveMe.WebAPI.Database;
using MoveMe.WebAPI.Other;
using MoveMe.WebAPI.Services;

namespace MoveMe.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        private readonly ICRUDService<Model.Address, object, AddressUpsertRequest, AddressUpsertRequest> _addressService;
        private readonly ApplicationSettings _appSettings;
        public AuthController(UserManager<User> userManager, RoleManager<IdentityRole<int>> roleManager,
            ICRUDService<Model.Address, object, AddressUpsertRequest, AddressUpsertRequest> addressService,
            IOptions<ApplicationSettings> appSettings)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _addressService = addressService;
            _appSettings = appSettings.Value;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            
            if (user != null && await _userManager.CheckPasswordAsync(user, request.Password))
            {
                var identity = new ClaimsIdentity(IdentityConstants.ApplicationScheme);
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString(), null));
                identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));

                await HttpContext.SignInAsync(IdentityConstants.ApplicationScheme,
                    new ClaimsPrincipal(identity));

                var token = GenerateToken(user.Id);

                return Ok(new { token });
            }
            else
            {
                return BadRequest("Invalid username or password");
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            if (request.Password == request.ConfirmPassword)
            {
                var userCheck = await _userManager.FindByEmailAsync(request.Email);

                if (userCheck != null)
                {
                    return BadRequest("Email already exists");
                }

                var address = _addressService.Insert(new AddressUpsertRequest
                {
                    AdditionalAddress = request.AdditionalAddress,
                    City = request.City,
                    CountryId = request.CountryId,
                    Street = request.Street,
                    ZipCode = request.ZipCode
                });

                var user = new User
                {
                    Email = request.Email,
                    UserName = request.Email,
                    EmailConfirmed = false,
                    Active = true,
                    AddressId = address.AddressId,
                    PhoneNumber = request.PhoneNumber
                };

                var result = await _userManager.CreateAsync(user, request.Password);

                if (request.RoleId == 1)
                {
                    //Admin
                    await _userManager.AddToRoleAsync(user, "Admin");
                } else if (request.RoleId == 2)
                {
                    //Supplier
                    await _userManager.AddToRoleAsync(user, "Supplier");
                    user.Company = request.Company;
                    user.Image = request.Image;
                } else if (request.RoleId == 3)
                {
                    //Client
                    await _userManager.AddToRoleAsync(user, "Client");
                    user.FirstName = request.FirstName;
                    user.LastName = request.LastName;
                }
                await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest(result.Errors);
                }
            }
            else
            {
                return BadRequest("Passwords do not match");
            }
        }

        private string GenerateToken(int userId)
        {
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                    {
                            new Claim("UserID", userId.ToString())
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
