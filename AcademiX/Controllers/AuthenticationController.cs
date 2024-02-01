using AcademiX.Helpers;
using AcademiX.Models;
using AcademiX.Repositories.Contracts;
using AcademiX.Services;
using AcademiX.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace AcademiX.Controllers
{
	public class AuthenticationController : Controller
	{
		private readonly ModelMapper modelMapper;
		private readonly IUserService _userService;

		public AuthenticationController(ModelMapper modelMapper, IUserService userService)
		{
			this.modelMapper = modelMapper;
			_userService = userService;
		}

		public IActionResult Login()
		{
			var viewModel = new LoginViewModel();

			return this.View(model: viewModel);
		}

		[HttpPost]
		public IActionResult Login(LoginViewModel viewModel)
		{
			if (!this.ModelState.IsValid)
			{
				return this.View(model: viewModel);
			}

			try
			{
				var user = _userService.TryGetUserByNameAndPass(viewModel.Username, viewModel.Password);

				if (user is not null)
				{
					return this.RedirectToAction(actionName: "Index", controllerName: "Home");
				}

				ModelState.AddModelError("Password", "Invalid username or password. Please try again.");
				return View(viewModel);

				//ModelState.AddModelError("Invalid username or pass!", "The username and password do not correspond to a user!");
				//return View(viewModel);

				//User user = this.authHelper.TryGetUser(viewModel.Username, viewModel.Password);
				//this.HttpContext.Session.SetString("CurrentUser", user.Username);

			}
			catch (Exception e)
			{
				this.ModelState.AddModelError("Username", e.Message);

				return this.View(model: viewModel);
			}
		}

		public IActionResult Logout()
		{
			this.HttpContext.Session.Remove("CurrentUser");

			return this.RedirectToAction(actionName: "Index", controllerName: "Home");
		}

		public IActionResult Register()
		{
			var viewModel = new RegisterViewModel();

			if (viewModel.Password != viewModel.ConfirmPassword)
			{
				ModelState.AddModelError("ConfirmPassword", "The password and confirmation password do not match.");
				return View(viewModel);
			}

			return this.View(model: viewModel);
			//return this.RedirectToAction(actionName: "Index", controllerName: "Home");
		}

		[HttpPost]
		public IActionResult Register(RegisterViewModel viewModel)
		{
			if (!this.ModelState.IsValid)
			{
				return this.View(model: viewModel);
			}

			if (_userService.GetUserByName(viewModel.Username) is not null)
			{
				this.ModelState.AddModelError("Username", "User with same username already exists.");

				return this.View(model: viewModel);
			}

			if (viewModel.Password != viewModel.ConfirmPassword)
			{
				this.ModelState.AddModelError("ConfirmPassword", "The password and confirmation password do not match.");

				return this.View(model: viewModel);
			}

			User user = this.modelMapper.Convert(viewModel);

			_userService.CreateUser(user);

			return this.RedirectToAction(actionName: "Login", controllerName: "Authentication");
		}
	}
}
