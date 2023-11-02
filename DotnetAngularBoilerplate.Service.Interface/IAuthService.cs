using DotnetAngularBoilerplate.Model;
using DotnetAngularBoilerplate.Model.DataModel;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace DotnetAngularBoilerplate.Service.Interface
{
    public interface IAuthService
    {
        Task<ApiResponseModel> RegisterUser(RegisterUserDataModel registerUserDataModel);
        Task<string> GetJwtAccessToken(string emailId);

        JwtSecurityToken GenerateJwtToken(List<Claim> authClaims);

    }
}