using DocflowApp.Files;
using DocflowApp.Models;
using DocflowApp.Models.Repositories;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DocflowApp.Controllers
{
    public class BaseController : Controller
    {
        protected UserRepository userRepository;
        protected IFileProvider[] fileProviders;

        public BaseController(UserRepository userRepository, IFileProvider[] fileProviders)
        {
            this.userRepository = userRepository;
            this.fileProviders = fileProviders;
        }

        public SignInManager SignInManager
        {
            get { return HttpContext.GetOwinContext().Get<SignInManager>(); }
        }

        public UserManager UserManager
        {
            get { return HttpContext.GetOwinContext().GetUserManager<UserManager>(); }
        }

        public User CurrentUser
        {
            get { return userRepository.GetCurrentUser(User); }
        }

        public IFileProvider GetFileProvider()
        {
            var key = ConfigurationManager.AppSettings["FileProvider"];
            return fileProviders.First(p => p.Name == key);
        }
    }
}