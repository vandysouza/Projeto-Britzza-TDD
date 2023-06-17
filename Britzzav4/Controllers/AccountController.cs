using Britzzav4.Interfaces;
using Britzzav4.Models;
using Britzzav4.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Britzzav4.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserRepository _userRepository;

        public AccountController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    Username = model.Username,
                    Email = model.Email,
                    Password = model.Password,
                    Function = model.Function
                };

                _userRepository.CreateUser(user);

                return RedirectToAction("Login");
            }
            return View(model);
        }
    }
}