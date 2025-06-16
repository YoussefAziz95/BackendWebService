
using Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Domain;
[Table("Job")]
public class Job
{
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; } 
    public DateTime EndDate { get; set; }
    public DateTime ExpirationTime { get; set; }
    public bool IsVerified { get; set; } = false;
}