using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DotnetAngularBoilerplate.WebAPI.Controllers
{
    [ApiController]
    public class OIDCController : ControllerBase
    {
        [AllowAnonymous]
        [Route("api/OIDC/InitiateSingleSignOn")]
        [HttpGet, HttpPost]
        public async Task InitiateSingleSignOn()
        {
            await HttpContext.ChallengeAsync(OpenIdConnectDefaults.AuthenticationScheme, new AuthenticationProperties()
            {
                RedirectUri = "/api/OIDC/SignInCallback",
            });
        }

        [Authorize(AuthenticationSchemes = OpenIdConnectDefaults.AuthenticationScheme)]
        //[Route("signin-oidc")]
        [Route("api/OIDC/SignInCallback")]
        [HttpGet, HttpPost]
        public async Task SignInCallback()
        {
            var access_token = await HttpContext.GetTokenAsync(OpenIdConnectDefaults.AuthenticationScheme, "access_token");
            var id_token = await HttpContext.GetTokenAsync(OpenIdConnectDefaults.AuthenticationScheme, "id_token");
            var userInfo = HttpContext.User;
        }
    }
}