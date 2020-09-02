using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ParentContactWeb.Models;
using Microsoft.EntityFrameworkCore;
using ParentContactWeb.models;
using ParentContactWeb.ViewModels;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.AspNetCore.Authorization;

namespace ParentContactWeb.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {  
        private readonly ILogger<HomeController> _logger;
        private readonly parentcontactdbContext _context;
       

        public HomeController(parentcontactdbContext context)
        {
            _context = context;
        }

        // GET: Students
        [AllowAnonymous]
        public     IActionResult Index()
        {

            var  temp = _context.Contacts.OrderByDescending(c => c.ContactDate)
                    .Select(c => new ContactTopTenViewModel
                     {
                        FirstName = c.Parent.FirstName,
                        LastName = c.Parent.FamilyName,
                        ContactReason = c.ContactReason,
                        ContactDate = c.ContactDate,
                        ContactID = c.ContactId,
                        FollowupNeeded = (bool)c.FollowUpNeeded

                    })
                    .Take(10)
                                        ;
            
           // ViewBag.ContactTopTen = temp;
            return View(temp);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}