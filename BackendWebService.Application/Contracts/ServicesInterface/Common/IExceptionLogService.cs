using Application.DTOs.ExceptionLogs;
using Application.DTOs.SupplierCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Services
{
    public interface IExceptionLogService
    {
        void Add(ExceptionDto request);
    }
}
