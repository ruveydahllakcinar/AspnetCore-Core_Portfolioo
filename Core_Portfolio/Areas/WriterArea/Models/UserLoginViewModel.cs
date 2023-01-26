using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Portfolio.Areas.WriterArea.Models
{
    public class UserLoginViewModel
    {
        [Display(Name ="Username")]
        [Required(ErrorMessage ="Please enter username")]
        public string Username{ get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please enter password")]
        public string Password { get; set; }
    }
}
