using System.ComponentModel.DataAnnotations;

namespace LogControl.Domain.Entity
{
    public class Log
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Level { get; set; }
        public string MicroserviceName { get; set; }
        public string Message { get; set; }
        public string? Exception { get; set; }
        public string Environment { get; set; }
        public DateTime Time { get; set; } = DateTime.Now;
    }
}