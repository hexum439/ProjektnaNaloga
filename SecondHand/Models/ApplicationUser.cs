using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace SecondHand.Models
{
	public class ApplicationUser : IdentityUser
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string City { get; set; }
	}
}
