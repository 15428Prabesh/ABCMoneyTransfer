using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
	public interface IUserRepositories
	{
		Task<User> GetUserByUsernameAsync(string username);
		Task<User> GetUserByEmailAsync(string email);
		Task AddUserAsync(User user);

		Task UpdateAsync(User user);
	}
}
