using AcademiX.Helpers;
using AcademiX.Models;
using Microsoft.AspNetCore.Mvc;

namespace AcademiX.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly ModelMapper modelMapper;

        public AuthenticationController(ModelMapper modelMapper)
        {
            this.modelMapper = modelMapper;
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
                //User user = this.authHelper.TryGetUser(viewModel.Username, viewModel.Password);
                //this.HttpContext.Session.SetString("CurrentUser", user.Username);

                return this.RedirectToAction(actionName: "Index", controllerName: "Home");
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

            return this.View(model: viewModel);
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel viewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model: viewModel);
            }

            //if (this.usersService.Exists(viewModel.Username))
            //{
            //    this.ModelState.AddModelError("Username", "User with same username already exists.");

            //    return this.View(model: viewModel);
            //}

            if (viewModel.Password != viewModel.ConfirmPassword)
            {
                this.ModelState.AddModelError("ConfirmPassword", "The password and confirmation password do not match.");

                return this.View(model: viewModel);
            }

            User user = this.modelMapper.Convert(viewModel);
            //this.usersService.Create(user);

            return this.RedirectToAction(actionName: "Login", controllerName: "Authentication");
        }
    }
}
