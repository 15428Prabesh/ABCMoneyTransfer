using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
	public class UserRepository : IUserRepositories
	{
		private readonly AppDbContext _context;
		public UserRepository(AppDbContext appDbContext)
		{
			_context = appDbContext;
		}
		public async Task<User> GetUserByUsernameAsync(string username)
		{
			return await _context.Users.SingleOrDefaultAsync(u => u.UserName == username);
		}
		public async Task<User> GetUserByEmailAsync(string email)
		{
			return await _context.Users.SingleOrDefaultAsync(u => u.Email == email);
		}
		public async Task AddUserAsync(User user)
		{
			await _context.Users.AddAsync(user);
			await _context.SaveChangesAsync();
		}
		public async Task UpdateAsync(User user)
		{
			_context.Users.Update(user);
			await _context.SaveChangesAsync();
		}
	}
}
