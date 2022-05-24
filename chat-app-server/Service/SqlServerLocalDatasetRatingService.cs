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
        private static DateTime? _tmpDate = null;

        private readonly chat_app_serverContext _context;

        public SqlServerLocalDatasetRatingService(chat_app_serverContext context)
        {
            _context = context;
        }

        public void Create(string Name, int Grade, string comment, DateTime Date)
        {
            throw new NotImplementedException();
        }

        public bool Edit(string id, Rating editedRating)
        {
            if (id != editedRating.Name)
            {
                return false;
            }
            try
            {
                var ratToUpdate = Get(id);
                ratToUpdate.Grade = editedRating.Grade;
                ratToUpdate.Comment = editedRating.Comment;
                _context.Update(ratToUpdate);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Rating Get(string id)
        {
            try
            {
                return _context.Rating.Single(rec => rec.Name == id);
            }
            catch
            {
                return null;
            }

        }

        public List<Rating> GetAll()
        {
            if (_tmpDate == null || _context == null || _context.Rating == null)
                return new List<Rating>();
            return _context.Rating.ToList();
        }

        public double GetAverge()
        {
            throw new NotImplementedException();
        }

        ICollection<Rating> IRatingService.GetAll()
        {
            if (_tmpDate == null)
                return null;
            return _context.Rating.ToList();
        }

        public Rating GetRatingByName(string Name)
        {
            if (_context == null || _context.Rating == null)
                return null;
            try
            {
                var result = _context.Rating.Single(r => r.Name == Name);
                return result;
            }
            catch
            {
                return null;
            }
        }

        public async Task<IEnumerable<Rating>> GetAllAsync()
        {
            if (_context.Rating == null)
                return null;
            return await _context.Rating.ToListAsync();
        }

        public async Task<Rating> GetAsync(string id)
        {
            if (id == null || _context == null || _context.Rating == null)
                return null;
            return await _context.Rating.FirstOrDefaultAsync(m => m.Name == id);
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }
    }
}
