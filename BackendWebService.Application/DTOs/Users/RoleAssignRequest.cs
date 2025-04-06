using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendWebService.Application.DTOs.Users;

public class RoleAssignRequest
{
    public int UserId { get; set; }
    public string Role { get; set; }
}
