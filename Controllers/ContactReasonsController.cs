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
    public class ContactReasonsController : Controller
    {
        private readonly parentcontactdbContext _context;

        public ContactReasonsController(parentcontactdbContext context)
        {
            _context = context;
        }

        // GET: ContactReasons
        public async Task<IActionResult> Index()
        {
            return View(await _context.ContactReasons.ToListAsync());
        }

        // GET: ContactReasons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactReason = await _context.ContactReasons
                .FirstOrDefaultAsync(m => m.CrID == id);
            if (contactReason == null)
            {
                return NotFound();
            }

            return View(contactReason);
        }

        // GET: ContactReasons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ContactReasons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CrID,Reason")] ContactReason contactReason)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contactReason);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contactReason);
        }

        // GET: ContactReasons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactReason = await _context.ContactReasons.FindAsync(id);
            if (contactReason == null)
            {
                return NotFound();
            }
            return View(contactReason);
        }

        // POST: ContactReasons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CrID,Reason")] ContactReason contactReason)
        {
            if (id != contactReason.CrID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contactReason);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactReasonExists(contactReason.CrID))
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
            return View(contactReason);
        }

        // GET: ContactReasons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactReason = await _context.ContactReasons
                .FirstOrDefaultAsync(m => m.CrID == id);
            if (contactReason == null)
            {
                return NotFound();
            }

            return View(contactReason);
        }

        // POST: ContactReasons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contactReason = await _context.ContactReasons.FindAsync(id);
            _context.ContactReasons.Remove(contactReason);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactReasonExists(int id)
        {
            return _context.ContactReasons.Any(e => e.CrID == id);
        }
    }
}
