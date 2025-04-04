using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = Microsoft.Build.Framework.RequiredAttribute;

namespace Demo_PL.Models
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress(ErrorMessage ="Invalid Email")]
        public string EmailAddress { get; set;}
        [Required]
        [StringLength(6, MinimumLength = 5, ErrorMessage = "Invalid Password")]
        public string Password { get; set;}
        [Required]
        [Compare(nameof(Password), ErrorMessage ="Password Mismatch")]
        public string ConfirmPassword { get; set; }
        [Required]
        public bool IsAgree { get; set; }

    }
}
