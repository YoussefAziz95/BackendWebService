using Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.ExceptionLog
{
    public class ExceptionDto
    {
      
        public string? KeyExceptionMessage { get; set; }
        public int ExceptionCode { get; set; }
    }
}
