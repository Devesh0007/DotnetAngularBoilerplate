using DotnetAngularBoilerplate.Model;
using DotnetAngularBoilerplate.Model.DataModel;
using DotnetAngularBoilerplate.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace DotnetAngularBoilerplate.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAuthService _authService;

        public AuthController(UserManager<ApplicationUser> userManager, IAuthService authService)
        {
            _userManager = userManager;
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterUserDataModel userDetails)
        {
            try
            {
                var result = await _authService.RegisterUser(userDetails);
                if (result.Success)
                    return Ok(result);
                else
                    return BadRequest(result);
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
                    if (user == null)
                        return BadRequest(new ApiResponseModel(HttpStatusCode.BadRequest, false, message: "Error! User not exists."));
                }

                if (!await _userManager.CheckPasswordAsync(user, userDetails.Password))
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
                claims.Add(new Claim(ClaimTypes.GivenName, user.FirstName));
                claims.Add(new Claim(ClaimTypes.Surname, user.LastName));
                claims.Add(new Claim(ClaimTypes.Email, user.Email));
                claims.Add(new Claim("UserId", user.Id));
                var token = _authService.GenerateJwtToken(claims);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    userId = user.Id,
                    firstName = user.FirstName,
                    lastName = user.LastName,
                    expiresOn = token.ValidTo,
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetLoggedInUserDetails()
        {
            try
            {
                var userInfo = HttpContext.User.Claims.ToList();
                
                return Ok(new
                {
                    //userId = user.Id,
                    //firstName = user.FirstName,
                    //lastName = user.LastName,
                    //expiresOn = token.ValidTo,
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}