using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using chat_app_server.Data;
using chat_app_server.Models;
using chat_app_server.Service;

namespace chat_app_server.Controllers
{
    public class RatingsController : Controller
    {
        private readonly chat_app_serverContext _context;
        private IRatingService _service;
        public RatingsController(chat_app_serverContext context)
        {
            _context = context;
            _service = new SqlServerLocalDatasetRatingService(_context);
        }

        private double Avg
        {
            get
            {
                int Total = 0;
                int Counter = 0;
                foreach (var i in _context.Rating)
                {
                    Total++;
                    Counter += i.Grade;
                }
                if (Counter == 0)
                    return 0;
                double avg = (double)Counter / Total;
                return avg;
            }
        }
        private static DateTime? _tmpDate = null;

        public bool IsNameAvailable([Bind("Name,Grade,Comment")] Rating rating)
        {
            if (_context.Rating == null)
                return true;
            try
            {
                var result = _context.Rating.Single(r => r.Name == rating.Name);
                return false;
            }
            catch
            {
                return true;
            }
        }

        // GET: Ratings
        public async Task<IActionResult> Index()
        {
            ViewData["avg"] = Avg;
            if(!_service.AllSetup())
                Problem("Entity set 'chat_app_serverContext.Rating'  is null.");
            return View(await _service.GetAllAsync());
        }

        // GET: Ratings/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Rating == null)
            {
                return NotFound();
            }

            var rating = await _context.Rating
                .FirstOrDefaultAsync(m => m.Name == id);
            if (rating == null)
            {
                return NotFound();
            }

            return View(rating);
        }

        // GET: Ratings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ratings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Grade,Comment,Date")] Rating rating)
        {
            rating.Date = DateTime.Now;
            if (ModelState.IsValid)
            {
                _context.Add(rating);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rating);
        }

        // GET: Ratings/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Rating == null)
            {
                return NotFound();
            }

            var rating = await _context.Rating.FindAsync(id);
            if (rating == null)
            {
                return NotFound();
            }
            _tmpDate = rating.Date;
            return View(rating);
        }

        // POST: Ratings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Name,Grade,Comment")] Rating rating)
        {
            if (id != rating.Name)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (_tmpDate != null)
                    {
                        rating.Date = _tmpDate ?? default(DateTime);
                        _tmpDate = null;
                    }
                    _context.Update(rating);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RatingExists(rating.Name))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(rating);
        }

        // GET: Ratings/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Rating == null)
            {
                return NotFound();
            }

            var rating = await _context.Rating
                .FirstOrDefaultAsync(m => m.Name == id);
            if (rating == null)
            {
                return NotFound();
            }

            return View(rating);
        }

        // POST: Ratings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Rating == null)
            {
                return Problem("Entity set 'chat_app_serverContext.Rating'  is null.");
            }
            var rating = await _context.Rating.FindAsync(id);
            if (rating != null)
            {
                _context.Rating.Remove(rating);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RatingExists(string id)
        {
            return (_context.Rating?.Any(e => e.Name == id)).GetValueOrDefault();
        }
    }
}
