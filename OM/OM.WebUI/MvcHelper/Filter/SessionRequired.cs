using System.Web.Mvc;

namespace OM.WebUI.MvcHelper.Filter
{
    public class SessionRequired : FilterAttribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {

        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (SessionManager.ActiveUser == null)
                filterContext.Result = new RedirectResult("/DashBoard/LogX/LogIn");
        }
    }
}