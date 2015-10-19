using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CouponHub.Areas.Admin.Controllers
{
    [Authorize(Roles = "A")]
    public class ApproveURLsController : BaseAdminController
    {
        // GET: Admin/ApproveURLs
        public ActionResult Index(String Status)
        {
            ViewBag.Status = (Status == null ? "P" : Status);
            if (Status == null)
            {
                var urls = objBs.urlBs.GetAll().Where(x => x.IsApproved == "P").ToList();
                return View(urls);
            }
            else
            {
                var urls = objBs.urlBs.GetAll().Where(x => x.IsApproved == Status).ToList();
                return View(urls);
            }
        }

        public ActionResult Approve(int id)
        {
            try
            {
                var myUrl = objBs.urlBs.GetByID(id);
                myUrl.IsApproved = "A";
                objBs.urlBs.Update(myUrl);
                TempData["Msg"] = "Approved Successfully";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["Msg"] = "Approval Failed : " + e.Message;
                return RedirectToAction("Index");
            }
        }

        public ActionResult Reject(int id)
        {
            try
            {
                var myUrl = objBs.urlBs.GetByID(id);
                myUrl.IsApproved = "R";
                objBs.urlBs.Update(myUrl);
                TempData["Msg"] = "Rejected Successfully";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["Msg"] = "Rejection Failed : " + e.Message;
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult ApproveOrRejectAll(List<int> Ids, string Status, string CurrentStatus)
        {
            try
            {
                objBs.ApproveOrReject(Ids, Status);
                TempData["Msg"] = "Updated Sucessfully!";
                var urls = objBs.urlBs.GetAll().Where(x => x.IsApproved == CurrentStatus).ToList();
                return PartialView("pv_ApproveURLs", urls);
            }
            catch (Exception e)
            {
                TempData["Msg"] = "Update Failed" + e.Message;
                var urls = objBs.urlBs.GetAll().Where(x => x.IsApproved == CurrentStatus).ToList();
                return PartialView("pv_ApproveURLs", urls);
            }
        }
    }
}