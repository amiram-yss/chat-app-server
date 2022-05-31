namespace chat_app_web_api.Service
{
    public interface IContactService
    {
        /// <summary>
        /// Get all contacts for registered user.
        /// </summary>
        /// <returns>All contacts for</returns>
        public IEnumerable<Contact> GetAll();

        /// <summary>
        /// Gets contact by id.
        /// </summary>
        /// <param name="id">Contact's ID</param>
        /// <returns>Contact with the id, or null if doesn't exist.</returns>
        public IEnumerable<Contact> GetById(string id);

        /// <summary>
        /// Add contact
        /// </summary>
        /// <param name="newContact">Contact to add</param>
        /// <returns>True if insertion succeeded. False O.W.</returns>
        public bool AddContact(Contact updatedContact);

        /// <summary>
        /// Update Contact details
        /// </summary>
        /// <param name="updatedContact">Contac to update</param>
        /// <returns>True for</returns>
        public bool UpdateContact(Contact updatedContact);

        /// <summary>
        /// Deletes a contact with key == id.
        /// </summary>
        /// <param name="id">Contact's id to delete</param>
        /// <returns></returns>
        public bool DeleteContact(string id);

        /// <summary>
        /// Gets contact id and password, and tries to login.
        /// </summary>
        /// <param name="connectionJSON">Login info (id + password)</param>
        /// <returns>All friends for success, error 204 OW.</returns>
        public IEnumerable<Contact> Login(string connectionJSON);
        /// <summary>
        /// Gets contact id and password, and tries to login.
        /// </summary>
        /// <param name="username">Contact id (id + password)</param>
        /// <param name="password">password</param>
        /// <returns>All friends for success, error 204 OW.</returns>
        public bool CanLogin(string username, string password);

        /// <summary>
        /// Checks that dataset is initialized.
        /// </summary>
        /// <returns>True if inited. False OW.</returns>
        public bool IsInitialized();
        /// <summary>
        /// Checks if contact exists
        /// </summary>
        /// <returns>True if exists.</returns>
        public bool ContactExists(string id);
        
    }
}
