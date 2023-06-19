using Britzza___v6.Interfaces;
using Britzza___v6.Models;
using Britzza___v6.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Britzza___v6.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserRepository _userRepository;

        public AccountController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _userRepository.GetUserByUsernameAndPassword(model.Username, model.Password);

                if (user != null)
                {
                    var nomeUsuario = user.Username;
                    return RedirectToAction("Dashboard", "Home", new { username = nomeUsuario });
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password");
                }
            }

            // Se houver erros de validação ou autenticação falhar, retornar a view de login com os erros exibidos.
            return View(model);
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