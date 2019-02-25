using System.Web;
using OM.Entity.Domain;

namespace OM.WebUI.MvcHelper
{
    public class SessionManager
    {
        public static User ActiveUser
        {
            get
            {
                return HttpContext.Current.Session["ActiveUser"] as User;
            }
            set
            {
                HttpContext.Current.Session.Add("ActiveUser", value);
            }
        }

        public static string SecurityCode
        {
            get
            {
                return HttpContext.Current.Session["SecurityCode"].ToString();
            }
            set
            {
                HttpContext.Current.Session.Add("SecurityCode", value);
            }
        }
    }
}