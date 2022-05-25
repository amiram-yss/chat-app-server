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

        private string Avg
        {
            get
            {
                const int avgTextLen = 4;
                int Total = 0;
                int Counter = 0;
                foreach (var i in _context.Rating)
                {
                    Total++;
                    Counter += i.Grade;
                }
                if (Counter == 0)
                    return "No data available yet ;-}";
                double avg = (double)Counter / Total;
                string str = avg.ToString();
                if(str.Length >= avgTextLen)
                    str = str.Substring(0, avgTextLen);
                return "Average: " + str;
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

        //OK!
        // GET: Ratings
        public async Task<IActionResult> Index()
        {
            ViewData["avg"] = Avg;
            if(!_service.AllSetup())
                Problem("Entity set 'chat_app_serverContext.Rating'  is null.");
            return View(await _service.GetAllAsync());
        }

        public async Task<IActionResult> Search()
        {
            ViewData["avg"] = Avg;
            if (!_service.AllSetup())
                Problem("Entity set 'chat_app_serverContext.Rating'  is null.");
            return View(await _service.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Search(string query)
        {
            ViewData["avg"] = Avg;
            var filter = await _service.QueryAsync(query);
            if (filter == null)
                Problem("Entity set 'chat_app_serverContext.Rating'  is null.");
            return View(filter);
        }

        public async Task<IActionResult> SearchPartialView(string query)
        {
            if (query == null)
                query = "";
            ViewData["avg"] = Avg;
            var filter = await _service.QueryAsync(query);
            if (filter == null)
                filter = new List<Rating>();
          /*  if (filter == null)
                Problem("Entity set 'chat_app_serverContext.Rating'  is null.");*/
            return PartialView(filter);
        }

        //OK!
        // GET: Ratings/Details/5
        public async Task<IActionResult> Details(string id)
        {
            var rating = await _service.GetAsync(id);
            if(rating == null)
                return NotFound();
            return View(rating);
        }

        //OK! not edited
        // GET: Ratings/Create
        public IActionResult Create()
        {
            return View();
        }

        // OK!
        // POST: Ratings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Grade,Comment,Date")] Rating rating)
        {
            if (ModelState.IsValid)
            {
                /*_context.Add(rating);
                await _context.SaveChangesAsync();*/
                await _service.CreateAsync(rating);
                return RedirectToAction(nameof(Index));
            }
            return View(rating);
        }

        // OK!
        // GET: Ratings/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            /*if (id == null || _context.Rating == null)
            {
                return NotFound();
            }*/
/*  newer deletion          if (!_service.AllSetup(id))
                return NotFound();
*/
            var rating = await _service.GetAsync(id);//_context.Rating.FindAsync(id);
            if (rating == null)
                return NotFound();
            //_tmpDate = rating.Date;
            return View(rating);
        }

        // Maybe could use some adjustment...
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
                    /*if (_tmpDate != null)
                    {
                        rating.Date = _tmpDate ?? default(DateTime);
                        _tmpDate = null;
                    }*/
                    await _service.EditAsync(id, rating);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!(await _service.ExistsAsync(id)))
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

        // OK!
        // GET: Ratings/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            var rating = await _service.GetAsync(id); //_context.Rating.FirstOrDefaultAsync(m => m.Name == id);
            if (rating == null)
            {
                return NotFound();
            }
            return View(rating);
        }

        // OK!
        // POST: Ratings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            /*if (!_service.AllSetup())
            {
                return Problem("Entity set 'chat_app_serverContext.Rating'  is null.");
            }
            var rating = await _context.Rating.FindAsync(id);
            if (rating != null)
            {
                _context.Rating.Remove(rating);
            }

            await _context.SaveChangesAsync();*/
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
