namespace chat_app_web_api.Service
{
    public interface IContact_ChatService
    {
        public IEnumerable<Contact> GetContacts(Contact contact);

        public IEnumerable<Contact> GetContacts(string contactId);
    }
}
