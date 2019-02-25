using System.Linq;
using System.Web.Mvc;
using OM.Entity.Complex.HR;
using OM.Business.Abstract;
using System.Collections.Generic;

namespace OM.WebUI.Areas.DashBoard.Controllers
{
    public class HRController : Controller
    {
        private readonly IUserBs _us;
        private readonly IRoleBs _rs;

        public HRController(IUserBs us, IRoleBs rs)
        {
            _us = us;
            _rs = rs;
        }

        public ActionResult HR(UserListVM vm)
        {
            List<UserListVM> list = _us.GetAll()
                .Select(x => new UserListVM()
                {
                    Photo = x.Photo,
                    FName = x.FName,
                    LName = x.LName,
                    Email = x.Email,
                    Phone = x.Phone,
                    Created = x.Created,
                    IsActive = x.IsActive,
                    UserName = x.UserName,
                    RoleName = _rs.GetAll()
                                    .Where(y => y.Id == x.RoleId)
                                    .Select(y => y.Name)
                                    .FirstOrDefault(),
                    PersonnelCode = x.Id
                }).ToList();

            return View(list);
        }
    }
}