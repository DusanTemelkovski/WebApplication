﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class TheatreShowsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TheatreShowsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TheatreShows
        public async Task<IActionResult> Index()
        {
            return View(await _context.TheatreShow.ToListAsync());
        }

        // GET: TheatreShows/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var theatreShow = await _context.TheatreShow
                .FirstOrDefaultAsync(show => show.Id == id);
            if (theatreShow == null)
            {
                return NotFound();
            }

            return View(theatreShow);
        }

        // GET: TheatreShows/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TheatreShows/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,Place,ShowDate,ImageUrl")] TheatreShow theatreShow)
        {
            if (ModelState.IsValid)
            {
                _context.Add(theatreShow);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(theatreShow);
        }

        // GET: TheatreShows/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var theatreShow = await _context.TheatreShow.FindAsync(id);
            if (theatreShow == null)
            {
                return NotFound();
            }
            return View(theatreShow);
        }

        // POST: TheatreShows/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Place,ShowDate,ImageUrl")] TheatreShow theatreShow)
        {
            if (id != theatreShow.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(theatreShow);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TheatreShowExists(theatreShow.Id))
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
            return View(theatreShow);
        }

        // GET: TheatreShows/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var theatreShow = await _context.TheatreShow
                .FirstOrDefaultAsync(m => m.Id == id);
            if (theatreShow == null)
            {
                return NotFound();
            }

            return View(theatreShow);
        }

        // POST: TheatreShows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var theatreShow = await _context.TheatreShow.FindAsync(id);
            if (theatreShow != null)
            {
                _context.TheatreShow.Remove(theatreShow);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TheatreShowExists(int id)
        {
            return _context.TheatreShow.Any(e => e.Id == id);
        }
    }
}
