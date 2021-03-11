using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Backend.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Backend.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<BackendUser> _userManager;
        private readonly SignInManager<BackendUser> _signInManager;

        public IndexModel(
            UserManager<BackendUser> userManager,
            SignInManager<BackendUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Full Name")]
            public string Name { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Card Holders Name")]
            public string CardHolderName { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Credit Card Number")]
            public string CCNumber { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Experiation Number (mm/yyyy)")]
            public string ExpDate { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Security Number")]
            public int SecurityNumber { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Billing Address")]
            public string BillingAddress { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Address")]
            public string Address { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "State")]
            public string State { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "City")]
            public string City { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Country")]
            public string Country { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Zip Code")]
            public string ZipCode { get; set; }
        }

        private async Task LoadAsync(BackendUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            Username = userName;

            Input = new InputModel
            {
                PhoneNumber = phoneNumber,
                Name = user.Name,
                CardHolderName = user.CardHolderName,
                CCNumber = user.CCNumber,
                ExpDate = user.ExpDate,
                SecurityNumber = user.SecurityNumber,
                BillingAddress = user.BillingAddress,
                Address = user.Address,
                State = user.State,
                City = user.City,
                Country = user.Country,
                ZipCode = user.ZipCode
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }

            if (Input.Name != user.Name)
            {
                user.Name = Input.Name;
            }

            if (Input.CardHolderName != user.CardHolderName)
            {
                user.CardHolderName = Input.CardHolderName;
            }

            if (Input.CCNumber != user.CCNumber)
            {
                user.CCNumber = Input.CCNumber;
            }

            if (Input.ExpDate != user.ExpDate)
            {
                user.ExpDate = Input.ExpDate;
            }

            if (Input.SecurityNumber != user.SecurityNumber)
            {
                user.SecurityNumber = Input.SecurityNumber;
            }

            if (Input.BillingAddress != user.BillingAddress)
            {
                user.BillingAddress = Input.BillingAddress;
            }

            if (Input.Address != user.Address)
            {
                user.Address = Input.Address;
            }

            if (Input.State != user.State)
            {
                user.State = Input.State;
            }

            if (Input.City != user.City)
            {
                user.City = Input.City;
            }

            if (Input.Country != user.Country)
            {
                user.Country = Input.Country;
            }

            if (Input.ZipCode != user.ZipCode)
            {
                user.ZipCode = Input.ZipCode;
            }

            await _userManager.UpdateAsync(user);

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
