using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using chat_app_web_api;
using chat_app_web_api.Data;
using chat_app_web_api.Service;

namespace chat_app_web_api.Controllers
{
    [ApiController]
    [Route("api")]
    public class ContactsController : Controller
    {
        //private readonly chat_app_web_apiContext _context;
        private readonly WebApiDatabaseContactService _service;

        public ContactsController(chat_app_web_apiContext context)
        {
            _service = new WebApiDatabaseContactService(context);
        }

        [HttpGet]
        [Route("contacts")]
        public IEnumerable<Contact> Get()
        {
            return _service.GetAll();
        }
        [HttpGet]
        [Route("contacts/{id}")]
        public Contact? Get(string id)
        {
            return _service.GetById(id);
        }
        private bool ContactExists(string id)
        {
            return _service.ContactExists(id);
        }
    }
}
