namespace UserManagement.Interfaces
{
    public interface ITaskScheduler
    {
        string Schedule { get; }
        Task ExecuteAsync(CancellationToken cancellationToken);
    }
}
