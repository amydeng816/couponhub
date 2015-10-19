using BussinessObjectsLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CouponHub.Areas.Security.Controllers
{
    [AllowAnonymous]
    public class LoginController : BaseSecurityController
    {
        // GET: Security/Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(User_Table user)
        {
            try
            {
                if (Membership.ValidateUser(user.UserEmail, user.Password))
                {
                    FormsAuthentication.SetAuthCookie(user.UserEmail, false);
                    return RedirectToAction("Index", "Home", new { area = "Common" });
                }
                else
                {
                    TempData["Msg"] = "Login Failed";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {
                TempData["Msg"] = "Login Failed : " + e.Message;
                return RedirectToAction("Index");
            }
        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home", new { area = "Common" });
        }
    }
}