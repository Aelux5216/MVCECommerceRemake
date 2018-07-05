using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MVCECommerceRemake.Models.AccountViewModels
{
    public class LoginViewModel
    {
        /*[Required]
        [EmailAddress]
        public string Email { get; set; }
        */

        [Required(ErrorMessage = "{0} cannot be blank")]
        [DataType(DataType.Text)]
        [Display(Name = "Email or Username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "{0} cannot be blank")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}
