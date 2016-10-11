using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicMattersMVC.ViewModels
{
    public class LoginVM
    {
        [Required]
        [Display(Name = "Username: ")]
        [StringLength(50, MinimumLength = 5)]
        public string Username { get; set; }

        [Required]
        [Display(Name = "Password: ")]
        [StringLength(50, MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Pass { get; set; }
    }
}