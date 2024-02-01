using AcademiX.Models;

namespace AcademiX.Services.Contracts
{
    public interface IUserService
    {
        public IEnumerable<User> GetAllUsers();

        public User GetUserById(int id);

        public User GetUserByName(string name);

        public void CreateUser(User specialty);

        public int UpdateUser(User userToUpdate);

        public int DeleteUser(int id);

		public User? TryGetUserByNameAndPass(string username, string pass);
	}
}
