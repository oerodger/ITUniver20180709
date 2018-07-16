using DocflowApp.Models;
using DocflowApp.Models.Filters;
using DocflowApp.Models.Repositories;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DocflowApp.Controllers
{
    [Authorize]
    public class UserController : BaseController
    {
        public UserController(UserRepository userRepository): 
            base(userRepository)
        {
            this.userRepository = userRepository;
        }

        // GET: User
        public ActionResult Index(UserFilter userFilter, FetchOptions options)
        {
            var users = userRepository.Find(userFilter, options);
            return View(users);
        }

        public ActionResult Create()
        {
            var model = new UserViewModel { Entity = new User() };
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var res = UserManager.CreateAsync(model.Entity, model.Password);
                if (res.Result == IdentityResult.Success)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }
    }
}