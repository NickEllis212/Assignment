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

namespace Assignment.Views.TechnicalIssues
{
    [Authorize(Roles = "ITManager")]
    public class TechnicalIssuesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TechnicalIssuesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TechnicalIssues
        public async Task<IActionResult> Index()
        {
            return View(await _context.TechnicalIssue.ToListAsync());
        }

        // GET: TechnicalIssues/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var technicalIssueModel = await _context.TechnicalIssue
                .FirstOrDefaultAsync(m => m.ID == id);
            if (technicalIssueModel == null)
            {
                return NotFound();
            }

            return View(technicalIssueModel);
        }

        // GET: TechnicalIssues/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TechnicalIssues/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,IssueName,IssueDetails,StaffName,Assetseffected,Date")] TechnicalIssueModel technicalIssueModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(technicalIssueModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(technicalIssueModel);
        }

        // GET: TechnicalIssues/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var technicalIssueModel = await _context.TechnicalIssue.FindAsync(id);
            if (technicalIssueModel == null)
            {
                return NotFound();
            }
            return View(technicalIssueModel);
        }

        // POST: TechnicalIssues/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,IssueName,IssueDetails,StaffName,Assetseffected,Date")] TechnicalIssueModel technicalIssueModel)
        {
            if (id != technicalIssueModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(technicalIssueModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TechnicalIssueModelExists(technicalIssueModel.ID))
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
            return View(technicalIssueModel);
        }

        // GET: TechnicalIssues/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var technicalIssueModel = await _context.TechnicalIssue
                .FirstOrDefaultAsync(m => m.ID == id);
            if (technicalIssueModel == null)
            {
                return NotFound();
            }

            return View(technicalIssueModel);
        }

        // POST: TechnicalIssues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var technicalIssueModel = await _context.TechnicalIssue.FindAsync(id);
            _context.TechnicalIssue.Remove(technicalIssueModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TechnicalIssueModelExists(int id)
        {
            return _context.TechnicalIssue.Any(e => e.ID == id);
        }
    }
}
