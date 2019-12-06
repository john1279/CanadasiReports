using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Reports.Data;
using Reports.Models;
using Reports.Services;

namespace Reports.Controllers
{
    public class TotalLeadsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ITotalLeadsService totalLeadsService;

        public TotalLeadsController(ApplicationDbContext context, ITotalLeadsService _totalLeadsService)
        {
            _context = context;
            totalLeadsService = _totalLeadsService;

        }

        // GET: TotalLeads
        public IActionResult Index()
        {
            //return View(await _context.TotalLeads.ToListAsync());

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(TotalLeads totalLeads)
        {
            //return View(await _context.TotalLeads.ToListAsync());
            //totalLeadsService.ObtenerLista();

            totalLeads.Date1 = DateTime.Now;
            totalLeads.Date2 = DateTime.Now;

            return View(totalLeads);
        }

        // GET: TotalLeads/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var totalLeads = await _context.TotalLeads
                .FirstOrDefaultAsync(m => m.Id == id);
            if (totalLeads == null)
            {
                return NotFound();
            }

            return View(totalLeads);
        }

        // GET: TotalLeads/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TotalLeads/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] TotalLeads totalLeads)
        {
            if (ModelState.IsValid)
            {
                totalLeads.Id = Guid.NewGuid();
                _context.Add(totalLeads);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(totalLeads);
        }

        // GET: TotalLeads/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var totalLeads = await _context.TotalLeads.FindAsync(id);
            if (totalLeads == null)
            {
                return NotFound();
            }
            return View(totalLeads);
        }

        // POST: TotalLeads/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id")] TotalLeads totalLeads)
        {
            if (id != totalLeads.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(totalLeads);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TotalLeadsExists(totalLeads.Id))
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
            return View(totalLeads);
        }

        // GET: TotalLeads/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var totalLeads = await _context.TotalLeads
                .FirstOrDefaultAsync(m => m.Id == id);
            if (totalLeads == null)
            {
                return NotFound();
            }

            return View(totalLeads);
        }

        // POST: TotalLeads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var totalLeads = await _context.TotalLeads.FindAsync(id);
            _context.TotalLeads.Remove(totalLeads);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TotalLeadsExists(Guid id)
        {
            return _context.TotalLeads.Any(e => e.Id == id);
        }
    }
}
