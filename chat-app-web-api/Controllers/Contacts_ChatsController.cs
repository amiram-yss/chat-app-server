using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using chat_app_web_api;
using chat_app_web_api.Data;
using Microsoft.AspNetCore.Authorization;
using chat_app_web_api.Service;

namespace chat_app_web_api.Controllers
{
    [ApiController]
    [Route("api")]
    public class Contacts_ChatsController : Controller
    {

        public IContact_ChatService _service;
        public IConfiguration _configuration;

        public Contacts_ChatsController(chat_app_web_apiContext context, IConfiguration config)
        {
            _service = new WebApiDatabaseContact_ChatService(context);
            _configuration = config;
        }

        [HttpGet]
        [Route("contact")]
        public IActionResult GetContacts()
        {
            var shit = _configuration.GetValue("UserId", "");
            _service.GetContacts(shit);
            return Ok();
        }
    }
}
