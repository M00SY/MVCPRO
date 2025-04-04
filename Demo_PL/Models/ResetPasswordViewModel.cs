using System.ComponentModel.DataAnnotations;

namespace Demo_PL.Models
{
    public class ResetPasswordViewModel
    {
        [Required]
        [StringLength(6, MinimumLength = 5, ErrorMessage = "Invalid Password")]
        public string Password { get; set; }
        [Required]
        [Compare(nameof(Password), ErrorMessage = "Password Mismatch")]
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }

        public string Token { get; set; }

    }
}
