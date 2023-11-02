using DotnetAngularBoilerplate.Model.DataModel;
using DotnetAngularBoilerplate.Service.Interface;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DotnetAngularBoilerplate.WebAPI.Controllers
{
    [ApiController]
    public class OidcController : ControllerBase
    {
        private readonly IAuthService _authService;
        public OidcController(IAuthService authService)
        {
            _authService = authService;
        }
        [AllowAnonymous]
        [Route("api/oidc/InitiateSingleSignOn")]
        [HttpGet, HttpPost]
        public async Task InitiateSingleSignOn([FromQuery] string ssoProvider)
        {
            if (string.IsNullOrEmpty(ssoProvider))
            {
                throw new ArgumentException($"'{nameof(ssoProvider)}' cannot be null or empty.", nameof(ssoProvider));
            }

            await HttpContext.ChallengeAsync(OpenIdConnectDefaults.AuthenticationScheme, new AuthenticationProperties()
            {
                RedirectUri = "/api/OIDC/SignInCallback",
            });
        }

        [Authorize(AuthenticationSchemes = OpenIdConnectDefaults.AuthenticationScheme)]
        [Route("api/OIDC/SignInCallback")]
        [HttpGet, HttpPost]
        public async Task<IActionResult> SignInCallback()
        {
            //var access_token = await HttpContext.GetTokenAsync(OpenIdConnectDefaults.AuthenticationScheme, "access_token");
            //var id_token = await HttpContext.GetTokenAsync(OpenIdConnectDefaults.AuthenticationScheme, "id_token");
            var token = await _authService.GetJwtAccessToken(HttpContext.User.Claims.FirstOrDefault(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")?.Value);
            if(token == null)
            {
                RegisterUserDataModel userInfo = new()
                {
                    Email = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")?.Value,
                    UserName = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "preferred_username")?.Value,
                    FirstName = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname")?.Value,
                    LastName = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/surname")?.Value,
                    Password = "Dngb@1234",
                    Role = "Manager",
                };

                var result = await _authService.RegisterUser(userInfo);
                token = await _authService.GetJwtAccessToken(userInfo.Email);
            }

            return Redirect("http://localhost:4200/auth/ssoLogin?token="+ token);
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