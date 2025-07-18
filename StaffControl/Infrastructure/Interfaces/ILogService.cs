namespace StaffControl.Infrastructure.Interfaces
{
    public interface ILogService
    {
        void LogInfo(string message, string? exception = null);
        void LogWarning(string message, string? exception = null);
        void LogError(string message, string? exception = null);
    }
}
