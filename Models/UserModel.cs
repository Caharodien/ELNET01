using System.ComponentModel.DataAnnotations;

namespace ELNETBAI.Models
{
	public class UserModel
	{
		[Required]
		public string? Name { get; set; }

		[Required, EmailAddress]
		public string? Email { get; set; }

		[Required]
		public string? PhoneNo { get; set; }

		[Required]
		public string? Country { get; set; }

		[Required]
		public string? Username { get; set; }

		[Required, MinLength(6)]
		public string? Password { get; set; }
	}
}
