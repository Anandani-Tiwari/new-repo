using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFDBFirstApproachExample.Identity;
using EFDBFirstApproachExample.Models;
using EFDBFirstApproachExample.ViewModels;
using System.Web.Helpers;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace EFDBFirstApproachExample.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account/Register
        [ActionName("Register")]
        public ActionResult RegistrationPage()
        {
            return View();
        }

        //POST:Account/Register
        [HttpPost]
        public ActionResult Register(RegisterViewModel rvm)
        {
            if(ModelState.IsValid)
            {
                //register
                var appDbContext = new ApplicationDbContext();
                var userStore = new ApplicationUserStore(appDbContext);
                var userManager = new ApplicationUserManager(userStore);
                var passwordHash = Crypto.HashPassword(rvm.Password);
                var user = new ApplicationUser()
                {
                    Email = rvm.Email,
                    UserName = rvm.Username,
                    PasswordHash = passwordHash,
                    Birthday = rvm.DateOfBirth,
                    Address = rvm.Address,
                    City = rvm.City,
                    Country = rvm.Country,
                    PhoneNumber = rvm.Mobile
                };
                IdentityResult result = userManager.Create(user);
                if (result.Succeeded)
                {
                    //role
                    userManager.AddToRole(user.Id, "Customer");
                    //login
                    this.LoginUser(userManager,user);

                }
                return RedirectToAction("Index","Home");
            }
            else
            {
                ModelState.AddModelError("MyError", "Invalid Data");
                return View();
            }
        }
        //GET:Account/Login
        public ActionResult Login()
        {
            return View();
        }

        //POST:Account/Login
        [HttpPost]
        public ActionResult Login(LoginViewModel lvm)
        {
            //login
            var appDbContext = new ApplicationDbContext();
            var userStore = new ApplicationUserStore(appDbContext);
            var userManager = new ApplicationUserManager(userStore);
            var user = userManager.Find(lvm.Username, lvm.Password);
            if(user!=null)
            {
                this.LoginUser(userManager, user);
                if (userManager.IsInRole(user.Id,"Admin"))
                {
                    return RedirectToAction("Index", "Home",new { area="Admin"});
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
              
            }
            else
            {
                ModelState.AddModelError("myerr", "invalid Username or password");
                return View();
            }
          
        }
        [NonAction]
        public void LoginUser(ApplicationUserManager userManager,ApplicationUser user)
        {
            var authenticationManager = HttpContext.GetOwinContext().Authentication;
            var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
            authenticationManager.SignIn(new AuthenticationProperties(), userIdentity);
        }
        //GET:Account/Logout
        public ActionResult Logout()
        {
            var authenticationManager = HttpContext.GetOwinContext().Authentication;
            authenticationManager.SignOut();
            return RedirectToAction("Index","Home");
        }

        //GET:Account/MyProfile
        public ActionResult MyProfile()
        {
            var appDbContext = new ApplicationDbContext();
            var userStore = new ApplicationUserStore(appDbContext);
            var userManager = new ApplicationUserManager(userStore);
            ApplicationUser appUser = userManager.FindById(User.Identity.GetUserId());
            return View(appUser);
        }
    }
}