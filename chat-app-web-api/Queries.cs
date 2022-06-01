using chat_app_web_api.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8603 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Dereference of a possibly null reference.

namespace chat_app_web_api
{
    public static class Queries
    {
        
        public static int GetMaxIdInChats(DbSet<Contacts_Chats> set)
        {
            var res = set.OrderByDescending(x => x.chat.id).FirstOrDefault();
            if (res == default(IOrderedEnumerable<Contacts_Chats>))
                return -1;
            return res.id;
        }

        public static int GetMaxIdInChatsContactConnector(DbSet<Contacts_Chats> set)
        {
            if (set.OrderByDescending(x => x.id).FirstOrDefault() == null)
                return -1;
            return set.OrderByDescending(x => x.id).FirstOrDefault().id;
        }

        /// <summary>
        /// Does contact have friend with the following:
        /// </summary>
        /// <param name="context">db context</param>
        /// <param name="connectedContact">connected</param>
        /// <param name="id">friend's id</param>
        /// <param name="name">name</param>
        /// <param name="server">server</param>
        /// <returns></returns>
        public static bool CanAddContact
            (chat_app_web_apiContext context, Contact connectedContact, string id, string name, string server)
        {
            var c = context.Contact.Where(x => x.id == id).FirstOrDefault();
            //Check exists in db and correct
            if (c == default || c == null)
                return false;
            if (c.server != server || c.name != name)
                return false;
            //In db. check if already friend.
            var friend = GetUserContacts(context, connectedContact).Where(x => x.id == id).FirstOrDefault();
            if (friend == default || friend == null)
                return true;
            return false;
        }
        public static Chat GetChatForTwoContacts(chat_app_web_apiContext context)
        {
            return null;
        }
        public static IEnumerable<Contact> GetUserContacts(chat_app_web_apiContext context, Contact contact)
        {
            var validChats = from record in context.Contacts_Chats
                             where record.contact.id == contact.id
                             select record.chat.id;
            var result = from record in context.Contacts_Chats
                         where validChats.Contains(record.chat.id)
                                 && record.contact.name != contact.name
                         select record.contact;
            return result;
        }
    }
}
