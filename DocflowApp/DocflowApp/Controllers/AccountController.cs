using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DocflowApp.Files;
using DocflowApp.Models;
using DocflowApp.Models.Repositories;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace DocflowApp.Controllers
{
    public class AccountController : BaseController
    {
        public AccountController(UserRepository userRepository, IFileProvider[] fileProviders) 
            : base(userRepository, fileProviders)
        {
        }

        public ActionResult CreateUser(string login, string password)
        {
            var res = UserManager.CreateAsync(new User { UserName = login }, password);
            if (res.Result == IdentityResult.Success)
            {
                return RedirectToAction("Login");
            }
            return RedirectToAction("Login");
        }

        public ActionResult Login()
        {
            return View(new LoginViewModel { Date = DateTime.Now });
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = SignInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
                if (result.Result == SignInStatus.Success)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Неверный логин или пароль");
                }
            }
            return View(model);
        }
    }
}