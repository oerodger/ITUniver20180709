using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DocflowApp.Models
{
    public class UserViewModel: EntityViewModel<User>
    {
        [DataType(DataType.Password)]
        [Required]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required]
        [Compare("Password")]
        [Display(Name = "Подтвердите пароль")]
        public string ConfirmPassword { get; set; }
    }
}