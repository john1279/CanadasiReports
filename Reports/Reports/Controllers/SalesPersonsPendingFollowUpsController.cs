using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Reports.Data;
using Reports.Models;

namespace Reports.Controllers
{
    public class SalesPersonsPendingFollowUpsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SalesPersonsPendingFollowUpsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SalesPersonsPendingFollowUps
        public async Task<IActionResult> Index()
        {
            return View(await _context.SalesPersonsPendingFollowUps.ToListAsync());
        }

        // GET: SalesPersonsPendingFollowUps/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesPersonsPendingFollowUps = await _context.SalesPersonsPendingFollowUps
                .FirstOrDefaultAsync(m => m.Id == id);
            if (salesPersonsPendingFollowUps == null)
            {
                return NotFound();
            }

            return View(salesPersonsPendingFollowUps);
        }

        // GET: SalesPersonsPendingFollowUps/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SalesPersonsPendingFollowUps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] SalesPersonsPendingFollowUps salesPersonsPendingFollowUps)
        {
            if (ModelState.IsValid)
            {
                salesPersonsPendingFollowUps.Id = Guid.NewGuid();
                _context.Add(salesPersonsPendingFollowUps);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(salesPersonsPendingFollowUps);
        }

        // GET: SalesPersonsPendingFollowUps/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesPersonsPendingFollowUps = await _context.SalesPersonsPendingFollowUps.FindAsync(id);
            if (salesPersonsPendingFollowUps == null)
            {
                return NotFound();
            }
            return View(salesPersonsPendingFollowUps);
        }

        // POST: SalesPersonsPendingFollowUps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id")] SalesPersonsPendingFollowUps salesPersonsPendingFollowUps)
        {
            if (id != salesPersonsPendingFollowUps.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salesPersonsPendingFollowUps);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalesPersonsPendingFollowUpsExists(salesPersonsPendingFollowUps.Id))
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
            return View(salesPersonsPendingFollowUps);
        }

        // GET: SalesPersonsPendingFollowUps/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesPersonsPendingFollowUps = await _context.SalesPersonsPendingFollowUps
                .FirstOrDefaultAsync(m => m.Id == id);
            if (salesPersonsPendingFollowUps == null)
            {
                return NotFound();
            }

            return View(salesPersonsPendingFollowUps);
        }

        // POST: SalesPersonsPendingFollowUps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var salesPersonsPendingFollowUps = await _context.SalesPersonsPendingFollowUps.FindAsync(id);
            _context.SalesPersonsPendingFollowUps.Remove(salesPersonsPendingFollowUps);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalesPersonsPendingFollowUpsExists(Guid id)
        {
            return _context.SalesPersonsPendingFollowUps.Any(e => e.Id == id);
        }
    }
}
