using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
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
        [Route("api/OIDC/SignInCallback")]
        [HttpGet, HttpPost]
        public async Task SignInCallback()
        {
            var access_token = await HttpContext.GetTokenAsync(OpenIdConnectDefaults.AuthenticationScheme, "access_token");
            var id_token = await HttpContext.GetTokenAsync(OpenIdConnectDefaults.AuthenticationScheme, "id_token");
            var userInfo = HttpContext.User;
        }

        [Authorize(AuthenticationSchemes = OpenIdConnectDefaults.AuthenticationScheme)]
        [Route("api/OIDC/InitiateSingleSignOut")]
        [HttpGet, HttpPost]
        public async Task InitiateSingleSignOut()
        {
            var id_token = await HttpContext.GetTokenAsync(OpenIdConnectDefaults.AuthenticationScheme, "id_token");

            //await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            //await HttpContext.SignOutAsync(OpenIdConnectDefaults.AuthenticationScheme);

            //var a = new OpenIdConnectOptions().Configuration.EndSessionEndpoint;
            //Uri logout = new Uri()
        }

        [AllowAnonymous]
        [Route("api/OIDC/SignOutCallback")]
        [HttpGet, HttpPost]
        public async Task SignOutCallback()
        {
            
        }
    }
}