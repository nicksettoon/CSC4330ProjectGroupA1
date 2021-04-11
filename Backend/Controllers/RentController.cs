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

            private const double DamagedBikePriceAddition = 200.0;
            private const double DifferentDockPriceAddition = 25.0;

            public IActionResult Index()
            {
                var data = new RentModel()
                {
                    RentSuccessful = false,
                    ReturnSuccessful = false,
                    AlreadyCheckedOut = false

                };

                return View(data);
            }

            public IActionResult Rent()
            {
                var data = new RentModel()
                {
                    RentSuccessful = false,
                    ReturnSuccessful = false,
                    AlreadyCheckedOut = false

                };

                return View(data);
            }
            public IActionResult Return()
            {
                var data = new RentModel()
                {
                    RentSuccessful = false,
                    ReturnSuccessful = false,
                    AlreadyCheckedOut = false

                };

                TempData["Return"] = "true";

                return View(data);
            }

            public IActionResult RentFinished(RentModel data)
            {
                data.CheckOut = DateTime.Now;

                var userEmail = User.Identity.Name;

                using (var context = new DowlingContext())
                {
                    var rental = from a in context.Rentals
                                 where a.BikeNumber.Equals(data.BikeNumber) && a.CheckInTime.Equals(new DateTime())
                                 select a;

                    Bike bike = new Bike();
                    try
                    {
                        bike = (from a in context.Bikes
                                    where a.Id.Equals(data.BikeNumber)
                                    select a).First();
                    }
                    catch (Exception e)
                    {
                        Console.Error.WriteLine(e);
                        data.AlreadyCheckedOut = true;
                        data.RentSuccessful = false;
                        ViewData["Rent"] = "Invalid";
                        return View("Rent", data);
                    }

                    if (!rental.Any())
                    {
                        

                        var bikeDock = bike.DockId;
                        context.Rentals.Add(new Rental() { CheckOutTime = data.CheckOut, BikeNumber = data.BikeNumber, RenterEmail = userEmail, RentDock = bikeDock });
                        bike.Rented = true;
                        data.AlreadyCheckedOut = false;
                        context.SaveChanges();
                        TempData["Rent"] = "true";
                    }
                    else
                    {
                        data.AlreadyCheckedOut = true;
                        data.RentSuccessful = false;
                        ViewData["Rent"] = "false";
                        return View("Rent", data);
                    }
                    
                }

                return RedirectToAction("Index", "Home");
                //return View("../Home/Index", data);
            }

            public IActionResult Returnfinished(RentModel data)
            {
                data.CheckIn = DateTime.Now;

                /*ClaimsPrincipal currentUser = this.User;
                var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;*/

                var userEmail = User.Identity.Name;

                using (var context = new DowlingContext())
                {
                    var rental = from a in context.Rentals
                                 where a.BikeNumber.Equals(data.BikeNumber) && a.CheckInTime.Equals(new DateTime()) && a.RenterEmail.Equals(userEmail)
                                 select a;

                    Bike bike = new Bike();
                    Dock dock = new Dock();
                    try
                    {
                        bike = (from a in context.Bikes
                                where a.Id.Equals(data.BikeNumber)
                                select a).First();

                        dock = (from a in context.Docks
                                where a.Id.Equals(data.ReturnDock)
                                select a).First();

                    }
                    catch (Exception e)
                    {
                        Console.Error.WriteLine(e);

                        ViewData["Return"] = "false";
                        data.ReturnSuccessful = false;
                        Console.WriteLine("Return Failed");
                        return View("Return", data);
                    }

                    if (rental.Any())
                    {

                        // Check In Handling
                        var entry = context.Entry(rental.First());
                        entry.Property(u => u.CheckInTime).CurrentValue = data.CheckIn;

                        // Price Handling
                        var price = RoundHours((entry.Property(u => u.CheckInTime).CurrentValue - entry.Property(u => u.CheckOutTime).CurrentValue).TotalHours) * 9;

                        entry.Property(u => u.IsBikeDamaged).CurrentValue = data.BikeDamaged;

                        // Add charge if Bike is Damaged
                        if (data.BikeDamaged)
                        {
                            price += DamagedBikePriceAddition;
                            Console.WriteLine("Bike was damaged");
                        }

                        entry.Property(u => u.ReturnDock).CurrentValue = data.ReturnDock;

                        // Add charge if bike is returned at different dock
                        if (data.ReturnDock != entry.Property(u => u.RentDock).CurrentValue)
                        {
                            price += DifferentDockPriceAddition;
                            bike.DockId = data.ReturnDock;
                            Console.WriteLine("Returned at different Dock");
                        }

                        entry.Property(u => u.Price).CurrentValue = price;
                        data.Price = price;

                        // Damaged Bike Handling
                        entry.Property(u => u.IsBikeDamaged).CurrentValue = data.BikeDamaged;

                        bike.Rented = false;

                        TempData["Return"] = "true";
                        TempData["Price"] = price.ToString();

                        context.SaveChanges();
                    }
                    else
                    {
                        ViewData["Return"] = "false";
                        data.ReturnSuccessful = false;
                        Console.WriteLine("Return Failed");
                        return View("Return", data);
                    }
                }

                return RedirectToAction("Index", "Home");
                //return View("../Home/Index", data);
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
