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
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8603 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Dereference of a possibly null reference.

namespace chat_app_web_api.Controllers
{
    [ApiController]
    [Route("api")]
    public class ContactsController : ControllerBase
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
        //private readonly chat_app_web_apiContext _context;
        private readonly WebApiDatabaseContactService _service;
        public IConfiguration _configuration;

        public ContactsController(chat_app_web_apiContext context, IConfiguration config)
        {
            _configuration = config;
            _service = new WebApiDatabaseContactService(context, config);
        }

        [HttpGet]
        [Route("allContacts")]
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
        [HttpDelete]
        [Route("contacts/{id}")]
        public IActionResult DeleteContact(string id)
        {
            if (!_service.DeleteContact(id))
                return BadRequest();
            return StatusCode(204);
        }
        [HttpPut]
        [Route("contacts/{id}")]
        public IActionResult UpdateOrCreateContact(string id, string name, string address, string password)
        {
            if (_service.ContactExists(id))
            {
                if(_service.UpdateContact(Get(id), name, address, password))
                    return StatusCode(204);
                return BadRequest();
            }
            if (_service.CreateContact(id, name, address, password))
                return Created("","");
            return BadRequest();
        }
        private bool ContactExists(string id)
        {
            return _service.ContactExists(id);
        }
        [HttpPost]
        [Route("Login")]
        public IActionResult Login(string username, string password)
        {
            if (!_service.CanLogin(username, password))
                return BadRequest("User or password is incorrect.");

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, _configuration["JwtParams:Subject"]),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString()),
                new Claim("UserId", username)
            };
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWTParams:SecretKey"]));
            var mac = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _configuration["JWTParams:Issuer"],
                _configuration["JWTParams:Audience"],
                claims,
                expires: DateTime.UtcNow.AddMinutes(5),
                signingCredentials: mac
                );
            return Ok(new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}
