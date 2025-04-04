using BackendWebService.Application.Profiles;
using Domain;
using System;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Notifications;

public class NotificationHubResponse : ICreateMapper<Notification>
{

    [Required]
    public string MessageTitle { get; set; }

    [Required]
    public string MessageBody { get; set; }
    public string? Priority { get; set; }
    public string? Status { get; set; }
    public DateTime? TimeStamp { get; set; }
    public DateTime? ExpiryDate { get; set; }

    public bool? IsRead { get; set; }
    public int? NotifierId { get; set; }

    public string? Email { get; set; }


}
