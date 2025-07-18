namespace PatientControl.Application.DTOs.Logs
{
    public class LogMessageDto
    {
        public string Level { get; set; }
        public string MicroserviceName { get; set; } = "PatientControl";
        public string Message { get; set; }
        public string? Exception { get; set; }
        public string Environment { get; set; }
    }
}
