using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MVCECommerceRemake.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "{0} cannot be blank")]
        [Display(Name = "Username")]
        [StringLength(15, ErrorMessage = "{0} must be between {2} and {1} characters long.", MinimumLength = 3)]
        [Remote("CheckUsernameExists", "Account", HttpMethod = "Post", ErrorMessage = "This username is not available. Please try again.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "{0} cannot be blank")]
        [EmailAddress(ErrorMessage = "This {0} is not a valid e-mail address.")]
        [StringLength(255, ErrorMessage = "{0} must be under {1} characters long")]
        [Display(Name = "Email")]
        [Remote("CheckEmailExists", "Account", HttpMethod = "Post", ErrorMessage = "This email address is already is use by another account. Please try again.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} cannot be blank")]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-.]).{8,20}$",ErrorMessage = "Password must have at least one lower case character, one upper case character, one number & one special character.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "{0} cannot be blank")]
        [Compare("Password", ErrorMessage = "The passwords do not match.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "{0} cannot be blank")]
        [StringLength(35, ErrorMessage = "{0} must be under {1} characters long")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [StringLength(35, ErrorMessage = "{0} must be under {1} characters long")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "{0} cannot be blank")]
        [RegularExpression(@"^(?:(?:\(?(?:0(?:0|11)\)?[\s-]?\(?|\+)44\)?[\s-]?(?:\(?0\)?[\s-]?)?)|(?:\(?0))(?:(?:\d{5}\)?[\s-]?\d{4,5})|(?:\d{4}\)?[\s-]?(?:\d{5}|\d{3}[\s-]?\d{3}))|(?:\d{3}\)?[\s-]?\d{3}[\s-]?\d{3,4})|(?:\d{2}\)?[\s-]?\d{4}[\s-]?\d{4}))(?:[\s-]?(?:x|ext\.?|\#)\d{3,4})?$",
            ErrorMessage = "{0} must be in UK format.")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone/Mobile Number")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "{0} cannot be blank")]
        [StringLength(35, ErrorMessage = "{0} must be under {1} characters long")]
        [Display(Name = "House Name/Number")]
        public string HouseName { get; set; }

        [Required(ErrorMessage = "{0} cannot be blank")]
        [StringLength(35, ErrorMessage = "{0} must be under {1} characters long")]
        [Display(Name = "Address Line 1")]
        public string Address1 { get; set; }

        [StringLength(35, ErrorMessage = "{0} must be under {1} characters long")]
        [Display(Name = "Address Line 2")]
        public string Address2 { get; set; }

        [Required(ErrorMessage = "{0} cannot be blank")]
        [RegularExpression(@"([Gg][Ii][Rr] 0[Aa]{2})|((([A-Za-z][0-9]{1,2})|(([A-Za-z][A-Ha-hJ-Yj-y][0-9]{1,2})|(([A-Za-z][0-9][A-Za-z])|([A-Za-z][A-Ha-hJ-Yj-y][0-9]?[A-Za-z]))))\s?[0-9][A-Za-z]{2})",
            ErrorMessage = "{0} Must be in UK format.")]
        [DataType(DataType.PostalCode)]
        [Display(Name = "Postcode")]
        public string Postcode { get; set; }
    }
}
