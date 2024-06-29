using DotnetAngularBoilerplate.Mapper;
using DotnetAngularBoilerplate.Model;
using DotnetAngularBoilerplate.Model.DataModel;
using DotnetAngularBoilerplate.Service.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace DotnetAngularBoilerplate.Service
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;

        private readonly UserManager<ApplicationUser> _userManager;

        public AuthService(UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<string> GetJwtAccessToken(string emailId)
        {
            var user = await _userManager.FindByEmailAsync(emailId);
            if (user == null)
            {
                return null;
            }

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
            var token = GenerateJwtToken(claims);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<ApiResponseModel> RegisterUser(RegisterUserDataModel userDetails)
        {
            try
            {
                if (userDetails is null)
                {
                    throw new ArgumentNullException(nameof(userDetails));
                }

                var user = await _userManager.FindByEmailAsync(userDetails.Email);
                if (user != null)
                    return new ApiResponseModel(HttpStatusCode.BadRequest, false, message: "Error! User already registered.");

                //Add the User in the database
                user = ModelToEntity.Map(userDetails);
                var result = await _userManager.CreateAsync(user, userDetails.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, userDetails.Role);
                    return new ApiResponseModel(HttpStatusCode.Created, true, message: "Success! User registered successfully.");
                }

                return new ApiResponseModel(HttpStatusCode.BadRequest, false, message: "Error while registering user.");
            }
            catch (Exception ex)
            {
                return new ApiResponseModel(HttpStatusCode.BadRequest, false, message: $"Error while registering user. Exception occurred: {ex.Message}.");
            }

        }

        public JwtSecurityToken GenerateJwtToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.UtcNow.AddMinutes(30),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );
            return token;
        }
    }
}