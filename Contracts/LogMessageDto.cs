using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public class LogMessageDto
    {
        public string? Level { get; set; }
        public string? MicroserviceName { get; set; }
        public string? Message { get; set; }
        public string? Exception { get; set; }
        public string? Environment { get; set; }
    }
}
