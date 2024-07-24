using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TheFinalProject.core.Authentication;
using TheFinalProject.core.ICommon;
using TheFinalProject.core.IRepositories;
using TheFinalProject.core.IServices;
using TheFinalProject.infra.Common;
using TheFinalProject.infra.Repositories;
using TheFinalProject.infra.Services;

namespace TheFinalProject.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IDbContext, DbContext>();
            //REpository 
            builder.Services.AddScoped<IHallRepository, HallRepository>();
            builder.Services.AddScoped<IVisaInfoRepository, VisaInfoRepository>();
            builder.Services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
            builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

            builder.Services.AddScoped<IUsersRepository, UsersRepository>();
            builder.Services.AddScoped<IUsersService, UsersService>();

            var jwtsettings = new JwtSettings();

            builder.Services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();

            builder.Configuration.Bind(JwtSettings.jwtSettings, jwtsettings);
            builder.Services.AddSingleton(Options.Create(jwtsettings));

            builder.Services.AddCors(coreOptions =>
            {
                coreOptions.AddPolicy("policy",
                    builder =>
                    {
                        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                    });
            });

            builder.Services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new()
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidIssuer = jwtsettings.Issuer,
                    ValidAudience = jwtsettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtsettings.SecretKey))
                };
            });

            //REpository 
            builder.Services.AddScoped<IHallRepository,HallRepository>();

            //Services
            builder.Services.AddScoped<IHallService,HallService>();


            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCors("policy");
            app.MapControllers();

            app.Run();
        }
    }
}
