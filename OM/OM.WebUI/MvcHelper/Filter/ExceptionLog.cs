using System;
using System.Web.Mvc;

namespace OM.WebUI.MvcHelper.Filter
{
    public class ExceptionLog : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            Exception ex = filterContext.Exception;
            if (ex is DivideByZeroException)
            {
                filterContext.Result = new RedirectResult("/DashBoard/DashBoard/Index");
            }

            filterContext.ExceptionHandled = true;
        }
    }
}