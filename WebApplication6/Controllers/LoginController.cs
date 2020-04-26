using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication6.Models;

namespace WebApplication6.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Authorize(WebApplication6.Models.User userModel)
        {
            using (ClinicEntities db = new ClinicEntities())
            {
                var userdetails = db.Users.Where(x => x.Email == userModel.Email && x.Pswd == userModel.Pswd).FirstOrDefault();
                if (userdetails == null)
                {
                    userModel.LoginErrorMessage = "Wrong username or password";
                    return View("Index", userModel);
                }
                else
                {
                    Session["userID"] = userdetails.UID;
                    return RedirectToAction("Index", "Demo");
                }
            }
        }
    }
}