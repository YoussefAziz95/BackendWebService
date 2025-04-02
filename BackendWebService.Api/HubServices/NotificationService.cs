using Application.Contracts.HubServices;
using Application.Contracts.Presistence.Identities;
using Application.Contracts.Presistence.Notifications;
using Application.Contracts.Proxy;
using Application.DTOs.Notification;
using Application.DTOs.Notification.Request;
using Application.MappingProfiles;
using Application.Wrappers;
using AutoMapper;


namespace Presentation.HubServices
{
    public class NotificationService : ResponseHandler, INotificationService
    {
        private readonly INotificationProxy<NotificationHubResponse> _notificationProxy;
        private readonly INotificationRepository _notificationRepository;
        private readonly IMapper _mapper;

        public NotificationService(INotificationProxy<NotificationHubResponse> notificationProxy,
            IMapper mapper,
            INotificationRepository notification)
        {
            _mapper = mapper;
            _notificationRepository = notification;
            _notificationProxy = notificationProxy;
        }


        public async Task<bool> SendMessageAsync(AddNotificationRequest request)
        {
            var addNotificationRequest = _mapper.Map<NotificationHubRequest>(request);
            var notification = _mapper.Map<Notification>(request);
          
            var result = await _notificationRepository.AddAsync(notification);

            string[] userNames = [];
            if (request.NotifiedType == "Customer")
            {
                userNames = IClientRepository._users.Where(u => u.UserId == request.NotifiedId).Select(u => u.Username).Distinct().ToArray();
            }
            else if (request.NotifiedType == "Role")
            {
                userNames = IClientRepository._users.Where(u => u.RoleId == request.NotifiedId).Select(u => u.Username).Distinct().ToArray();
            }
            else if (request.NotifiedType == "Group")
            {
                userNames = IClientRepository._users.Where(u => u.GroupId == request.NotifiedId).Select(u => u.Username).Distinct().ToArray();
            }
            var response = _mapper.Map<NotificationHubResponse>(notification);

            await _notificationProxy.NotifyAsync(request.NotificationType, result, userNames, response);

            return result > 0;

        }

    }
}
