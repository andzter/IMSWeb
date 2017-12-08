using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IMSWeb.Core;

namespace IMSWeb.Controllers
{
    public class ExportController : Controller
    {
        // GET: Export
        [HttpPost()]
        public ActionResult Index()
        {
            DataTable results = new DataTable();

            var transform = results.TransformXslt(Server.MapPath(@"~/Resources/xsl/excel.xsl"));

            return new FileDownloadResult
            {
                FileDownloadName = "emails.xls",
                ContentType = "application/vnd.ms-excel",
                Content = transform.ToByteArray()
            };
        }
    }
}