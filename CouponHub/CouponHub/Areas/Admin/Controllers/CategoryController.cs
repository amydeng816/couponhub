﻿using BusinessLogicLayer;
using BussinessObjectsLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CouponHub.Areas.Admin.Controllers
{
    [Authorize(Roles="A")]
    public class CategoryController : BaseAdminController
    {

        // GET: Admin/Category
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category_Table category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    objBs.categoryBs.Insert(category);
                    TempData["Msg"] = "Created Category Successfully";
                    return RedirectToAction("Index");
                }
                else
                {
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