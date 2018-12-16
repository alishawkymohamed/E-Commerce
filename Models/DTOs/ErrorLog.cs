using System;

namespace Models.DTOs
{
    public class ErrorLog
    {
        public int Id { get; set; }
        public DateTimeOffset? Time { get; set; }
        public string Url { get; set; }
        public string Type { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public string MachineName { get; set; }
        public string MachineIP { get; set; }
        public string Browser { get; set; }
    }
}