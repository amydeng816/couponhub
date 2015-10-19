using BussinessObjectsLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CouponHub.Areas.Security.Controllers
{
    [AllowAnonymous]
    public class RegisterController : BaseSecurityController
    {
        // GET: Security/Register
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User_Table user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    user.Role = "U";
                    objBs.userBs.Insert(user);
                    TempData["Msg"] = "Created Successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Index");
                }
            }
            catch (Exception e)
            {
                TempData["Msg"] = "Create user failed";
                return RedirectToAction("Index");
            }
        }
    }
}