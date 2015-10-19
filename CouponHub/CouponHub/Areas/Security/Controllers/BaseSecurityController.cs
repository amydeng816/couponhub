using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CouponHub.Areas.Security.Controllers
{
    public class BaseSecurityController : Controller
    {
        protected SecurityBs objBs;

        public BaseSecurityController()
        {
            objBs = new SecurityBs();
        }
    }
}