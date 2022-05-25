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
            rating.Date = DateTime.Now;
            _context.Add(rating);
            await _context.SaveChangesAsync();
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(string id)
        {
            if (!AllSetup())
                return;
            var rating = await GetAsync(id);
            if (rating != null)
            {
                _context.Rating.Remove(rating);
            }
            await _context.SaveChangesAsync();
        }

        public void Edit(string id, Rating newInfoRating)
        {
            if (newInfoRating == null)
                return;
            /*newInfoRating.Date = Get(id).Date;*/
            var oldRating = Get(id);
            oldRating.Comment = newInfoRating.Comment;
            oldRating.Grade = newInfoRating.Grade;
            _context.Update(oldRating);
            _context.SaveChanges();
        }

        public async Task EditAsync(string id, Rating newInfoRating)
        {
            if (newInfoRating == null)
                return;
            /*newInfoRating.Date = Get(id).Date;*/
            var oldRating = await GetAsync(id);
            oldRating.Comment = newInfoRating.Comment;
            oldRating.Grade = newInfoRating.Grade;
            _context.Update(oldRating);
            await _context.SaveChangesAsync();
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

        public bool Exists(string id)
        {
            if (AllSetup(id))
                return false;
            return _context.Rating.Any(m => m.Name == id);
        }

        public async Task<bool> ExistsAsync(string id)
        {
            if (AllSetup(id))
                return false;
            return await _context.Rating.AnyAsync(m => m.Name == id);
        }
    }
}
