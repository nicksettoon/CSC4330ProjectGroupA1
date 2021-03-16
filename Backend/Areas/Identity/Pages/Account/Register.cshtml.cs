using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Backend.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;

namespace Backend.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<BackendUser> _signInManager;
        private readonly UserManager<BackendUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;

        public RegisterModel(
            UserManager<BackendUser> userManager,
            SignInManager<BackendUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
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

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = new BackendUser {
                    Name = Input.Name,
                    CardHolderName = Input.CardHolderName,
                    CCNumber = Input.CCNumber,
                    ExpDate = Input.ExpDate,
                    SecurityNumber = Input.SecurityNumber,
                    BillingAddress = Input.BillingAddress,
                    Address = Input.Address,
                    State = Input.State,
                    City = Input.City,
                    Country = Input.Country,
                    ZipCode = Input.ZipCode,
                    UserName = Input.Email, 
                    Email = Input.Email 
                };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
