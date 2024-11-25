using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
	public class RegisterUserDto
	{
		[Required]
		public string Username { get; set; }
		[Required]
		public string Firstname { get; set; }
		public string? Middlename { get; set; }
		[Required]
		public string Lastname { get; set; }
		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }
		[DataType(DataType.Password)]
		[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
		public string ConfirmPassword { get; set; }
		[Required]
		[EmailAddress]
		public string Email { get; set; }
		public string? Address { get; set; }
		[Phone]
		public string? ContactNumber { get; set; }
		public string? Country { get; set; }
	}
}
