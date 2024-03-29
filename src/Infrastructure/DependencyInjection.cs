﻿
using ZenAchitecture.Domain.Shared.Entities;
using ZenAchitecture.Domain.Interfaces;
using ZenAchitecture.Infrastructure.Identity;
using ZenAchitecture.Infrastructure.Persistence;
using ZenAchitecture.Infrastructure.Shared.Services;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Zen.Bog.Ecommerce;
using Zen.Infrastructure.Interfaces;
using Infrastructure.Shared;
using ZenAchitecture.Infrastructure.Shared.Persistence;
using ZenAchitecture.Domain.Shared.Interfaces;

namespace ZenAchitecture.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddInfrastructureShared(configuration);
            
            services.AddZenBogEcommerce(configuration);

            services.AddScoped<IAppDbContext>(provider => provider.GetService<ApplicationDbContext>());

            services
                .AddDefaultIdentity<ApplicationUser>(options =>
                {
                    options.Password.RequireDigit = false;
                    options.Password.RequiredLength = 5;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;

                })
                .AddRoles<IdentityRole>()
                .AddErrorDescriber<CustomIdentityErrorDescriber>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            var issuerUri = configuration.GetSection("IdentityServer")["AuthorityUrl"];

            services.AddIdentityServer(option =>
            {
                option.IssuerUri = issuerUri;
            })
            .AddApiAuthorization<ApplicationUser, ApplicationDbContext>(option =>
            {
                // msdn https://docs.microsoft.com/en-us/aspnet/core/security/authentication/identity-api-authorization?view=aspnetcore-6.0
                option.Clients.AddSPA(
                     configuration.GetSection("IdentityServer")["ClientId"], spa => spa
                            .WithRedirectUri(configuration.GetSection("IdentityServer")["LoginCallbackUrl"])
                            .WithLogoutRedirectUri(configuration.GetSection("IdentityServer")["LogoutCallbackUrl"])
                        );

                foreach (var client in option.Clients)
                {
                    client.AllowOfflineAccess = true;
                    client.UpdateAccessTokenClaimsOnRefresh = true;
                    client.AccessTokenLifetime = 3600; // seconds / 1 hour
                }
            })
            .AddProfileService<ProfileService>();

            services.AddTransient<IDateTime, DateTimeService>();
            services.AddTransient<IIdentityService, IdentityService>();

            services.AddAuthentication()
                .AddIdentityServerJwt();

            services.Configure<JwtBearerOptions>(
                        IdentityServerJwtConstants.IdentityServerJwtBearerScheme,
                        options =>
                        {
                            options.Authority = issuerUri;
                        });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("CanPurge", policy => policy.RequireRole("Administrator"));
            });

            return services;
        }



    }
}