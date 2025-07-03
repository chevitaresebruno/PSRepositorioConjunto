
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using ToDoList.Domain.Security.Account;
using System.Text;

namespace ToDoList.WebApi.Extensions
{
    public static class BuilderExtension
    {
        // Recuperação das Private Keys definidas no appsettings.json
        public async static void AddConfiguration(this WebApplicationBuilder builder)
        {
            bool prod = false;

            if (prod)
            {
                Configuration.Secrets.ApiKey = Environment.GetEnvironmentVariable("ApiKey");
                Configuration.Secrets.JwtPrivateKey = Environment.GetEnvironmentVariable("JwtPrivateKey");
                Configuration.Secrets.PasswordSaltKey = Environment.GetEnvironmentVariable("PasswordSaltKey");

                Configuration.Email.DefaultFromEmail = Environment.GetEnvironmentVariable("DefaultFromEmail");
                Configuration.Email.ApiKey = Environment.GetEnvironmentVariable("EmailApiKey");
            }
            else
            {
                Configuration.Secrets.ApiKey = Environment.GetEnvironmentVariable("ApiKey");
                Configuration.Secrets.JwtPrivateKey = Environment.GetEnvironmentVariable("JwtPrivateKey");
                Configuration.Secrets.PasswordSaltKey = Environment.GetEnvironmentVariable("PasswordSaltKey");

                Configuration.Email.DefaultFromEmail = Environment.GetEnvironmentVariable("DefaultFromEmail");
                Configuration.Email.ApiKey = Environment.GetEnvironmentVariable("EmailApiKey");
            }
        }
        // Configuraçãod do JWT na api
        public static void AddJwtAuthentication(this WebApplicationBuilder builder)
        {
            builder.Services
                .AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                }).AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration.Secrets.JwtPrivateKey)),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });
            builder.Services.AddAuthorization();
        }
    }
}