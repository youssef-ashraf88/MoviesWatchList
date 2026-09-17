using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MovieWatchList.Core.DTO
{
    public class RegisterDTO
    {
        [Required(ErrorMessage = "user name is required")]
        public string PersonName { get; set; } = string.Empty;


        [Required(ErrorMessage = "email is required")]
        [EmailAddress(ErrorMessage = "email should be in a proper format")]
        public string Email { get; set; } = string.Empty;


        [Required(ErrorMessage = "password is required")]
        public string Password { get; set; } = string.Empty;


        [Required(ErrorMessage = "confirm password is required")]
        [Compare("Password", ErrorMessage = "password and confirm password should match")]
        public string ConfirmPassword { get; set; } = string.Empty;


        [Required(ErrorMessage = "phone number is required")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "phone number should contain digits only")]
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
