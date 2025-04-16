using Domain;
using Application.Profiles;
namespace Application.DTOs.ExceptionLogs
{
    public class ExceptionDto
    {

        public string? KeyExceptionMessage { get; set; }
        public int ExceptionCode { get; set; }
    }
}
