using SignalR.Models;

namespace SignalR.Hubs.ClientHubs;

public interface IPersonHubProxy
{
    Task ReceivedMessage(string message);
    Task NewUserAdded();
    Task NewPersonAdded(Person person);
}