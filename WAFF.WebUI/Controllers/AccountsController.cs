using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WAFF.DataAccess.Entity;
using WAFF.DataAccess.Contexts;
using System.Web.Security;

namespace WAFF.WebUI.Controllers
{
    public class AccountsController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                using (var context = new EFDbContext())
                {
                    var username = model.UserEmail;
                    var password = model.UserPassword;

                    var userIsValid = context.Users.Any(m => m.UserEmail == username && m.UserPassword == password);

                    if (userIsValid)
                    {
                        FormsAuthentication.SetAuthCookie(username, false);

                        if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                            && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                        {
                            return Redirect(returnUrl);
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "The user name or password provided is incorrect.");
                    }
                }
            }

            return View(model);
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}