using chat_app_web_api.Data;

namespace chat_app_web_api.Service
{
    public class WebApiDatabaseMessagesService : IMessagesService
    {
        chat_app_web_apiContext _context;
        public WebApiDatabaseMessagesService(chat_app_web_apiContext context)
        {
            _context = context;
        }

        private Chat GetChatOfTwoContacts(string id1, string id2)
        {
            var allChatIdsWithId1Inside = from c in _context.Contacts_Chats
                    where c.contact.id == id1
                    select c;
            var res = (from connector in allChatIdsWithId1Inside
                       where connector.contact.id == id2
                       select connector.chat).FirstOrDefault();
            return res;
        }
        private int GetChatIdOfTwoContacts(string id1, string id2)
        {
            return GetChatOfTwoContacts(id1, id2).id;
        }

        public bool CreateMessageWith(string myId, string otherId, string content)
        {
            try
            {
                var chatId = GetChatOfTwoContacts(myId, otherId);
                _context.Message.Add(new ChatAppWebApi.Message
                {
                    Chat = GetChatOfTwoContacts(myId, otherId),
                    ChatId = GetChatIdOfTwoContacts(myId, otherId),
                    Sender = _context.Contact.Where(x => x.id == myId).FirstOrDefault(),
                    Content = content,
                    CreatedAt = DateTime.Now,
                    SenderId = myId
                }) ;
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IOrderedQueryable<Message> GetMeesagesWith(string myId, string otherId)
        {
            throw new NotImplementedException();
            /*
            try
            {

                var chatId = GetChatIdOfTwoContacts(myId, otherId);
                var messages = _context.Message.Where(x => x.ChatId == chatId).OrderBy(x => x.CreatedAt);
                return messages;
            }
            catch
            {
                return null;
            }*/
        }
    }
}
