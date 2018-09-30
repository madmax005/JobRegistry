using JobRegistry.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobRegistry.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        } //Create Username & Password 
        public ActionResult Authorized()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Authorized(Users user)
        {
            if (!ModelState.IsValid)

            {
                return View();

            }
            using (JobRegistryDBContext db = new JobRegistryDBContext())

            {
                Users u = db.Users.FirstOrDefault(model => model.UserName == user.UserName);

                if (u != null)
                {
                    ModelState.AddModelError("", "This username already exists.");
                    return View();
                }

                db.Users.Add(user);
                db.SaveChanges();
                               
            };
            return RedirectToAction("Login");

            //Get User login 
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Users user)
        {
            using (JobRegistryDBContext db = new JobRegistryDBContext())
            {
                var usr = db.Users.Single(u => u.UserName == user.UserName && u.Password == user.Password);
                if (usr != null)
                {
                    Session["UserID"] = usr.ID.ToString();
                    Session["Username"] = usr.UserName.ToString();
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Username or Password is wrong.");
                }
            }
            return View();
        }
        public ActionResult LogOut()
        {

            Session.Abandon();
            return RedirectToAction("Login");
        }
    }
}
