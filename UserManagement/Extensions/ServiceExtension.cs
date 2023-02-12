
using UserManagement.Interfaces;
using UserManagement.Services;
using UserManagement.Services.Scheduler;

namespace UserManagement.Extensions
{
    public static class ServiceExtension
    {
        public static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            #region Add Sceduler
            services.AddHostedService<SchedulerHostedService>();
            services.AddSingleton<ITaskScheduler, Scheduler>();
            #endregion

            #region Add Services

            services.AddTransient<IAuthenticateService, AuthenticateService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IEmailService, EmailService>();

            #endregion
        }
    }
}
