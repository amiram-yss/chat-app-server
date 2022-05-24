using chat_app_server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using chat_app_server.Data;

#pragma warning disable CS8603 // Possible null reference return.
#pragma warning disable CS8604 // Possible null reference return.
#pragma warning disable IDE0044 // Add readonly modifier

namespace chat_app_server.Service
{
    public class SqlServerLocalDatasetRatingService : IRatingService
    {
        chat_app_serverContext _context;
        //OK
        public SqlServerLocalDatasetRatingService(chat_app_serverContext context)
        {
            this._context = context;
        }
        public void Create(Rating rating)
        {
            throw new NotImplementedException();
        }

        public Task CreateAsync(Rating rating)
        {
            throw new NotImplementedException();
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public void DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public void Edit(string id, Rating rating)
        {
            throw new NotImplementedException();
        }

        public Task EditAsync(string id, Rating rating)
        {
            throw new NotImplementedException();
        }

        public Rating Get(string id)
        {
            throw new NotImplementedException();
        }
        //OK
        public ICollection<Rating> GetAll()
        {
            return _context.Rating.ToList<Rating>();
        }
        //OK
        public async Task<IEnumerable<Rating>> GetAllAsync()
        {
            return await _context.Rating.ToListAsync<Rating>();
        }

        public Task<Rating> GetAsync(string id)
        {
            throw new NotImplementedException();
        }

        public double GetAverge()
        {
            throw new NotImplementedException();
        }

        public bool AllSetup()
        {
            return (_context != null) && (_context.Rating != null);
        }
    }
}
