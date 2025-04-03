using Application.Contracts.Persistence.Identities;
using Application.Model.Notifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace CrossCuttingConcerns.ConfigHub;

[Authorize]
public class NotificationHub : Hub
{
    protected static ConnectionMapping _connections = new ConnectionMapping();

    public override Task OnConnectedAsync()
    {
        string name = Contains(Context, "nameidentifier");

        if (IClientRepository._users is not null)
        {
            var client = IClientRepository._users.Where(c => c.Username == name).FirstOrDefault();
            if (client != null)
            {
                var oldConnection = _connections.Add(name, Context.ConnectionId);
                if (oldConnection is not null)
                {
                    Groups.RemoveFromGroupAsync(oldConnection, "Role_" + client.RoleId);
                    Groups.RemoveFromGroupAsync(oldConnection, "Group_" + client.GroupId);
                }
                Groups.AddToGroupAsync(Context.ConnectionId, "Role_" + client.RoleId);
                if (client.GroupId is not null)
                    Groups.AddToGroupAsync(Context.ConnectionId, "Group_" + client.GroupId);
                SendOnline();
            }
        }

        return base.OnConnectedAsync();
    }
    public void SendOnline()
    {
        Clients.All.SendAsync("GetOnline", _connections.GetConnection());
    }
    public static Dictionary<string, string> GetConnection(string[] keys)
    {
        var connectionsIds = new Dictionary<string, string>();
        foreach (var key in keys)
        {
            var value = _connections.GetConnection(key);
            if (value is not null)
                connectionsIds.Add(key, "Offline");
            else connectionsIds.Add(key, value);
        }
        return _connections.GetConnection();
    }

    private string Contains(HubCallerContext httpContextAccessor, string search)
    {
        var flag = httpContextAccessor?.User?.Claims?.ToList();
        return flag is not null ? flag[0].Value : "0";
    }
    public override Task OnDisconnectedAsync(Exception exception)
    {
        string name = Contains(Context, "nameidentifier");
        if (IClientRepository._users is not null)
        {
            var client = IClientRepository._users.Where(c => c.Username == name).FirstOrDefault();
            if (client != null)
            {
                var oldConnection = _connections.GetConnection(name);
                if (oldConnection is not null)
                {
                    Groups.RemoveFromGroupAsync(oldConnection, "Role_" + client.RoleId);
                    Groups.RemoveFromGroupAsync(oldConnection, "Group_" + client.GroupId);
                }
            }
            _connections.Remove(name);
            SendOnline();
        }
        return base.OnDisconnectedAsync(new Exception());
    }
}
