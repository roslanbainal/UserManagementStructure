using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using UserManagement.Interfaces;

namespace UserManagement.Services.Scheduler
{
    public class Scheduler : ITaskScheduler
    {
        // run every 12:00 am
        public string Schedule { get; } = "0 0 * * *";

        private readonly ILogger<Scheduler> _logger;
        private readonly IServiceProvider _serviceProvider;

        public Scheduler(ILogger<Scheduler> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        public async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Daily Task Running...");

            // Perform your daily task here

            try
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var emailScopeService = scope.ServiceProvider.GetRequiredService<IUserService>();

                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            await Task.CompletedTask;
        }
    }
}
