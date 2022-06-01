using chat_app_web_api.Data;

namespace chat_app_web_api.Service
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8603 // Possible null reference return.
#pragma warning disable CS8604 // Possible null reference argument.

{
    public class WebApiDatabaseContact_ChatService : IContact_ChatService
    {
        chat_app_web_apiContext _context;
        public WebApiDatabaseContact_ChatService(chat_app_web_apiContext context)
        {
            this._context = context;
        }

        public IEnumerable<Contact> GetContacts(Contact contact)
        {
            if(!IsInited())
                return Enumerable.Empty<Contact>();
            var validChats =    from record in _context.Contacts_Chats
                                where record.contact.id == contact.id
                                select record;

            var result =        from record in validChats
                                where record.contact.id != contact.id
                                select record.contact;
            return result;
        }

        public IEnumerable<Contact> GetContacts(string contactId)
        {
            return GetContacts(_context.Contact.Where(c => c.id == contactId).FirstOrDefault());
        }

        private bool IsInited()
        {
            return _context != null &&
                _context.Contact != null &&
                _context.Chat != null &&
                _context.Contacts_Chats != null;
        }
    }
}
