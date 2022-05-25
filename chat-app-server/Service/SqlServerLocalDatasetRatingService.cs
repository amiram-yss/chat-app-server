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
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable IDE0044 // Add readonly modifier
#pragma warning disable CS8619 // Nullability of reference types in value doesn't match target type.

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
            rating.Date = DateTime.Now;
            _context.Add(rating);
            _context.SaveChanges();
        }

        public async Task CreateAsync(Rating rating)
        {
            _context.Add(rating);
            await _context.SaveChangesAsync();
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
            if (!AllSetup(id))
                return null;
            return _context.Rating.FirstOrDefault(m => m.Name == id);
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

        public async Task<Rating> GetAsync(string id)
        {
            if (!AllSetup(id))
                return null;
            return await _context.Rating.FirstOrDefaultAsync(m => m.Name == id);
        }

        public double GetAverge()
        {
            throw new NotImplementedException();
        }

        public bool AllSetup(string id = "")
        {
            if (id == null)
                return false;
            if (_context == null)
                return false;
            if (_context.Rating == null)
                return false;
            return true;
        }
    }
}
