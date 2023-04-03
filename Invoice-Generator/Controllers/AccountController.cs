using Domain.Entities.Identification;
using Invoice_Generator.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.Win32;

namespace Invoice_Generator.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        public AccountController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Login login)
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }
            //logika logująca
            return RedirectToAction("Index", "Home");

        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(Register register)
        {
            if (!ModelState.IsValid)
            {
                return View(register);
            }
            //register logic 
            var newUser = new UserModel
            {
                Email = register.Email,
                UserName = register.UserName,
            };

            await _userManager.CreateAsync(newUser, register.Password);

            //await _userManager.CreateAsync(new UserModel
            //{
            //    Email = register.Email,
            //    UserName = register.UserName
            //}, register.Password);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Logout()
        {
            return View();
        }
    }
}
