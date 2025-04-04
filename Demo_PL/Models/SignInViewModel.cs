using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = Microsoft.Build.Framework.RequiredAttribute;

namespace Demo_PL.Models
{
	public class SignInViewModel
	{
		[Required]
		[EmailAddress]
        public string EmailAddress { get; set; }
		[Required]
		[StringLength(6, MinimumLength = 5, ErrorMessage = "Invalid Password")]
		public string Password { get; set; }

        public bool RememberMe { get; set; }


    }
}
