using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ParentContactWeb.models;

namespace ParentContactWeb
{
    public class ParentsController : Controller
    {
        private readonly parentcontactdbContext _context;

        public ParentsController(parentcontactdbContext context)
        {
            _context = context;
        }

        // GET: ParentsController2
        public async Task<IActionResult> Index(
             string searchTerm,
            int? pageNumber
            )
        {
            if (searchTerm != null)
            {
                pageNumber = 1;
            }

            var parents = from p in _context.Parents.Include(p => p.Student)
                          select p;
            parents = parents.OrderBy(p => p.FamilyName);

            if (!String.IsNullOrEmpty(searchTerm))

                
            {

                TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
                searchTerm = textInfo.ToTitleCase(searchTerm);
                parents = parents.Where(p => p.FamilyName.Contains(searchTerm));
            }

            int pageSize = 10;

            return View(await PaginatedList<Parent>.CreateAsync(parents.AsNoTracking(), pageNumber ?? 1, pageSize));

        }

        // GET: ParentsController2/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parent = await _context.Parents
                .Include(p => p.Student)
                .FirstOrDefaultAsync(m => m.ParentId == id);

            var contact = await _context.Contacts
              .Where(c => c.ParentId == parent.ParentId)
              .OrderByDescending(c => c.ContactDate)
              .ToListAsync();

            ViewData["Contacts"] = contact;

            if (parent == null)
                           {
                return NotFound();
            }

            return View(parent);
        }

        // GET: ParentsController2/Create
        public IActionResult Create()
        {
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "FirstName");
            return View();
        }

        // POST: ParentsController2/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ParentId,StudentId,FamilyName,FirstName,CellNo,Email")] Parent parent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(parent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "FirstName", parent.StudentId);
            return View(parent);
        }

        // GET: ParentsController2/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parent = await _context.Parents
                .Include(p => p.Contacts)
                .FirstOrDefaultAsync(n => n.ParentId == id);



            if (parent == null)
            {
                return NotFound();
            }
            var student = await _context.Students
               .FirstOrDefaultAsync(s => s.StudentId == parent.StudentId);

            ViewData["Student"] = student;
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "FirstName", parent.StudentId);
            return View(parent);
        }

        // POST: ParentsController2/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ParentId,StudentId,FamilyName,FirstName,CellNo,Email")] Parent parent)
        {
            if (id != parent.ParentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(parent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParentExists(parent.ParentId))
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

            parent = await _context.Parents
               .FirstOrDefaultAsync(n => n.ParentId == id);

            var student = await _context.Students
                .FirstOrDefaultAsync(s => s.StudentId == parent.StudentId);

            ViewData["Student"] = student;
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "FirstName", parent.StudentId);
            return View(parent);
        }

        // GET: ParentsController2/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parent = await _context.Parents
                .Include(p => p.Student)
                .FirstOrDefaultAsync(m => m.ParentId == id);
            if (parent == null)
            {
                return NotFound();
            }

            return View(parent);
        }

        // POST: ParentsController2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var parent = await _context.Parents.FindAsync(id);
            _context.Parents.Remove(parent);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParentExists(int id)
        {
            return _context.Parents.Any(e => e.ParentId == id);
        }
    }
}
