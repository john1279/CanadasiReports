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
    public class ContractsSentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContractsSentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ContractsSents
        public async Task<IActionResult> Index()
        {
            return View(await _context.ContractsSent.ToListAsync());
        }

        // GET: ContractsSents/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contractsSent = await _context.ContractsSent
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contractsSent == null)
            {
                return NotFound();
            }

            return View(contractsSent);
        }

        // GET: ContractsSents/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ContractsSents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] ContractsSent contractsSent)
        {
            if (ModelState.IsValid)
            {
                contractsSent.Id = Guid.NewGuid();
                _context.Add(contractsSent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contractsSent);
        }

        // GET: ContractsSents/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contractsSent = await _context.ContractsSent.FindAsync(id);
            if (contractsSent == null)
            {
                return NotFound();
            }
            return View(contractsSent);
        }

        // POST: ContractsSents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id")] ContractsSent contractsSent)
        {
            if (id != contractsSent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contractsSent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContractsSentExists(contractsSent.Id))
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
            return View(contractsSent);
        }

        // GET: ContractsSents/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contractsSent = await _context.ContractsSent
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contractsSent == null)
            {
                return NotFound();
            }

            return View(contractsSent);
        }

        // POST: ContractsSents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var contractsSent = await _context.ContractsSent.FindAsync(id);
            _context.ContractsSent.Remove(contractsSent);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContractsSentExists(Guid id)
        {
            return _context.ContractsSent.Any(e => e.Id == id);
        }
    }
}
