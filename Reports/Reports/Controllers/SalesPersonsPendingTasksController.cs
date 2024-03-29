﻿using System;
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
    public class SalesPersonsPendingTasksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SalesPersonsPendingTasksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SalesPersonsPendingTasks
        public async Task<IActionResult> Index()
        {
            return View(await _context.SalesPersonsPendingTasks.ToListAsync());
        }

        // GET: SalesPersonsPendingTasks/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesPersonsPendingTasks = await _context.SalesPersonsPendingTasks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (salesPersonsPendingTasks == null)
            {
                return NotFound();
            }

            return View(salesPersonsPendingTasks);
        }

        // GET: SalesPersonsPendingTasks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SalesPersonsPendingTasks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] SalesPersonsPendingTasks salesPersonsPendingTasks)
        {
            if (ModelState.IsValid)
            {
                salesPersonsPendingTasks.Id = Guid.NewGuid();
                _context.Add(salesPersonsPendingTasks);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(salesPersonsPendingTasks);
        }

        // GET: SalesPersonsPendingTasks/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesPersonsPendingTasks = await _context.SalesPersonsPendingTasks.FindAsync(id);
            if (salesPersonsPendingTasks == null)
            {
                return NotFound();
            }
            return View(salesPersonsPendingTasks);
        }

        // POST: SalesPersonsPendingTasks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id")] SalesPersonsPendingTasks salesPersonsPendingTasks)
        {
            if (id != salesPersonsPendingTasks.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salesPersonsPendingTasks);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalesPersonsPendingTasksExists(salesPersonsPendingTasks.Id))
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
            return View(salesPersonsPendingTasks);
        }

        // GET: SalesPersonsPendingTasks/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesPersonsPendingTasks = await _context.SalesPersonsPendingTasks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (salesPersonsPendingTasks == null)
            {
                return NotFound();
            }

            return View(salesPersonsPendingTasks);
        }

        // POST: SalesPersonsPendingTasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var salesPersonsPendingTasks = await _context.SalesPersonsPendingTasks.FindAsync(id);
            _context.SalesPersonsPendingTasks.Remove(salesPersonsPendingTasks);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalesPersonsPendingTasksExists(Guid id)
        {
            return _context.SalesPersonsPendingTasks.Any(e => e.Id == id);
        }
    }
}
