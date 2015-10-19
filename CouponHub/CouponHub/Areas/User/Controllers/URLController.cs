using BusinessLogicLayer;
using BussinessObjectsLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CouponHub.Areas.User.Controllers
{
    [Authorize(Roles = "A, U")]
    public class URLController : BaseUserController
    {
        private CommonBs objBs;

        public URLController() {
            objBs = new CommonBs();
        }

        // GET: User/URL
        public ActionResult Index()
        {
            ViewBag.CategoryId = new SelectList(objBs.categoryBs.GetAll().ToList(), "CategoryId", "CategoryName");
            ViewBag.UserId = new SelectList(objBs.userBs.GetAll().ToList(), "UserId", "UserEmail");
            return View();
        }

        // POST: User/URL
        [HttpPost]
        public ActionResult Create(Url_Table urlObj)
        {
            try
            {
                urlObj.IsApproved = "P";
                urlObj.UserId = objBs.userBs.GetAll().Where(x => x.UserEmail == User.Identity.Name).FirstOrDefault().UserId;

                if (ModelState.IsValid)
                {
                    objBs.urlBs.Insert(urlObj);
                    TempData["Msg"] = "Created Coupon Successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.CategoryId = new SelectList(objBs.categoryBs.GetAll().ToList(), "CategoryId", "CategoryName");
                    return View("Index");
                }
            }
            catch (Exception e)
            {
                TempData["Msg"] = "Create Failed : " + e.Message;
                return RedirectToAction("Index");
            }
            return View("Index");
        }
    }
}