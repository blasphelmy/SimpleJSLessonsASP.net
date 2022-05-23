using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace SimpleJSLessons.Models
{
    public class UserModel
    {
        [Display(Name="Create a Username")]
        [StringLength(30)]
        [Required(ErrorMessage = "Username cannot be blank!")]
        [RegularExpression(@"^\S*$", ErrorMessage = "No white space allowed")]
        public String username { get; set; }
        [Display(Name = "Your first name")]
        [StringLength(20)]
        [Required(ErrorMessage = "First name cannot be blank!")]
        public String firstName { get; set; }
        [Display(Name = "Your last name")]
        [StringLength(20)]
        [Required(ErrorMessage = "Last name cannot be blank!")]
        public String lastName { get; set; }
        [Display(Name = "Create a password")]
        [Required(ErrorMessage = "Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public String password { get; set; }
        [Display(Name = "Confirm password")]
        [Required(ErrorMessage = "password confirmation required!")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Compare("password")]
        public String passwordcnf { get; set; }

    }
}
