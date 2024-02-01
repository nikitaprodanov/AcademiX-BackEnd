using AcademiX.Migrations;
using AcademiX.Models;
using AcademiX.Repositories;
using AcademiX.Repositories.Contracts;
using AcademiX.Services.Contracts;

namespace AcademiX.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void CreateUser(User user)
		{
            _userRepository.CreateUser(user);
		}

        public int DeleteUser(int id)
        {
			return _userRepository.DeleteUser(id);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

        public User GetUserById(int id)
        {
			return _userRepository.GetUserById(id);
		}

        public User GetUserByName(string name)
        {
			return _userRepository.GetUserByName(name);
		}

		public User? TryGetUserByNameAndPass(string username, string pass)
		{
            return _userRepository.TryGetUserByNameAndPass(username, pass);
		}

		public int UpdateUser(User userToUpdate)
        {
			return _userRepository.UpdateUser(userToUpdate);
		}
    }
}
