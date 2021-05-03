using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Assignment.Data;
using Assignment.Models;
using Microsoft.AspNetCore.Authorization;

namespace Assignment.Views.Manager
{
    [Area("ITManager")]
    [Authorize(Roles = "ITManager")]
    public class ManagerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ManagerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Manager
        public async Task<IActionResult> Index()
        {
            return View(await _context.ITmanagerModel.ToListAsync());
        }

        // GET: Manager/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iTmanagerModel = await _context.ITmanagerModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (iTmanagerModel == null)
            {
                return NotFound();
            }

            return View(iTmanagerModel);
        }

        // GET: Manager/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Manager/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email")] ITmanagerModel iTmanagerModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(iTmanagerModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(iTmanagerModel);
        }

        // GET: Manager/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iTmanagerModel = await _context.ITmanagerModel.FindAsync(id);
            if (iTmanagerModel == null)
            {
                return NotFound();
            }
            return View(iTmanagerModel);
        }

        // POST: Manager/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email")] ITmanagerModel iTmanagerModel)
        {
            if (id != iTmanagerModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(iTmanagerModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ITmanagerModelExists(iTmanagerModel.Id))
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
            return View(iTmanagerModel);
        }

        // GET: Manager/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iTmanagerModel = await _context.ITmanagerModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (iTmanagerModel == null)
            {
                return NotFound();
            }

            return View(iTmanagerModel);
        }

        // POST: Manager/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var iTmanagerModel = await _context.ITmanagerModel.FindAsync(id);
            _context.ITmanagerModel.Remove(iTmanagerModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ITmanagerModelExists(int id)
        {
            return _context.ITmanagerModel.Any(e => e.Id == id);
        }
    }
}
