using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Optimization;
using OM.Business.DependencyResolvers;
using OIT.Core.Utilities.Mvc.IoC.Ninject;

namespace OM.WebUI
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory(new NinjectBusinessModule()));
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Session.Timeout = 60;
        }
    }
}