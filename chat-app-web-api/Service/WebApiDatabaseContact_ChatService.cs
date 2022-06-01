using chat_app_web_api.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace chat_app_web_api.Service
#pragma warning disable CS8601 // Possible null reference assignment.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8603 // Possible null reference return.
#pragma warning disable CS8604 // Possible null reference argument.

{
    [Authorize]
    public class WebApiDatabaseContact_ChatService : IContact_ChatService
    {
        chat_app_web_apiContext _context;
        public WebApiDatabaseContact_ChatService(chat_app_web_apiContext context)
        {
            this._context = context;
        }

        public Contact GetContactById(string id)
        {
            var res = _context.Contact.Where(x => x.id == id).FirstOrDefault();
            if (res == default)
                return null;
            return res;
        }

        public bool AddContactToUser(Contact connectedContact, string contactId, string name, string server)
        {
            IsInited();
            if (!Queries.CanAddContact(_context ,connectedContact, contactId, name, server))
                return false;
            int maxChatId = Queries.GetMaxIdInChatsContactConnector(_context.Contacts_Chats);
            if (maxChatId < 0)
                throw new Exception();
            Chat newChat;
            var tst = _context.Contacts_Chats.Where(x => x.id == maxChatId + 1);
            if (tst.Count() == 0)
                newChat = new Chat()
                {
                    name = "."
                };
            else
                newChat = _context.Chat.Where(x => x.id == maxChatId + 1).FirstOrDefault();
            _context.Chat.Add(newChat);
            _context.SaveChanges();
            _context.Contacts_Chats.Add(new Contacts_Chats()
            {
                chat = newChat,
                contact = connectedContact
            });
            _context.Contacts_Chats.Add(new Contacts_Chats()
            {
                chat = newChat,
                contact = _context.Contact.Where(x => x.id == contactId).FirstOrDefault()
            });
            _context.SaveChanges();

            return true;
        }

        public IEnumerable<object> GetUserContacts(Contact contact)
        {
            IsInited();
            var result = Queries.GetUserContacts(this._context, contact);
            foreach (var res_contact in result)
                yield return new
                {
                    id = res_contact.id,
                    name = res_contact.name,
                    server = res_contact.server,
                    last = res_contact.last,
                    lastdate = res_contact.lastdate
                };
        }

        public IEnumerable<object> GetUserContacts(string contactId)
        {
            return GetUserContacts(_context.Contact.Where(c => c.id == contactId).FirstOrDefault());
        }

        

        private void IsInited()
        {
            if (!(_context != null &&
                _context.Contact != null &&
                _context.Chat != null &&
                _context.Contacts_Chats != null))
                throw new Exception("Dataset is not set properly.");
        }
    }
}
