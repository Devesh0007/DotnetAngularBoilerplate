using DotnetAngularBoilerplate.Entity;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);


// For Entity Framework
var configuration = builder.Configuration;
builder.Services.AddDbContext<DotnetAngularBoilerplateDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

// For Identity
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<DotnetAngularBoilerplateDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
})
.AddCookie()
.AddOpenIdConnect(options =>
{
    options.Authority = "http://localhost:8080/realms/keycloak-dev/"; // Replace with your OIDC provider's URL
    options.ClientId = "keycloak-dev-oidc";
    options.ClientSecret = "JBcr2ZcyfxNbNBIaCsm5JEy1b7H69ICd";
    options.ResponseType = "code";
    options.Scope.Add("openid"); // Add any additional scopes you need
    options.Scope.Add("profile"); // Add any additional scopes you need
    options.SaveTokens = true;
    options.RequireHttpsMetadata = false;
    //options.SkipUnrecognizedRequests = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false // You might want to validate the issuer depending on your use case.
    };
});


// Adding Authentication
//builder.Services.AddAuthentication(options =>
// {
//     options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//     options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//     options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
// }); 

 // Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsStaging())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
