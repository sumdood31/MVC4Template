using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using BlogData;
using BlogWeb.Models;

namespace BlogWeb.Controllers
{
    public class ApplicationController : Controller
    {
        //***************?????????????***********************///
        //NOTE:PUT SHARED DATA CONTEXT HERE
        //private ProjectDataContext datacontext = new ProjectDataContext();

        //protected ProjectDataContext DataContext
        //{
        //    get { return datacontext; }
        //}

        private ApplicationModel pageBaseModel = new ApplicationModel();
        protected ApplicationModel PageModel
        {
            get { return pageBaseModel; }
        }

        public ApplicationController()
        {

        }

        protected override void OnResultExecuting(ResultExecutingContext ctx)
        {
            base.OnResultExecuting(ctx);

            string _ipAddress;
            _ipAddress = ctx.HttpContext.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(_ipAddress))
            { _ipAddress = ctx.HttpContext.Request.ServerVariables["REMOTE_ADDR"]; }

            Tracking tracking = new Tracking();
            tracking.CreatedDate = DateTime.Now;
            tracking.Session = ctx.HttpContext.Session.SessionID;
            tracking.IP = _ipAddress;
            tracking.URL = ctx.HttpContext.Request.Url.PathAndQuery;

            try
            {
                using (var context = new BlogEntities())
                {
                    context.Entry(tracking).State = System.Data.EntityState.Added;
                    context.SaveChanges();                 
                }
            }
            catch (Exception ex)
            {
                ErrorModel err = new ErrorModel();
                err.InsertError(ex);
            }


            ViewBag.PageModel = PageModel;
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {

            if (filterContext.Exception != null)
            {
                BlogWeb.Models.ErrorModel err = new BlogWeb.Models.ErrorModel();
                err.InsertError(filterContext.Exception);

                filterContext.HttpContext.Trace.Write("(Logging Filter)Exception thrown");
            }

            base.OnActionExecuted(filterContext);
        }

    }
}
