using chat_app_web_api.Data;

namespace chat_app_web_api.Service
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
            throw new NotImplementedException();
        }

        public bool DeleteContact(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Contact> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Contact> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Contact> Login(string connectionJSON)
        {
            throw new NotImplementedException();
        }

        public bool UpdateContact(Contact updatedContact)
        {
            throw new NotImplementedException();
        }
    }
}
