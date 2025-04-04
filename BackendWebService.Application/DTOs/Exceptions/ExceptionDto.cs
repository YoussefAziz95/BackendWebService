using Application.DTOs.Common;
using BackendWebService.Application.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain.Enums;
using Domain;
namespace Application.DTOs.ExceptionLogs
{
    public class ExceptionDto : ICreateMapper<ExceptionLog>
    {
      
        public string? KeyExceptionMessage { get; set; }
        public int ExceptionCode { get; set; }
    }
}
