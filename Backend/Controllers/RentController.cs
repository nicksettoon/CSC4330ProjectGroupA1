﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Backend.Models;

namespace DowlingBikes
{
    namespace Backend.Controllers
    {
        public class RentController : Controller
        {
            public IActionResult Index()
            {
                return View();
            }

            public IActionResult SetNumber(RentModel data)
            {
                // Query for bike number and set to rented.
                return View();
            }
        }
    }
}