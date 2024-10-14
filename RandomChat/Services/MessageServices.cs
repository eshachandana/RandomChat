using RandomChat.Models;

namespace RandomChat.Services
{
    public class MessageServices
    {
        private static List<Message> _messages = new List<Message>();

        public IEnumerable<Message> GetMessages() => _messages;

        public void AddMessage(Message message)
        {
            _messages.Add(message);
        }
    }

    public class Message
    {
        public string User { get; set; }
        public string Content { get; set; }
    }
}

