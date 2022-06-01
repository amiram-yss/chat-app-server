namespace chat_app_web_api.Service
{
    public interface IContact_ChatService
    {
        public IEnumerable<object> GetContacts(Contact contact);

        public IEnumerable<object> GetContacts(string contactId);
    }
}
