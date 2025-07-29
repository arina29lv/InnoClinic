namespace AccountControl.Infrastructure.Interfaces
{
    public interface ILogService
    {
        Task LogInfo(string message, string? exception = null);
        Task LogWarning(string message, string? exception = null);
        Task LogError(string message, string? exception = null);
    }
}
