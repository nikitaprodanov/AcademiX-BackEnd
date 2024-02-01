using AcademiX.Data;
using AcademiX.Migrations;
using AcademiX.Models;
using AcademiX.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace AcademiX.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly ApplicationDbContext _context;

		public UserRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public void CreateUser(User user)
		{
			_context.Add(user);
			_context.SaveChanges();
		}

		public int DeleteUser(int id)
		{
			var userToDelete = _context.Users.Find(id);

			if (userToDelete != null)
			{
				_context.Users.Remove(userToDelete);
				_context.SaveChanges();
			}

			return userToDelete?.Id ?? 0;
		}

		public IEnumerable<User> GetAllUsers()
		{
			return _context.Users.ToList();
		}

		public User GetUserById(int id)
		{
			return _context.Users.Find(id) ?? throw new Exception("No such user exists!");
		}

		public User GetUserByName(string name)
		{
			return _context.Users.FirstOrDefault(u => u.Username == name) ?? throw new Exception("No such user exists!");
		}

		public User? TryGetUserByNameAndPass(string username, string pass)
		{
			return _context.Users.FirstOrDefault(u => u.Username == username && u.Password == pass);
		}

		public int UpdateUser(User userToUpdate)
		{
			_context.Entry(userToUpdate).State = EntityState.Modified;
			_context.SaveChanges();

			return userToUpdate.Id;
		}
	}
}
