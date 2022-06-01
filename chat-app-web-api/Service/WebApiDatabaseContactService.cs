using chat_app_web_api.Data;
using Microsoft.AspNetCore.Mvc;

namespace chat_app_web_api.Service
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8603 // Possible null reference return.
#pragma warning disable CS8604 // Possible null reference argument.

{
    public class WebApiDatabaseContactService : IContactService
    {
        chat_app_web_apiContext _context;

        public WebApiDatabaseContactService(chat_app_web_apiContext context, IConfiguration configuration)
        {
            this._context = context;
        }

        public bool AddContact(Contact updatedContact)
        {
            if (!IsInitialized())
                return false;
            if (updatedContact == null)
                return false;
            if (ContactExists(updatedContact.id))
                return false;
            _context.Contact.Add(updatedContact);
            return true;
        }

        public bool ContactExists(string id)
        {
            return (_context.Contact?.Any(e => e.id == id)).GetValueOrDefault();
        }

        public bool DeleteContact(string id)
        {
            if (!ContactExists(id))
                return false;
            var connectorsRecordsToRemove = from cnt in _context.Contacts_Chats
                             where cnt.contact.id == id
                             select cnt.chat.id;
            _context.Contact.Remove(GetById(id));
            foreach (var connector in connectorsRecordsToRemove)
            {
                _context.Contacts_Chats.Remove(_context.Contacts_Chats.Where(x => connectorsRecordsToRemove.Contains(x.chat.id)).FirstOrDefault());
            }
            _context.SaveChanges();
            return true;
        }

        public IEnumerable<Contact> GetAll()
        {
            if(!IsInitialized())
                return Enumerable.Empty<Contact>();
            return _context.Contact;
        }

        public Contact? GetById(string id)
        {
            if(string.IsNullOrEmpty(id))
                return null;
            if (!IsInitialized())
                return null;
            return _context.Contact.Where(x => x.id == id)
                .FirstOrDefault();
        }

        public bool IsInitialized()
        {
            if (_context == null)
                return false;
            if (_context.Contact == null)
                return false;
            return true;
        }

        public IEnumerable<Contact> Login(string connectionJSON)
        {
            throw new NotImplementedException();
        }

        public bool CanLogin(string username, string password)
        {
            if (!IsInitialized())
                return false;
            var info = GetById(username);
            if(info == null)
                return false;
            if (info.password != password)
                return false;
            return true;
        }

        public bool UpdateContact(Contact updatedContact, string name, string server, string password)
        {
            try
            {
                _context.Contact.Where(_x => _x.id == updatedContact.id).FirstOrDefault().name = name;
                _context.Contact.Where(_x => _x.id == updatedContact.id).FirstOrDefault().server = server;
                _context.Contact.Where(_x => _x.id == updatedContact.id).FirstOrDefault().password = password;
                _context.SaveChanges();
                return true;
            }
            catch { return false; }
        }

        public bool CreateContact(string id, string name, string server, string password)
        {
            try
            {
                _context.Contact.Add(new Contact()
                {
                    id = id,
                    name = name,
                    server = server,
                    password = password
                });
                _context.SaveChanges();
                return true;
            }
            catch { return false; }
        }

        IEnumerable<Contact> IContactService.GetById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
