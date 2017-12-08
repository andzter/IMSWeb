using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace IMSWeb.Core
{
    public class FileDownloadResult : ActionResult
    {
        #region Constructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        public FileDownloadResult()
        {

        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public FileDownloadResult(string virtualPath)
        {
            VirtualPath = virtualPath;
        }

        #endregion  // Constructors

        #region Public Properties

        /// <summary>
        /// Gets and sets ContentLength.
        /// </summary>
        public int ContentLength { get; set; }

        /// <summary>
        /// Gets and sets ContentType.
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// Gets and sets FileDownloadName.
        /// </summary>
        public string FileDownloadName { get; set; }

        /// <summary>
        /// Gets and sets VirtualPath.
        /// </summary>
        public string VirtualPath { get; set; }

        /// <summary>
        /// Gets and sets Content.
        /// </summary>
        public byte[] Content { get; set; }

        #endregion  // Public Properties

        #region Public Methods

        public override void ExecuteResult(ControllerContext context)
        {
            context.HttpContext.Response.Clear();

            if (!String.IsNullOrEmpty(FileDownloadName))
            {
                context.HttpContext.Response.AddHeader("content-disposition", "attachment; filename=\"" + this.FileDownloadName + "\"");
            }

            if (!String.IsNullOrEmpty(ContentType))
            {
                context.HttpContext.Response.ContentType = ContentType;
            }

            if (ContentLength > 0)
            {
                context.HttpContext.Response.AddHeader("content-length", ContentLength.ToString());
            }

            if (Content != null && Content.Length > 0)
            {
                context.HttpContext.Response.BinaryWrite(Content);
            }

            if (!String.IsNullOrEmpty(VirtualPath))
            {
                context.HttpContext.Response.TransmitFile(VirtualPath);
            }

            context.HttpContext.Response.End();
        }

        #endregion  // Public Methods
    }
}
