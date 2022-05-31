using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using chat_app_web_api;
using chat_app_web_api.Data;

namespace chat_app_web_api.Controllers
{
    public class ChatsController : Controller
    {
        private readonly chat_app_web_apiContext _context;

        public ChatsController(chat_app_web_apiContext context)
        {
            _context = context;
        }

        
        private bool ChatExists(int id)
        {
          return (_context.Chat?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
