using IdentityAndAccess.API.Constants;
using IdentityAndAccess.API.Data;
using IdentityAndAccess.API.Extensions;
using IdentityAndAccess.API.PolicyRequirements;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace IdentityAndAccess.API.Configuration
{
    public static class IdentityConfig
    {
        public static IServiceCollection AddIdentityConfig(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders(); // Adds the default token providers used to generate tokens for reset passwords, change email and change telephone number operations, and for two factor authentication token generation.

            services.AddAuthorization(options =>
            {
                #region Example using Policy with claims:
                // In this policy configuration example, if ClaimValue is 'CanRead, CanCreate, CanUpdate', it will not allow access when the policy "CanDelete" is necessary,
                // it will only allow access when ClaimValue is exactly "CanDelete";
                options.AddPolicy("CanDelete", policy => policy.RequireClaim("CanDelete"));

                // In this policy configuration example, if ClaimValue is 'CanRead, CanCreate, CanUpdate', it will allow access when the policy "CanRead" is necessary;
                options.AddPolicy("CanRead", policy => policy.Requirements.Add(new NecessaryPermission("CanRead")));
                #endregion

                #region Example using Policy requirement:
                options.AddPolicy(Policies.WorkingHours, policy =>
                    policy.Requirements.Add(new WorkingHoursRequirement()));
                #endregion

            });

            services.AddSingleton<IAuthorizationHandler, NecessaryPermissionHandler>();

            // JWT

            var appSettingsSection = configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = true;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = appSettings.Audience,
                    ValidIssuer = appSettings.Issuer
                };
            });

            return services;
        }

        public static void AddAuthorizationPolicies(this IServiceCollection services)
        {
            services.AddSingleton<IAuthorizationHandler, WorkingHoursHandler>();
            services.AddAuthorization(options =>
            {
                options.AddPolicy(Policies.WorkingHours, policy =>
                    policy.Requirements.Add(new WorkingHoursRequirement()));
            });
        }
    }
}