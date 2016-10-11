using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MusicMattersMVC.ViewModels
{
    public class RegisterVM
    {
        [Required]
        [Display(Name = "Username: ")]
        [StringLength(50, MinimumLength = 5)]
        public string Username { get; set; }

        [Required]
        [Display(Name = "Password: ")]
        [StringLength(50, MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Pass { get; set; }   //Fetches plaintext from POST

        [Required]
        [Display(Name = "Retype password: ")]
        [DataType(DataType.Password)]
        [Compare("Pass")]
        public string ComparePass { get; set; }

        [Required]
        [Display(Name = "Email address: ")]
        [StringLength(100, MinimumLength = 5)]
        [RegularExpression("^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-]+$")]
        public string Email { get; set; }
    }
}