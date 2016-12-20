using MediaBlueTest.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace MediaBlueTest
{
    public class MvcApplication : System.Web.HttpApplication
    {
        void Session_Start(object sender, EventArgs e)
        {
            HttpContext.Current.Session.Add("__AppSession", string.Empty);
            
            ApplicationDbContext dbContext = new ApplicationDbContext();
            string userId = HttpContext.Current.User.Identity.GetUserId();
            if (!dbContext.Sessions.Any(s=>s.SessionId == this.Session.SessionID))
            {
                dbContext.Sessions.Add(new Models.Session { SessionId = this.Session.SessionID, ApplicationUserID = userId });
                dbContext.SaveChanges();
            }
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
