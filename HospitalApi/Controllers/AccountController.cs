using HospitalApi.Data;
using HospitalApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HospitalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<Citizen> _userManager;
        private readonly SignInManager<Citizen> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<Citizen> userManager, SignInManager<Citizen> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.FindByEmailAsync(loginModel.Email);

            if (user != null)
            {
                var result = await _signInManager.CheckPasswordSignInAsync(user, loginModel.Password, false);

                if (result.Succeeded)
                {
                    // Password correct, check roles
                    var roles = await _userManager.GetRolesAsync(user);

                    // Do something with roles if needed

                    // Generate token
                    var token = GenerateJwtToken(user, roles);

                    // Return token in response
                    return Ok(new { Token = token, Roles = roles });
                }
            }

            // User not found or password incorrect
            return BadRequest("Invalid login attempt");
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto registerModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new Citizen
            {
                UserName = registerModel.Name,
                Email = registerModel.Email,
            };

            string[] roleNames = { "Admin", "User" }; //if role doesnt exist then create one
            IdentityResult roleResult;
            foreach (var roleName in roleNames)
            {
                var roleExist = await _roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    roleResult = await _roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            var result = await _userManager.CreateAsync(user, registerModel.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, UserRoles.Admin);

                await _signInManager.SignInAsync(user, isPersistent: false);

                var token = GenerateJwtToken(user, new List<string> { UserRoles.Admin }); // varsayılan olarak "user" rolü eklenmiştir

                return Ok(new { Token = token, UserName = user.UserName, Email = user.Email });
            }

            return BadRequest(result.Errors);
        }

        [HttpGet]
        public async Task<IActionResult> GetCitizenByEmail(string email)
        {
            var citizen = await _userManager.FindByEmailAsync(email);

            if(citizen == null)
            {
                return NotFound();
            }

            return Ok(citizen);
        }


        private string GenerateJwtToken(Citizen user, IList<string> roles)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Convert.FromBase64String("401b09eab3c013d4ca54922bb802bec8fd5318192b0a75f201d8b3727429090fb337591abd3e44453b954555b7a0812e1081c39b740293f765eae731f5a65ed1");

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim(ClaimTypes.Name, user.Id),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.NameIdentifier, user.UserName)
                // Add other claims as needed
            }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            if (roles.Any())
            {
                // Add roles to claims
                tokenDescriptor.Subject.AddClaims(roles.Select(role => new Claim(ClaimTypes.Role, role)));
            }

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }



    }
}
