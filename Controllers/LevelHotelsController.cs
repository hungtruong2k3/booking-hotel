using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Booking_Hotel.Data;
using Booking_Hotel.Models;

namespace Booking_Hotel.Controllers
{
    public class LevelHotelsController : Controller
    {
        private readonly Booking_HotelContext _context;

        public LevelHotelsController(Booking_HotelContext context)
        {
            _context = context;
        }

        // GET: LevelHotels
        public async Task<IActionResult> Index()
        {
              return _context.LevelHotel != null ? 
                          View(await _context.LevelHotel.ToListAsync()) :
                          Problem("Entity set 'Booking_HotelContext.LevelHotel'  is null.");
        }

        // GET: LevelHotels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.LevelHotel == null)
            {
                return NotFound();
            }

            var levelHotel = await _context.LevelHotel
                .FirstOrDefaultAsync(m => m.LeverID == id);
            if (levelHotel == null)
            {
                return NotFound();
            }

            return View(levelHotel);
        }

        // GET: LevelHotels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LevelHotels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LeverID,LocalName")] LevelHotel levelHotel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(levelHotel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(levelHotel);
        }

        // GET: LevelHotels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.LevelHotel == null)
            {
                return NotFound();
            }

            var levelHotel = await _context.LevelHotel.FindAsync(id);
            if (levelHotel == null)
            {
                return NotFound();
            }
            return View(levelHotel);
        }

        // POST: LevelHotels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LeverID,LocalName")] LevelHotel levelHotel)
        {
            if (id != levelHotel.LeverID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(levelHotel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LevelHotelExists(levelHotel.LeverID))
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
            return View(levelHotel);
        }

        // GET: LevelHotels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.LevelHotel == null)
            {
                return NotFound();
            }

            var levelHotel = await _context.LevelHotel
                .FirstOrDefaultAsync(m => m.LeverID == id);
            if (levelHotel == null)
            {
                return NotFound();
            }

            return View(levelHotel);
        }

        // POST: LevelHotels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.LevelHotel == null)
            {
                return Problem("Entity set 'Booking_HotelContext.LevelHotel'  is null.");
            }
            var levelHotel = await _context.LevelHotel.FindAsync(id);
            if (levelHotel != null)
            {
                _context.LevelHotel.Remove(levelHotel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LevelHotelExists(int id)
        {
          return (_context.LevelHotel?.Any(e => e.LeverID == id)).GetValueOrDefault();
        }
    }
}
