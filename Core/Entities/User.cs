using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
	public class User 
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string? MiddleName { get; set; }
		public string LastName { get; set; }
		public string UserName { get; set; }
		public string Password { get; set; }
		public string Email { get; set; }
		public string Address { get; set; }
		public string ContactNumber { get; set; }
		public string UserRole { get; set; }
		public string Country { get; set; }
		public DateTime CreatedAt { get; set; }
		public string CreatedBy { get; set; }
		public bool IsActive { get; set; }
	}
}
