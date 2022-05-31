using chat_app_web_api.Data;

namespace chat_app_web_api.Service
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8603 // Possible null reference return.
#pragma warning disable CS8604 // Possible null reference argument.

{
    public class WebApiDatabaseContactService : IContactService
    {
        chat_app_web_apiContext _context;
        public WebApiDatabaseContactService(chat_app_web_apiContext context)
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
            throw new NotImplementedException();
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

        public IEnumerable<Contact> Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        public bool UpdateContact(Contact updatedContact)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Contact> IContactService.GetById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
