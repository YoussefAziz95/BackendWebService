using Application.Profiles;

using System;

namespace Application.DTOs.Loggings
{
    public class LoggingDto : ICreateMapper<Logging>
    {
        public string Message { get; set; }
        public string LogType { get; set; }

        public string? Suggestion { get; set; }
        public string SourceLayer { get; set; }
        public string SourceClass { get; set; }
        public int SourceLineNumber { get; set; }
        public int? UserId { get; set; }
        public DateTime Timestamp { get; set; }



    }
}
