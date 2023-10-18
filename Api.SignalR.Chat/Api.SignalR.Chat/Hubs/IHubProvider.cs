using Api.SignalR.Chat.Models;

namespace Api.SignalR.Chat.Hubs
{
    public interface IHubProvider
    {
        Task ReceivedMessageAsync(Message message);
    }
}
