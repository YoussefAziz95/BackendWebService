using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

[Owned]
public class Otp
{
    public string Code { get; set; }
    public DateTime ExpiresOn { get; set; }
    public DateTime CreatedOn { get; set; }
    public bool IsExpired => DateTime.UtcNow >= ExpiresOn;
    public bool IsUsed { set; get; } = false;

}