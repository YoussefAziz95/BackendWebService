using Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Services
{
    public interface IOrganizationService
    {
        Task<string> OrganizationNameById(int Id);
    }
}
