using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Domain;
public class UserRole : IdentityUserRole<int>
{
    public User User { get; set; }
    public Role Role { get; set; }


}