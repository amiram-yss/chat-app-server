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
using Microsoft.AspNetCore.Authentication;
using System.IdentityModel.Tokens.Jwt;
using chat_app_web_api.Service;

namespace chat_app_web_api.Controllers
{
    [Authorize]
    public class ChatsController : ControllerBase
    {
        private readonly chat_app_web_apiContext _context;
        private IMessagesService _service;

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

        public ChatsController(chat_app_web_apiContext context)
        {
            _context = context;
            _service = new WebApiDatabaseMessagesService(context);
        }

        [HttpGet]
        [Route("contacts/{id}/messages")]
        public IEnumerable<Message> GetMessagesWith(string id)
        {
            throw new NotImplementedException();
            //return _service.GetMessagesWith(GetConnectedContactId(), id);
        }
    }
}
