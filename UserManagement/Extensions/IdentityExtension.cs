using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UserManagement.Data;
using UserManagement.Interfaces;
using UserManagement.Models.Entities;
using UserManagement.Security.Authorization;
using UserManagement.Services;

namespace UserManagement.Extensions
{
    public static class IdentityExtension
    {
        public static void AddIdentityConfig(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseOracle(
                    configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Transient);

            services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
            {
                options.SignIn.RequireConfirmedEmail = true;
            }).AddEntityFrameworkStores<ApplicationDbContext>()
              .AddDefaultTokenProviders();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.LoginPath = "/Account/Login";
                options.AccessDeniedPath = "/Home/Denied";
            });

            services.AddHttpContextAccessor();

            #region Authorization Filter

            services.AddScoped<IEndPointStore, EndpointStore>();
            services.AddAuthorization(options =>
            {
                options.AddPolicy("EndpointAccess", policy =>
                    policy.Requirements.Add(new DynamicEndpointAuthorizationRequirement()));
            });
            services.AddScoped<IAuthorizationHandler, DynamicEndpointAuthorizationHandler>();

            #endregion
        }
    }
}
