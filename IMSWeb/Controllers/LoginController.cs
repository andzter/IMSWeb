using IMSWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using IMSWeb.Core;

namespace IMSWeb.Controllers
{
    [Authorize]
    public class LoginController : Controller
    {
        // GET: Login
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Index()
        {
            var model = new Login();

            if (Session["logError"] != null)
                if (Session["logError"].ToString().Equals("1"))
                    ModelState.AddModelError("UserName", "The user name or password provided is incorrect.");

            return View();
        }

        [AllowAnonymous]
        [HttpPost, ActionName("Index")]
        [ValidateAntiForgeryToken]
        public ActionResult LoginPost()
        {

            var model = new Login();
            TryUpdateModel(model, "", new string[] { "UserName", "Password" });


            //ModelState.AddModelError("", "The user name or password provided is incorrect.");
            if (AdminDataContext.LoginUser(model.UserName, model.Password) == 0)
            {
                Session["logError"] = 1;

                return RedirectToAction("Index", "Login");
            }
            else
            {
                FormsAuthentication.SetAuthCookie(model.UserName, false);
                Session["UserName"] = model.UserName;
                return RedirectToAction("Index", "Home");
            }

        }



        public ActionResult LogOff()
        {

            FormsAuthentication.SignOut();
            // clear all cookies
            string[] myCookies = Request.Cookies.AllKeys;
            foreach (string cookie in myCookies)
            {
                Response.Cookies[cookie].Expires = DateTime.Now.AddDays(-1);
            }
            Session.Abandon();

            return RedirectToAction("Index", "Login");

        }
    }
}