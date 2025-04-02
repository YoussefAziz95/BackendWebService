using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Proxy
{
    public interface INotificationProxy<T>
    {
        Task NotifyAsync(string message, int notificationId, string[] NotifiedUserName, T response);
    }
}
