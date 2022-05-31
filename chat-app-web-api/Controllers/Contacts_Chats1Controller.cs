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
    [ApiController]
    [Route("api")]
    public class Contacts_Chats1Controller : Controller
    {
        private readonly chat_app_web_apiContext _context;

        public Contacts_Chats1Controller(chat_app_web_apiContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("api/{id1}/{id2}")]
        public object MessagesBetween(string id1, string id2)
        {
            /*var chatIds = from chat in _context.Contacts_Chats
                         where chat.contact.id == id1 || chat.contact.id == id2
                         select chat;
            var chatId = from chat in chatIds
                         where*/
            var res = from connector in _context.Contacts_Chats
                      where connector.contact.id == id1 || connector.contact.id == id2
                      group connector by connector.chat.id into counter
                      where counter.Count() > 1
                      select new { id = counter.Key, count = counter.Count() };

            var jsonObj = new
            {
                users = new string[] {
                    
                }
            };

            return res;
        }
    }
}
