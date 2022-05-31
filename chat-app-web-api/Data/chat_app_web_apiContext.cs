using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using chat_app_web_api;
using ChatAppWebApi;

namespace chat_app_web_api.Data
{
    public class chat_app_web_apiContext : DbContext
    {
        public chat_app_web_apiContext (DbContextOptions<chat_app_web_apiContext> options)
            : base(options)
        {
        }

        public DbSet<chat_app_web_api.Chat>? Chat { get; set; }

        public DbSet<chat_app_web_api.Contact>? Contact { get; set; }

        public DbSet<chat_app_web_api.Contacts_Chats>? Contacts_Chats { get; set; }

        public DbSet<ChatAppWebApi.Message>? Message { get; set; }
    }
}
