using Microsoft.AspNetCore.Mvc;

namespace chat_app_web_api.Service
{
    public interface IMessagesService
    {
        public IEnumerable<Message> GetMeesagesWith(string myId, string otherId);
        public bool CreateMessageWith(string myId, string otherId, string content);

    }
}
