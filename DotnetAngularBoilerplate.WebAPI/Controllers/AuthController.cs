using Azure;
using DotnetAngularBoilerplate.Model;
using DotnetAngularBoilerplate.Model.DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DotnetAngularBoilerplate.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        public AuthController(IConfiguration configuration, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _configuration = configuration;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterUserDataModel userDetails)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(userDetails.Email);
                if(user != null)
                    return BadRequest(new ApiResponseModel(HttpStatusCode.BadRequest, false, message:"Error! User already registered."));

                //Add the User in the database
                user = new()
                {
                    Email = userDetails.Email,
                    SecurityStamp = Guid.NewGuid().ToString(),
                };

                var result = await _userManager.CreateAsync(user, userDetails.Password);

                if (result.Succeeded)
                    return Ok(new ApiResponseModel(HttpStatusCode.Created, false, message: "Success! User registered successfully."));

                return BadRequest(new ApiResponseModel(HttpStatusCode.BadRequest, false, message: "Error while registering user."));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }    
    }
}
