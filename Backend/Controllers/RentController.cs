using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Backend.Models;
using Backend.Context;
using Backend.Entities;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace DowlingBikes
{
    namespace Backend.Controllers
    {
        [Authorize]
        public class RentController : Controller
        {

            private const double DamagedBikePriceAddition = 8.5;

            public IActionResult Index()
            {
                return View();
            }

            public IActionResult Submit(RentModel data)
            {
                data.CheckOut = DateTime.Now;


                /*ClaimsPrincipal currentUser = this.User;
                var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;*/

                var userEmail = User.Identity.Name;

                using (var context = new DowlingContext())
                {
                    var rental = from a in context.Rentals
                                 where a.BikeNumber.Equals(data.BikeNumber) && a.CheckInTime.Equals(new DateTime())
                                 select a;

                    if (!rental.Any())
                    {
                        context.Rentals.Add(new Rental() { CheckOutTime = data.CheckOut, BikeNumber = data.BikeNumber, RenterEmail = userEmail });
                        data.AlreadyCheckedOut = false;
                    }
                    else
                    {
                        data.AlreadyCheckedOut = true;
                        data.RentSuccessful = false;
                    }
                    
                    context.SaveChanges();
                }

                return View("Index", data);
            }

            public IActionResult Return(RentModel data)
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

                    if (rental.Any())
                    {
                        // Check In Handling
                        var entry = context.Entry(rental.First());
                        entry.Property(u => u.CheckInTime).CurrentValue = data.CheckIn;

                        // Price Handling
                        var price = (entry.Property(u => u.CheckInTime).CurrentValue - entry.Property(u => u.CheckOutTime).CurrentValue).TotalHours * 9;
                        entry.Property(u => u.Price).CurrentValue = price;

                        if (data.BikeDamaged)
                        {
                            price += DamagedBikePriceAddition;
                        }

                        data.Price = price;


                        // Damaged Bike Handling
                        entry.Property(u => u.IsBikeDamaged).CurrentValue = data.BikeDamaged;


                        context.SaveChanges();
                    }
                    else
                    {
                        data.ReturnSuccessful = false;
                    }

                    
                }

                return View("Index", data);
            }
        }
    }
}
