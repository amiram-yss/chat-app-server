using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using chat_app_server.Models;

namespace chat_app_server.Data
{
    public class chat_app_serverContext : DbContext
    {
        public chat_app_serverContext (DbContextOptions<chat_app_serverContext> options)
            : base(options)
        {
        }

        public DbSet<chat_app_server.Models.Rating>? Rating { get; set; }
    }
}
