using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using IMSWeb.Core;

namespace IMSWeb.Controllers
{
    public class ClientReportController : Controller
    {
        // GET: ClientReport
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NoBday()
        {
            return View();
        }

        public ActionResult Bday()
        {
            return View();
        }

        public ActionResult NoMobile()
        {
            return View();
        }

        public ActionResult NoMobileWithEmail()
        {
            return View();
        }

        public ActionResult WithMobile()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetNoNicknames([DataSourceRequest]DataSourceRequest request)
        {
            var result = ClientData.NoNicknames();
            return Json(result.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetNoBirthdays([DataSourceRequest]DataSourceRequest request)
        {
            var result = ClientData.NoBirthdays();
            return Json(result.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
    }
}