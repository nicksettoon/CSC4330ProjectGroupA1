using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Entities;
using Microsoft.AspNetCore.Identity;

namespace Backend.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the BackendUser class
    public class BackendUser : IdentityUser
    {
        [PersonalData]
        public string Name { get; set; }

        [PersonalData]
        public string CardHolderName { get; set; }

        [PersonalData]
        public string CCNumber { get; set; }

        [PersonalData]
        public string ExpDate { get; set; }

        [PersonalData]
        public int SecurityNumber { get; set; }

        [PersonalData]
        public string BillingAddress { get; set; }

        [PersonalData]
        public string Address { get; set; }

        [PersonalData]
        public string State { get; set; }

        [PersonalData]
        public string City { get; set; }

        [PersonalData]
        public string Country { get; set; }

        [PersonalData]
        public string ZipCode { get; set; }

    }
}
