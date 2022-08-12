using Microsoft.AspNetCore.SignalR;
using SignalR.Hubs.ClientHubs;

namespace SignalR.Hubs.ServerHubs;

public class PersonHub : Hub<IPersonHubProxy>
{
    public async Task SendMessage(string message)
    {
        await Clients.All.ReceivedMessage(message);
    }

    public async Task UserConnected()
    {
        await Clients.All.NewUserAdded();
    }
}