using AcademiX.Models;

namespace AcademiX.Helpers
{
	public class ModelMapper
	{
		public ModelMapper()
		{

		}		

		public User Convert(RegisterViewModel viewModel)
		{
			return new User()
			{
				Username = viewModel.Username,
				Password = viewModel.Password
			};
		}
	}
}
