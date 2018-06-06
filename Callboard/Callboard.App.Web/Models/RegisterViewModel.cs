﻿using System.ComponentModel.DataAnnotations;

namespace Callboard.App.Web.Models
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Login")]
        [MinLength(6)]
        public string Login { get; set; }

        [Required]
        [Display(Name = "Password")]
        [MinLength(6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Confirm password")]
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string RePassword { get; set; }
    }
}