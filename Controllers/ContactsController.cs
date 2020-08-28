using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ParentContactWeb.models;

namespace ParentContactWeb.Controllers
{
    public class ContactsController : Controller
    {
        private readonly parentcontactdbContext _context;

        public ContactsController(parentcontactdbContext context)
        {
            _context = context;
        }

        // GET: Contacts
        public async Task<IActionResult> Index(
             string searchTerm,
            int? pageNumber)

        {
            var contacts = from c in _context.Contacts.Include(c => c.Parent).Include(c => c.Student)
                           select c;
            contacts = contacts.OrderByDescending(c => c.ContactDate).ThenByDescending(c => c.Student.LastName);

            if (!String.IsNullOrEmpty(searchTerm))
            {
                contacts = contacts.Where(s => s.Student.LastName.Contains(searchTerm));
            }


            int pageSize = 10;

            return View(await PaginatedList<Contact>.CreateAsync(contacts.AsNoTracking(), pageNumber ?? 1, pageSize));

            
        }

        // GET: Contacts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = await _context.Contacts
                .Include(c => c.Parent)
                .Include(c => c.Student)
                .FirstOrDefaultAsync(m => m.ContactId == id);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        // GET: Contacts/Create
        public async Task<IActionResult>Create(int? id)
        {
            var parent = await _context.Parents
                .FirstOrDefaultAsync(p => p.ParentId == id);

            var familyname = parent.FamilyName;

            var student = await _context.Students
                .Where(s => s.LastName == familyname)
                .FirstOrDefaultAsync();


            var staffs = await _context.Staffs
                .ToListAsync();

            var contactmethod = await _context.ContactMethods
                .ToListAsync();
            


            var contactreason = await _context.ContactReasons
                .ToListAsync();

            

            ViewData["ContactMethod"] = new SelectList(contactmethod, "Method", "Method");
            ViewData["ContactReasons"] = new SelectList(contactreason, "Reason", "Reason");
            ViewData["AssignedTo"] = new SelectList(staffs, "FullName", "FullName");
            ViewData["Student"] = student;
            ViewData["Parent"] = parent;
            
            return View();
        }

        // POST: Contacts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContactId,StudentId,ParentId,ContactReason,TalkingPoints,ParentComments,FollowUpNeeded,ContactStatus,ContactMethod,ContactDate,AssignedTo")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            var parent = await _context.Parents
                .FirstOrDefaultAsync(p => p.ParentId == contact.ParentId);

            var familyname = parent.FamilyName;

            var student = await _context.Students
                .Where(s => s.LastName == familyname)
                .FirstOrDefaultAsync();
            var contactreasons = await _context.ContactReasons
               .ToListAsync();

            var contactmethods = await _context.ContactMethods
                .ToListAsync();
            ViewData["Student"] = student;
            ViewData["Parent"] = parent;
            ViewData["ContactMethod"] = new SelectList(contactmethods, "CmID", "Method");
            ViewData["ContactReasons"] = new SelectList(contactreasons, "CrID", "Reason");
            return View(contact);
        }

        // GET: Contacts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            // todo - include any notes associated with this contact 
            //  var contact = await _context.Contacts.FindAsync(id);

            var contact = await _context.Contacts
                .Include(c => c.Notes)
                .FirstOrDefaultAsync(n => n.ContactId == id);

            if (contact == null)
            {
                return NotFound();
            }

            //todo - this should not be a select list - this should be the parent full name and student's first name

            var parent = await _context.Parents
                .FirstOrDefaultAsync(p => p.ParentId == contact.ParentId);
            
            var student = await _context.Students
                .FirstOrDefaultAsync(s => s.StudentId == contact.StudentId);

            ViewData["Parent"] = parent;
            ViewData["Student"] = student;
            return View(contact);
        }

        // POST: Contacts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ContactId,StudentId,ParentId,ContactReason,TalkingPoints,ParentComments,FollowUpNeeded,ContactStatus,ContactMethod,ContactDate,AssignedTo")] Contact contact)
        {
            if (id != contact.ContactId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contact);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactExists(contact.ContactId))
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
            ViewData["ParentId"] = new SelectList(_context.Parents, "ParentId", "FamilyName", contact.ParentId);
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "FirstName", contact.StudentId);
            return View(contact);
        }

        // GET: Contacts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = await _context.Contacts
                .Include(c => c.Parent)
                .Include(c => c.Student)
                .FirstOrDefaultAsync(m => m.ContactId == id);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        // POST: Contacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactExists(int id)
        {
            return _context.Contacts.Any(e => e.ContactId == id);
        }
    }
}
