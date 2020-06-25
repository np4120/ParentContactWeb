using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ParentContactWeb.Models;
using ParentContactWeb.models;

namespace ParentContactWeb.Controllers
{
    public class ContactMethodsController : Controller
    {
        private readonly parentcontactdbContext _context;

        public ContactMethodsController(parentcontactdbContext context)
        {
            _context = context;
        }

        // GET: ContactMethods
        public async Task<IActionResult> Index()
        {
            return View(await _context.ContactMethods.ToListAsync());
        }

        // GET: ContactMethods/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactMethod = await _context.ContactMethods
                .FirstOrDefaultAsync(m => m.CmID == id);
            if (contactMethod == null)
            {
                return NotFound();
            }

            return View(contactMethod);
        }

        // GET: ContactMethods/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ContactMethods/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CmID,Method")] ContactMethod contactMethod)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contactMethod);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contactMethod);
        }

        // GET: ContactMethods/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactMethod = await _context.ContactMethods.FindAsync(id);
            if (contactMethod == null)
            {
                return NotFound();
            }
            return View(contactMethod);
        }

        // POST: ContactMethods/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CmID,Method")] ContactMethod contactMethod)
        {
            if (id != contactMethod.CmID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contactMethod);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactMethodExists(contactMethod.CmID))
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
            return View(contactMethod);
        }

        // GET: ContactMethods/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactMethod = await _context.ContactMethods
                .FirstOrDefaultAsync(m => m.CmID == id);
            if (contactMethod == null)
            {
                return NotFound();
            }

            return View(contactMethod);
        }

        // POST: ContactMethods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contactMethod = await _context.ContactMethods.FindAsync(id);
            _context.ContactMethods.Remove(contactMethod);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactMethodExists(int id)
        {
            return _context.ContactMethods.Any(e => e.CmID == id);
        }
    }
}
