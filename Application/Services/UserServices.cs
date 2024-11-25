using Application.DTOs;
using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
	public class UserServices
	{
		private readonly IUserRepositories _userRepositories;
		public UserServices(IUserRepositories userRepositories) { 
			_userRepositories = userRepositories;
		}
		public async Task<bool> RegisterUserAsync(RegisterUserDto dto)
		{
			try
			{
				var existingUser = await _userRepositories.GetUserByUsernameAsync(dto.Username);
				if (existingUser != null) return false;
				var existingUserByEmail = await _userRepositories.GetUserByEmailAsync(dto.Email);
				if (existingUserByEmail != null)
					return false;
				var hashedPassword = BCrypt.Net.BCrypt.HashPassword(dto.Password);
				var user = new User
				{
					UserName = dto.Username,
					FirstName = dto.Firstname,
					MiddleName = dto.Middlename,
					LastName = dto.Lastname,
					Email = dto.Email,
					Password = hashedPassword,
					Address = dto.Address,
					CreatedAt = DateTime.UtcNow,
					CreatedBy = "admin",
					ContactNumber = dto.ContactNumber,
					Country = dto.Country,
					IsActive = true
				};
				await _userRepositories.AddUserAsync(user);
				return true;
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error during user registration: {ex.Message}");
				throw;
			}
		}
        public async Task<User> ValidateUser(string username, string password)
        {
            var result = await _userRepositories.GetUserByUsernameAsync(username);

            if (result != null && BCrypt.Net.BCrypt.Verify(password, result.Password))
            {
                return result;
            }
            return null;
        }
    }
}
