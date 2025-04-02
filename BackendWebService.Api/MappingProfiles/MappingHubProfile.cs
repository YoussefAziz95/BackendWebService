using Application.DTOs.Notification;
using Application.DTOs.Notification.Request;
using Application.DTOs.User;
using Application.DTOs.Supplier.Request;
using AutoMapper;
using Domain.Constants;


namespace Persistence.MappingProfiles
{
    /// <summary>
    /// Mapping profile for configuring AutoMapper mappings.
    /// </summary>
    public class MappingHubProfile : Profile
    {
        /// <summary>
        /// Mapping profile for configuring AutoMapper mappings.
        /// </summary>
        public MappingHubProfile()
        {
            CreateMap<AddNotificationRequest, NotificationHubRequest>();
            CreateMap<AddNotificationRequest, Notification>();
            CreateMap<Notification, NotificationHubResponse > ();


        }

    }
}