using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Backend.Models;
using Backend.Context;
using Backend.Entities;
using Microsoft.AspNetCore.Authorization;

namespace DowlingBikes
{
    namespace Backend.Controllers
    {
        [Authorize]
        public class RentController : Controller
        {
            public IActionResult Index()
            {
                return View();
            }

            public IActionResult Submit(RentModel data)
            {
                data.CheckOut = System.DateTime.Now;

                using (var context = new DowlingContext())
                {
                    context.Rentals.Add(new Rental() { CheckOutTime = data.CheckOut, BikeNumber = data.BikeNumber, RenterEmail = "FatRat"});
                    context.SaveChanges();
                }

                return View("Index");
            }

            public IActionResult Return(RentModel data)
            {
                data.CheckIn = DateTime.Now;

                using (var context = new DowlingContext())
                {
                    var rental = from a in context.Rentals
                                 where a.BikeNumber.Equals(data.BikeNumber) && a.CheckInTime.Equals(new DateTime())
                                 select a;

                    context.Entry(rental.First()).Property(u => u.CheckInTime).CurrentValue = data.CheckIn;

                    context.SaveChanges();
                }

                return View("Index");
            }
        }
    }
}
