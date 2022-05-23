using System;
using System.ComponentModel.DataAnnotations;

namespace SimpleJSLessons.Models
{
    public class loginControl
    {
        [Display(Name = "Username")]
        [StringLength(30)]
        [Required(ErrorMessage = "Username cannot be blank!")]
        [RegularExpression(@"^\S*$", ErrorMessage = "No white space allowed")]
        public string username { get; set; }
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}
