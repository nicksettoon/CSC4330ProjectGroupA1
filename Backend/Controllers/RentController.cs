using System;
using System.Linq;
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
            private DowlingContext _context;

            public RentController(DowlingContext context)
            {
                _context = context;
            }

            private const double DamagedBikePriceAddition = 200.0;
            private const double DifferentDockPriceAddition = 25.0;

            public IActionResult Index()
            {
                return View();
            }

            public IActionResult Rent(RentModel data)
            {
                data.CheckOut = DateTime.Now;

                var userEmail = User.Identity.Name;

                var rental = from a in _context.Rentals
                                where a.BikeNumber.Equals(data.BikeNumber) && a.CheckInTime.Equals(new DateTime())
                                select a;

                var bike = (from a in _context.Bikes
                            where a.Id.Equals(data.BikeNumber)
                            select a).First();



                if (!rental.Any() && bike != null)
                {
                    var bikeDock = bike.DockId;
                    _context.Rentals.Add(new Rental() { CheckOutTime = data.CheckOut, BikeNumber = data.BikeNumber, RenterEmail = userEmail, RentDock = bikeDock });
                    data.AlreadyCheckedOut = false;
                }
                else
                {
                    data.AlreadyCheckedOut = true;
                    data.RentSuccessful = false;
                }
                
                _context.SaveChanges();

                return View("Index", data);
            }

            public IActionResult Return(RentModel data)
            {
                data.CheckIn = DateTime.Now;

                /*ClaimsPrincipal currentUser = this.User;
                var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;*/

                var userEmail = User.Identity.Name;

                var rental = from a in _context.Rentals
                                where a.BikeNumber.Equals(data.BikeNumber) && a.CheckInTime.Equals(new DateTime()) && a.RenterEmail.Equals(userEmail)
                                select a;

                if (rental.Any())
                {
                    // Check In Handling
                    var entry = _context.Entry(rental.First());
                    entry.Property(u => u.CheckInTime).CurrentValue = data.CheckIn;

                    // Price Handling
                    var price = RoundHours((entry.Property(u => u.CheckInTime).CurrentValue - entry.Property(u => u.CheckOutTime).CurrentValue).TotalHours) * 9;
                    

                    // Add charge if Bike is Damaged
                    if (data.BikeDamaged)
                    {
                        price += DamagedBikePriceAddition;
                        Console.WriteLine("Bike was damaged");
                    }

                    // Add charge if bike is returned at different dock
                    if (data.ReturnDock != entry.Property(u => u.RentDock).CurrentValue)
                    {
                        price += DifferentDockPriceAddition;
                        Console.WriteLine("Returned at different Dock");
                    }

                    entry.Property(u => u.Price).CurrentValue = price;
                    data.Price = price;

                    // Damaged Bike Handling
                    entry.Property(u => u.IsBikeDamaged).CurrentValue = data.BikeDamaged;

                    _context.SaveChanges();
                }
                else
                {
                    data.ReturnSuccessful = false;
                    Console.WriteLine("Return Failed");
                }

                return View("Index", data);
            }

            private static double RoundHours(double hours)
            {
                var roundedHours = Math.Round(hours);

                if (roundedHours < hours)
                {
                    roundedHours++;
                }

                return roundedHours;
            }
        }
    }
}
