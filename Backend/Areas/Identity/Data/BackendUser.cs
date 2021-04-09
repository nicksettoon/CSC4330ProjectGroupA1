using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Backend.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the BackendUser class
    public class BackendUser : IdentityUser
    {
        public BackendUser() : base()
        {

        }

        public BackendUser(string username) : base(username)
        {

        }

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

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }
        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }
        public virtual ICollection<IdentityUserToken<string>> Tokens { get; set; }
        public virtual ICollection<BackendUserRole> UserRoles { get; set; }

    }

    public class BackendRole : IdentityRole
    {
        public virtual ICollection<BackendUserRole> UserRoles { get; set; }

        public BackendRole() : base()
        { 
        }

        public BackendRole(string roleName) : base(roleName)
        {
        }
    }

    public class BackendUserRole : IdentityUserRole<string>
    {
        public virtual BackendUser User { get; set; }
        public virtual BackendRole Role { get; set; }
    }
}
