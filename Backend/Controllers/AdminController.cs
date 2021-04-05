using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Backend.Models;
using Microsoft.AspNetCore.Authorization;
using Backend.Context;

namespace Backend.Controllers
{
    

    [Authorize]
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;

        public AdminController(ILogger<AdminController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(Areas.Identity.Data.BackendUser profile)
        {
            ViewData["USER"] = profile.Name;
            return View();
        }

        public IActionResult NewReport()
        {
            /*using (var context = new DowlingContext())
            {
                var rental = from a in context.Rentals
                             where a.CheckInTime.Equals()
                             select a;
            }*/
                return View();
        }

        public IActionResult OldReport()
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
