using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Portfolio.Areas.WriterArea.Models
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage = "Please enter name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter surname")]
        public string Surname { get; set; }

        [Required(ErrorMessage ="Please enter username")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please enter password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please re-enter the password")]
        [Compare("Password",ErrorMessage = "Passwords do not match. please re-enter")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Please enter image url")]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "Please enter the mail")]
        public string Mail { get; set; }
    }
}
