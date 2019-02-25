using System;
using System.Web.Mvc;
using OM.Entity.Domain;
using System.Threading;
using OM.WebUI.MvcHelper;
using OM.Business.Abstract;
using OM.Entity.Complex.LogX;
using OIT.Core.Utilities.Common;

namespace OM.WebUI.Areas.DashBoard.Controllers
{
    public class LogXController : Controller
    {
        private readonly IUserBs _us;
        public LogXController(IUserBs us)
        {
            _us = us;
        }

        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public JsonResult LogIn(LogInVM vm)
        {
            try
            {
                if (SessionManager.SecurityCode != vm.SecurityCode)
                    return Json(new { Result = false, Message = "Güvenlik Kodu Doğrulanamadı!" });

                User user =
                    _us.Get(x => x.UserName == vm.UserName && x.Password == vm.Password);

                if (user != null)
                {
                    SessionManager.ActiveUser = user;

                    return Json(new { Result = true });
                }

                return Json(new { Result = false, Message = "Kullanıcı Adı yada Şifre Hatalı!" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = false, ex.Message });
            }            
        }

        [HttpGet]
        public ActionResult LogOut()
        {
            Session.Clear();

            return View();
        }

        [HttpGet]
        public ActionResult LogLock()
        {
            return View();
        }

        [HttpPost]
        public JsonResult LogLock(LogLockVM vm)
        {
            Thread.Sleep(1000);
            User user =
                _us.Get(x => x.Id == SessionManager.ActiveUser.Id && x.Password == vm.Password);

            if (user != null)
            {
                SessionManager.ActiveUser = user;

                return Json(new { Result = true });
            }

            return Json(new { Result = false, Message = "Şifre Hatalı Girildi!" });

        }

        public FileContentResult GetSecurityImage()
        {
            FileContentResult result = new FileContentResult(ImageHelper.CreateSecurityImage(), "image/png");

            SessionManager.SecurityCode = ImageHelper.SecurityCode;

            return result;
        }
    }
}