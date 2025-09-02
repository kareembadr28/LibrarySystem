using System.Net;

namespace LibrarySystem.Handler
{
    public class ExceptionResponse
    {
        public string Message { get; set; }
        public string Status { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}
