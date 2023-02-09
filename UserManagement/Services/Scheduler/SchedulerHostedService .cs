using UserManagement.Interfaces;

namespace UserManagement.Services.Scheduler
{
    public class SchedulerHostedService : BackgroundService
    {
        private readonly IEnumerable<ITaskScheduler> _tasksScheduler;

        public SchedulerHostedService(IEnumerable<ITaskScheduler> tasksScheduler)
        {
            _tasksScheduler = tasksScheduler;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                foreach (var task in _tasksScheduler)
                {
                    await task.ExecuteAsync(stoppingToken);
                }

                await Task.Delay(TimeSpan.FromDays(1), stoppingToken);
            }
        }
    }
}
