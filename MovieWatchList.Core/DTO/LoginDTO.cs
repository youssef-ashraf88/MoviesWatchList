using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MovieWatchList.Core.DTO
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Email should be in a proper format")]
        public string Email { get; set; } = string.Empty;


        [Required(ErrorMessage = "password is reqired")]
        public string Password { get; set; } = string.Empty;
    }
}
