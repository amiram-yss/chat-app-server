using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ChatAppWebApi;
using chat_app_web_api.Data;

namespace chat_app_web_api.Controllers
{
    public class MessagesController : ControllerBase
    {
        private readonly chat_app_web_apiContext _context;

        public MessagesController(chat_app_web_apiContext context)
        {
            _context = context;
        }

        
        private bool MessageExists(int id)
        {
          return (_context.Message?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
