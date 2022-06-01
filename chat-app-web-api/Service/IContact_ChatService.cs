using Microsoft.AspNetCore.Mvc;

namespace chat_app_web_api.Service
{
    public interface IContact_ChatService
    {
        public IEnumerable<object> GetUserContacts(Contact contact);

        public IEnumerable<object> GetUserContacts(string contactId);

        public bool AddContactToUser(Contact connectedContact, string contactId, string name, string server);
        public Contact GetContactById(string v);
    }
}
