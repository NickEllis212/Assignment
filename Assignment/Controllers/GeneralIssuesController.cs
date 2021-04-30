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

namespace Assignment.Views.GeneralIssues
{
    //[Authorize(Roles = "ITManager")]
   // [Authorize(Roles = "Teacher")]
    public class GeneralIssuesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GeneralIssuesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GeneralIssues
        public async Task<IActionResult> Index()
        {
            return View(await _context.GeneralIssues.ToListAsync());
        }

        // GET: GeneralIssues/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var generalIssuesModel = await _context.GeneralIssues
                .FirstOrDefaultAsync(m => m.ID == id);
            if (generalIssuesModel == null)
            {
                return NotFound();
            }

            return View(generalIssuesModel);
        }

        // GET: GeneralIssues/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GeneralIssues/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,IssueName,IssueDetails,StaffName,Date")] GeneralIssuesModel generalIssuesModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(generalIssuesModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(generalIssuesModel);
        }

        // GET: GeneralIssues/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var generalIssuesModel = await _context.GeneralIssues.FindAsync(id);
            if (generalIssuesModel == null)
            {
                return NotFound();
            }
            return View(generalIssuesModel);
        }

        // POST: GeneralIssues/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,IssueName,IssueDetails,StaffName,Date")] GeneralIssuesModel generalIssuesModel)
        {
            if (id != generalIssuesModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(generalIssuesModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GeneralIssuesModelExists(generalIssuesModel.ID))
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
            return View(generalIssuesModel);
        }

        // GET: GeneralIssues/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var generalIssuesModel = await _context.GeneralIssues
                .FirstOrDefaultAsync(m => m.ID == id);
            if (generalIssuesModel == null)
            {
                return NotFound();
            }

            return View(generalIssuesModel);
        }

        // POST: GeneralIssues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var generalIssuesModel = await _context.GeneralIssues.FindAsync(id);
            _context.GeneralIssues.Remove(generalIssuesModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GeneralIssuesModelExists(int id)
        {
            return _context.GeneralIssues.Any(e => e.ID == id);
        }
    }
}
