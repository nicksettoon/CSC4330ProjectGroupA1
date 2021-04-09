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
using Backend.Entities;

namespace Backend.Controllers
{


    [Authorize]
    public class AdminController : Controller
    {
        private const double MissingBikeCharge = 500.0;

        private readonly ILogger<AdminController> _logger;

        public AdminController(ILogger<AdminController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewData["USER"] = User.Identity.Name;
            return View();
        }

        public IActionResult Report(string id)
        {
            var data = new AdminModel();

            var userEmail = User.Identity.Name;

            data.CurrentUserEmail = userEmail;
            if (id == "new")
            {
                using (var context = new DowlingContext())
                {
                    var monday = DateTime.Now.AddDays(-(int)DateTime.Now.DayOfWeek - 6);

                    var rentalQuery = from a in context.Rentals
                                        where a.CheckOutTime.CompareTo(monday) >= 0 && a.CheckOutTime.CompareTo(DateTime.Now.AddDays(1)) <= 0
                                        select a;
                    var rentals = rentalQuery.ToList();
                    data.Rentals = rentals;
                }
            }
            else
            {
                using (var context = new DowlingContext())
                {
                    var monday = DateTime.Now.AddDays(-(int)DateTime.Now.DayOfWeek - 6);

                    var rentalQuery = from a in context.Rentals
                                      where a.CheckOutTime.CompareTo(monday) <= 0
                                      select a;
                    var rentals = rentalQuery.ToList();
                    data.Rentals = rentals;
                }
            }
            

            return View("Report", data);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult MissingBike(string id)
        {
            var bikeNumber = Int32.Parse(id);
            using (var context = new DowlingContext())
            {
                var rentalQuery = from a in context.Rentals
                                  where a.BikeNumber.Equals(bikeNumber) && a.ReturnDock == 0
                                  select a;

                if (rentalQuery.Any())
                {
                    var entry = context.Entry(rentalQuery.First());

                    entry.Property(u => u.CheckInTime).CurrentValue = DateTime.Now;

                    entry.Property(u => u.Price).CurrentValue += MissingBikeCharge;

                    entry.Property(u => u.ReturnDock).CurrentValue = entry.Property(u => u.RentDock).CurrentValue;
                }

                context.SaveChanges();
            }
                return View("Index");
        }
    }
}
