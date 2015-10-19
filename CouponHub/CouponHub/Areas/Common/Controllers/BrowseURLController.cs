using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CouponHub.Areas.Common.Controllers
{
    [AllowAnonymous]
    public class BrowseURLController : BaseCommonController
    {

        // GET: Common/BrowseURL
        public ActionResult Index(String SortOrder, string SortBy, string Page)
        {
            ViewBag.SortOrder = SortOrder;
            ViewBag.SortBy = SortBy;
            var urls = objBs.urlBs.GetAll().Where(x => x.IsApproved == "A");

            switch (SortBy)
            {
                case "Title":
                    switch (SortOrder)
                    {
                        case "Asc":
                            urls = urls.OrderBy(x => x.UrlTitle).ToList();
                            break;
                        case "Desc":
                            urls = urls.OrderByDescending(x => x.UrlTitle).ToList();
                            break;
                        default:
                            break;
                    }
                    break;
                case "Url":
                    switch (SortOrder)
                    {
                        case "Asc":
                            urls = urls.OrderBy(x => x.Url).ToList();
                            break;
                        case "Desc":
                            urls = urls.OrderByDescending(x => x.Url).ToList();
                            break;
                        default:
                            break;
                    }
                    break;
                case "Descript":
                    switch (SortOrder)
                    {
                        case "Asc":
                            urls = urls.OrderBy(x => x.UrlDesc).ToList();
                            break;
                        case "Desc":
                            urls = urls.OrderByDescending(x => x.UrlDesc).ToList();
                            break;
                        default:
                            break;
                    }
                    break;
                case "Coupon":
                    switch (SortOrder)
                    {
                        case "Asc":
                            urls = urls.OrderBy(x => x.Coupon).ToList();
                            break;
                        case "Desc":
                            urls = urls.OrderByDescending(x => x.Coupon).ToList();
                            break;
                        default:
                            break;
                    }
                    break;
                case "CategoryName":
                    switch (SortOrder)
                    {
                        case "Asc":
                            urls = urls.OrderBy(x => x.Category_Table.CategoryName).ToList();
                            break;
                        case "Desc":
                            urls = urls.OrderByDescending(x => x.Category_Table.CategoryName).ToList();
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    urls = urls.OrderBy(x => x.Url).ToList();
                    break;
            }

            ViewBag.TotalPages = Math.Ceiling(objBs.urlBs.GetAll().Where(x => x.IsApproved == "A").Count() / 10.0);
            int page = int.Parse(Page == null ? "1" : Page);
            ViewBag.Page = page;
            urls = urls.Skip((page - 1) * 10).Take(10);
            return View(urls);
        }
    }
}