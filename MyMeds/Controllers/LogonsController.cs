using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyMeds.Data;
using MyMeds.Models;

namespace MyMeds.Controllers
{
    public class LogonsController : Controller
    {
        private readonly MyMedsContext _context;

        public LogonsController(MyMedsContext context)
        {
            _context = context;
        }

        // GET: Logons
        public async Task<IActionResult> Index()
        {
            return View(await _context.Logons.ToListAsync());
        }

        // GET: Logons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var logon = await _context.Logons
                .FirstOrDefaultAsync(m => m.Id == id);
            if (logon == null)
            {
                return NotFound();
            }

            return View(logon);
        }

        // GET: Logons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Logons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,Password")] Logon logon)
        {
            Random random = new Random();
            logon.Id = random.Next(1, 10000);

            
            if (ModelState.IsValid)
            {
                _context.Add(logon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(logon);
        }

        // GET: Logons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var logon = await _context.Logons.FindAsync(id);
            if (logon == null)
            {
                return NotFound();
            }
            return View(logon);
        }

        // POST: Logons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,Password")] Logon logon)
        {
            if (id != logon.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(logon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LogonExists(logon.Id))
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
            return View(logon);
        }

        // GET: Logons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var logon = await _context.Logons
                .FirstOrDefaultAsync(m => m.Id == id);
            if (logon == null)
            {
                return NotFound();
            }

            return View(logon);
        }

        // POST: Logons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var logon = await _context.Logons.FindAsync(id);
            _context.Logons.Remove(logon);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LogonExists(int id)
        {
            return _context.Logons.Any(e => e.Id == id);
        }
    }
}
