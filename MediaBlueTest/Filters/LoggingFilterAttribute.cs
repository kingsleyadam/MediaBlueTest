using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MediaBlueTest
{
    public class LoggingFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var request = filterContext.HttpContext.Request;
            var page = filterContext.HttpContext.Request.Url.AbsoluteUri;
            string hostAddress = request.UserHostAddress;
            base.OnActionExecuted(filterContext);
        }
    }
}