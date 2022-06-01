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
using Microsoft.AspNetCore.Authentication;
using System.IdentityModel.Tokens.Jwt;

#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8603 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Dereference of a possibly null reference.

namespace chat_app_web_api.Controllers
{
    [ApiController]
    [Route("api")]
    public class Contacts_ChatsController : Controller
    {
        private string GetConnectedContactId()
        {
            var token = this.HttpContext.GetTokenAsync("access_token");
            if (token == null)
                return null;
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token.Result);
            return User.Claims.FirstOrDefault
                (c => c.Type.Equals("UserId", StringComparison.OrdinalIgnoreCase)).Value;
        }

        public IContact_ChatService _service;
        public IConfiguration _configuration;

        public Contacts_ChatsController(chat_app_web_apiContext context, IConfiguration config)
        {
            _service = new WebApiDatabaseContact_ChatService(context);
            _configuration = config;
        }

        [HttpGet]
        [Route("contacts")]
        public IActionResult GetContacts()
        {
            var result = _service.GetContacts(this.GetConnectedContactId());
            if (result == null)
                return NotFound();
            return Ok(result);
        }
    }
}
