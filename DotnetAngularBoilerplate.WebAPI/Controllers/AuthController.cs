using Azure;
using DotnetAngularBoilerplate.Mapper;
using DotnetAngularBoilerplate.Model;
using DotnetAngularBoilerplate.Model.DataModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text.Unicode;
using System.Text;

namespace DotnetAngularBoilerplate.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        public AuthController(UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterUserDataModel userDetails)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(userDetails.Email);
                if(user != null)
                    return BadRequest(new ApiResponseModel(HttpStatusCode.BadRequest, false, message:"Error! User already registered."));

                //Add the User in the database
                user = ModelToEntity.Map(userDetails);
                var result = await _userManager.CreateAsync(user, userDetails.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, userDetails.Role);
                    return Ok(new ApiResponseModel(HttpStatusCode.Created, false, message: "Success! User registered successfully."));
                }

                return BadRequest(new ApiResponseModel(HttpStatusCode.BadRequest, false, message: "Error while registering user."));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginUserDataModel userDetails)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(userDetails.Email);
                if (user == null)
                {
                    user = await _userManager.FindByNameAsync(userDetails.UserName);
                    if(user == null)
                        return BadRequest(new ApiResponseModel(HttpStatusCode.BadRequest, false, message: "Error! User not exists."));
                }
                
                if(!await _userManager.CheckPasswordAsync(user, userDetails.Password))
                    return Unauthorized(new ApiResponseModel(HttpStatusCode.Unauthorized, false, message: "Error! Invalid password."));
                
                List<Claim> claims = new()
                {
                    new Claim(ClaimTypes. Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                var roles = await _userManager.GetRolesAsync(user);
                foreach (var role in roles) 
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }
                var token = GenerateJwtToken(claims);

                return Ok(new {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiry = token.ValidTo,
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        private JwtSecurityToken GenerateJwtToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );
            return token;
        }
    }
}
