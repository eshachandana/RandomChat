using RandomChat.Models;
using RandomChat.Services;
using Microsoft.AspNetCore.SignalR;

namespace RandomChat.Server.Hubs
{
    public class ChatHub : Hub
    {
        private readonly MessageServices _messageService;

        public ChatHub(MessageServices messageService)
        {
            _messageService = messageService;
        }

        public async Task SendMessage(string user, string message)
        {
            _messageService.AddMessage(new Message { User = user, Content = message });
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public async Task GetAllMessages()
        {
            var messages = _messageService.GetMessages();
            await Clients.Caller.SendAsync("ReceiveAllMessages", messages);
        }
    }
}
