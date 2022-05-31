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
    public class ContactsController : Controller
    {
        private readonly chat_app_web_apiContext _context;

        public ContactsController(chat_app_web_apiContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("contacts")]
        public IEnumerable<Contact> Get()
        {
            if (_context.Contact == null)
                return Enumerable.Empty<Contact>();
            return _context.Contact;
        }
        [HttpGet]
        [Route("contacts/{id}")]
        public Contact? Get(string id)
        {
            if (_context.Contact == null)
                return null;
            return _context.Contact.Find(id);
        }
        private bool ContactExists(string id)
        {
          return (_context.Contact?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
