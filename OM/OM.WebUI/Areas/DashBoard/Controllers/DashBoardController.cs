using System;
using System.Linq;
using System.Web.Mvc;
using OM.Entity.Domain;
using OM.WebUI.MvcHelper;
using OM.Business.Abstract;
using System.Collections.Generic;
using OM.Entity.Complex.Customer.Project;
using OM.Entity.Complex.DashBoard.Task;

namespace OM.WebUI.Areas.DashBoard.Controllers
{
    public class DashBoardController : Controller
    {
        private readonly IWorkBs _ws;
        private readonly IMeetBs _ms;
        private readonly ICustomerBs _cus;
        private readonly ITaskBs _ts;
        private readonly IUserBs _us;

        public DashBoardController(IWorkBs ws, IMeetBs ms, ICustomerBs cus, ITaskBs ts, IUserBs us)
        {
            _ws = ws;
            _ms = ms;
            _cus = cus;
            _ts = ts;
            _us = us;
        }

        public ActionResult Index()
        {
            if (SessionManager.ActiveUser.Id == 1002 || SessionManager.ActiveUser.Id == 1 || SessionManager.ActiveUser.Id == 5)
            {
                ViewBag.MeetCount = _ms.GetAll().Where(x => x.IsActive == true).Count();
                ViewBag.MeetCountDaily = _ms.GetAll().Where(x => x.IsActive == true && x.Created.Day == DateTime.Now.Day).Count();

                ViewBag.ProjectCount = _ws.GetAll().Where(x => x.IsActive == true).Count();
                ViewBag.ProjectCountDaily = _ws.GetAll().Where(x => x.IsActive == true && x.Created.Day == DateTime.Now.Day).Count();

                ViewBag.TotalPrice = Math.Round(_ws.GetAll().Where(x => x.IsActive == true && x.IsPay == true).Select(x => x.Price).Sum());
                ViewBag.TotalPriceDailyCavcu = Math.Round(_ws.GetAll().Where(x => x.IsActive == true && x.IsPay == true && x.CreatedBy == 6 && x.Created.Day == DateTime.Now.Day).Select(x => x.Price).Sum());
                ViewBag.TotalPriceDailyOorkun = Math.Round(_ws.GetAll().Where(x => x.IsActive == true && x.IsPay == true && x.CreatedBy == 7 && x.Created.Day == DateTime.Now.Day).Select(x => x.Price).Sum());
                ViewBag.TotalPriceDaily = Math.Round(_ws.GetAll().Where(x => x.IsActive == true && x.IsPay == true && x.CreatedBy == 6 || x.CreatedBy == 7 && x.Created.Day == DateTime.Now.Day).Select(x => x.Price).Sum());

                ViewBag.TotalPriceMonthCavcu = Math.Round(_ws.GetAll().Where(x => x.IsActive == true && x.IsPay == true && x.CreatedBy == 6 && x.Created.Month == DateTime.Now.Month).Select(x => x.Price).Sum());
                ViewBag.TotalPriceMonthCavcuJan = Math.Round(_ws.GetAll().Where(x => x.IsActive == true && x.IsPay == true && x.CreatedBy == 6 && x.Created.Month == 1).Select(x => x.Price).Sum());
                ViewBag.TotalPriceMonthCavcuFeb = Math.Round(_ws.GetAll().Where(x => x.IsActive == true && x.IsPay == true && x.CreatedBy == 6 && x.Created.Month == 2).Select(x => x.Price).Sum());
                ViewBag.TotalPriceMonthCavcuMar = Math.Round(_ws.GetAll().Where(x => x.IsActive == true && x.IsPay == true && x.CreatedBy == 6 && x.Created.Month == 3).Select(x => x.Price).Sum());
                ViewBag.TotalPriceMonthCavcuApr = Math.Round(_ws.GetAll().Where(x => x.IsActive == true && x.IsPay == true && x.CreatedBy == 6 && x.Created.Month == 4).Select(x => x.Price).Sum());
                ViewBag.TotalPriceMonthCavcuMay = Math.Round(_ws.GetAll().Where(x => x.IsActive == true && x.IsPay == true && x.CreatedBy == 6 && x.Created.Month == 5).Select(x => x.Price).Sum());
                ViewBag.TotalPriceMonthCavcuJune = Math.Round(_ws.GetAll().Where(x => x.IsActive == true && x.IsPay == true && x.CreatedBy == 6 && x.Created.Month == 6).Select(x => x.Price).Sum());
                ViewBag.TotalPriceMonthCavcuJuly = Math.Round(_ws.GetAll().Where(x => x.IsActive == true && x.IsPay == true && x.CreatedBy == 6 && x.Created.Month == 7).Select(x => x.Price).Sum());
                ViewBag.TotalPriceMonthCavcuAgus = Math.Round(_ws.GetAll().Where(x => x.IsActive == true && x.IsPay == true && x.CreatedBy == 6 && x.Created.Month == 8).Select(x => x.Price).Sum());
                ViewBag.TotalPriceMonthCavcuSep = Math.Round(_ws.GetAll().Where(x => x.IsActive == true && x.IsPay == true && x.CreatedBy == 6 && x.Created.Month == 9).Select(x => x.Price).Sum());
                ViewBag.TotalPriceMonthCavcuOct = Math.Round(_ws.GetAll().Where(x => x.IsActive == true && x.IsPay == true && x.CreatedBy == 6 && x.Created.Month == 10).Select(x => x.Price).Sum());
                ViewBag.TotalPriceMonthCavcuNov = Math.Round(_ws.GetAll().Where(x => x.IsActive == true && x.IsPay == true && x.CreatedBy == 6 && x.Created.Month == 11).Select(x => x.Price).Sum());
                ViewBag.TotalPriceMonthCavcuDec = Math.Round(_ws.GetAll().Where(x => x.IsActive == true && x.IsPay == true && x.CreatedBy == 6 && x.Created.Month == 12).Select(x => x.Price).Sum());

                ViewBag.TotalPriceMonthOorkun = Math.Round(_ws.GetAll().Where(x => x.IsActive == true && x.IsPay == true && x.CreatedBy == 7 && x.Created.Month == DateTime.Now.Month).Select(x => x.Price).Sum());
                ViewBag.TotalPriceMonthOorkunJan = Math.Round(_ws.GetAll().Where(x => x.IsActive == true && x.IsPay == true && x.CreatedBy == 7 && x.Created.Month == 1).Select(x => x.Price).Sum());
                ViewBag.TotalPriceMonthOorkunFeb = Math.Round(_ws.GetAll().Where(x => x.IsActive == true && x.IsPay == true && x.CreatedBy == 7 && x.Created.Month == 2).Select(x => x.Price).Sum());
                ViewBag.TotalPriceMonthOorkunMar = Math.Round(_ws.GetAll().Where(x => x.IsActive == true && x.IsPay == true && x.CreatedBy == 7 && x.Created.Month == 3).Select(x => x.Price).Sum());
                ViewBag.TotalPriceMonthOorkunApr = Math.Round(_ws.GetAll().Where(x => x.IsActive == true && x.IsPay == true && x.CreatedBy == 7 && x.Created.Month == 4).Select(x => x.Price).Sum());
                ViewBag.TotalPriceMonthOorkunMay = Math.Round(_ws.GetAll().Where(x => x.IsActive == true && x.IsPay == true && x.CreatedBy == 7 && x.Created.Month == 5).Select(x => x.Price).Sum());
                ViewBag.TotalPriceMonthOorkunJune = Math.Round(_ws.GetAll().Where(x => x.IsActive == true && x.IsPay == true && x.CreatedBy == 7 && x.Created.Month == 6).Select(x => x.Price).Sum());
                ViewBag.TotalPriceMonthOorkunJuly = Math.Round(_ws.GetAll().Where(x => x.IsActive == true && x.IsPay == true && x.CreatedBy == 7 && x.Created.Month == 7).Select(x => x.Price).Sum());
                ViewBag.TotalPriceMonthOorkunAgus = Math.Round(_ws.GetAll().Where(x => x.IsActive == true && x.IsPay == true && x.CreatedBy == 7 && x.Created.Month == 8).Select(x => x.Price).Sum());
                ViewBag.TotalPriceMonthOorkunSep = Math.Round(_ws.GetAll().Where(x => x.IsActive == true && x.IsPay == true && x.CreatedBy == 7 && x.Created.Month == 9).Select(x => x.Price).Sum());
                ViewBag.TotalPriceMonthOorkunOct = Math.Round(_ws.GetAll().Where(x => x.IsActive == true && x.IsPay == true && x.CreatedBy == 7 && x.Created.Month == 10).Select(x => x.Price).Sum());
                ViewBag.TotalPriceMonthOorkunNov = Math.Round(_ws.GetAll().Where(x => x.IsActive == true && x.IsPay == true && x.CreatedBy == 7 && x.Created.Month == 11).Select(x => x.Price).Sum());
                ViewBag.TotalPriceMonthOorkunDec = Math.Round(_ws.GetAll().Where(x => x.IsActive == true && x.IsPay == true && x.CreatedBy == 7 && x.Created.Month == 12).Select(x => x.Price).Sum());

                ViewBag.TotalPriceYearCavcu = Math.Round(_ws.GetAll().Where(x => x.IsActive == true && x.IsPay == true && x.CreatedBy == 6 && x.Created.Year == DateTime.Now.Year).Select(x => x.Price).Sum());
                ViewBag.TotalPriceYearCavcu2017 = Math.Round(_ws.GetAll().Where(x => x.IsActive == true && x.IsPay == true && x.CreatedBy == 6 && x.Created.Year == 2017).Select(x => x.Price).Sum());
                ViewBag.TotalPriceYearCavcu2018 = Math.Round(_ws.GetAll().Where(x => x.IsActive == true && x.IsPay == true && x.CreatedBy == 6 && x.Created.Year == 2018).Select(x => x.Price).Sum());
                ViewBag.TotalPriceYearCavcu2019 = Math.Round(_ws.GetAll().Where(x => x.IsActive == true && x.IsPay == true && x.CreatedBy == 6 && x.Created.Year == 2019).Select(x => x.Price).Sum());
                ViewBag.TotalPriceYearCavcu2020 = Math.Round(_ws.GetAll().Where(x => x.IsActive == true && x.IsPay == true && x.CreatedBy == 6 && x.Created.Year == 2020).Select(x => x.Price).Sum());

                ViewBag.TotalPriceYearOorkun = Math.Round(_ws.GetAll().Where(x => x.IsActive == true && x.IsPay == true && x.CreatedBy == 7 && x.Created.Year == DateTime.Now.Year).Select(x => x.Price).Sum());
                ViewBag.TotalPriceYearOorkun2017 = Math.Round(_ws.GetAll().Where(x => x.IsActive == true && x.IsPay == true && x.CreatedBy == 7 && x.Created.Year == 2017).Select(x => x.Price).Sum());
                ViewBag.TotalPriceYearOorkun2018 = Math.Round(_ws.GetAll().Where(x => x.IsActive == true && x.IsPay == true && x.CreatedBy == 7 && x.Created.Year == 2018).Select(x => x.Price).Sum());
                ViewBag.TotalPriceYearOorkun2019 = Math.Round(_ws.GetAll().Where(x => x.IsActive == true && x.IsPay == true && x.CreatedBy == 7 && x.Created.Year == 2019).Select(x => x.Price).Sum());
                ViewBag.TotalPriceYearOorkun2020 = Math.Round(_ws.GetAll().Where(x => x.IsActive == true && x.IsPay == true && x.CreatedBy == 7 && x.Created.Year == 2020).Select(x => x.Price).Sum());

                ViewBag.CustomerCount = _cus.GetAll().Where(x => x.IsActive == true).Count();
                ViewBag.CustomerCountDaily = _cus.GetAll().Where(x => x.IsActive == true && x.Created.Day == DateTime.Now.Day).Count();

                List<ProjectListVM> list = _ws.GetAll()
                    .Where(x => x.IsActive == true)
                    .OrderByDescending(x => x.Created)
                    .Select(x => new ProjectListVM()
                    {
                        Id = x.Id,
                        Personnel = x.Personnel,
                        Model = x.Model,
                        CompanyName = x.CompanyName,
                        StartDate = x.StartDate,
                        EndDate = x.EndDate,
                        BillDate = x.BillDate,
                        BillNumber = x.BillNumber,
                        Price = Math.Round(x.Price, 2),
                        IsPay = x.IsPay,
                        Description = x.Description,
                    }).ToList();
                return View(list);
            }

            else
            {
                ViewBag.MeetCount = _ms.GetAll().Where(x => x.IsActive == true && x.CreatedBy == SessionManager.ActiveUser.Id).Count();
                ViewBag.MeetCountDaily = _ms.GetAll().Where(x => x.IsActive == true && x.Created.Day == DateTime.Now.Day && x.CreatedBy == SessionManager.ActiveUser.Id).Count();

                ViewBag.ProjectCount = _ws.GetAll().Where(x => x.IsActive == true && x.CreatedBy == SessionManager.ActiveUser.Id).Count();
                ViewBag.ProjectCountDaily = _ws.GetAll().Where(x => x.IsActive == true && x.Created.Day == DateTime.Now.Day && x.CreatedBy == SessionManager.ActiveUser.Id).Count();

                ViewBag.TotalPrice = Math.Round(_ws.GetAll().Where(x => x.IsActive == true && x.IsPay == true && x.CreatedBy == SessionManager.ActiveUser.Id).Select(x => x.Price).Sum());
                ViewBag.TotalPriceDailyCavcu = Math.Round(_ws.GetAll().Where(x => x.IsActive == true && x.IsPay == true && x.CreatedBy == 6 && x.Created.Day == DateTime.Now.Day).Select(x => x.Price).Sum());
                ViewBag.TotalPriceDailyOorkun = Math.Round(_ws.GetAll().Where(x => x.IsActive == true && x.IsPay == true && x.CreatedBy == 7 && x.Created.Day == DateTime.Now.Day).Select(x => x.Price).Sum());
                ViewBag.TotalPriceDaily = Math.Round(_ws.GetAll().Where(x => x.IsActive == true && x.IsPay == true && x.CreatedBy == 6 || x.CreatedBy == 7 && x.Created.Day == DateTime.Now.Day).Select(x => x.Price).Sum());

                ViewBag.TotalPriceMonthCavcu = Math.Round(_ws.GetAll().Where(x => x.IsActive == true && x.IsPay == true && x.CreatedBy == 6 && x.Created.Month == DateTime.Now.Month).Select(x => x.Price).Sum());
                ViewBag.TotalPriceMonthCavcuJan = Math.Round(_ws.GetAll().Where(x => x.IsActive == true && x.IsPay == true && x.CreatedBy == 6 && x.Created.Month == 1).Select(x => x.Price).Sum());
                ViewBag.TotalPriceMonthCavcuFeb = Math.Round(_ws.GetAll().Where(x => x.IsActive == true && x.IsPay == true && x.CreatedBy == 6 && x.Created.Month == 2).Select(x => x.Price).Sum());
                ViewBag.TotalPriceMonthCavcuMar = Math.Round(_ws.GetAll().Where(x => x.IsActive == true && x.IsPay == true && x.CreatedBy == 6 && x.Created.Month == 3).Select(x => x.Price).Sum());
                ViewBag.TotalPriceMonthCavcuApr = Math.Round(_ws.GetAll().Where(x => x.IsActive == true && x.IsPay == true && x.CreatedBy == 6 && x.Created.Month == 4).Select(x => x.Price).Sum());
                ViewBag.TotalPriceMonthCavcuMay = Math.Round(_ws.GetAll().Where(x => x.IsActive == true && x.IsPay == true && x.CreatedBy == 6 && x.Created.Month == 5).Select(x => x.Price).Sum());
                ViewBag.TotalPriceMonthCavcuJune = Math.Round(_ws.GetAll().Where(x => x.IsActive == true && x.IsPay == true && x.CreatedBy == 6 && x.Created.Month == 6).Select(x => x.Price).Sum());
                ViewBag.TotalPriceMonthCavcuJuly = Math.Round(_ws.GetAll().Where(x => x.IsActive == true && x.IsPay == true && x.CreatedBy == 6 && x.Created.Month == 7).Select(x => x.Price).Sum());
                ViewBag.TotalPriceMonthCavcuAgus = Math.Round(_ws.GetAll().Where(x => x.IsActive == true && x.IsPay == true && x.CreatedBy == 6 && x.Created.Month == 8).Select(x => x.Price).Sum());
                ViewBag.TotalPriceMonthCavcuSep = Math.Round(_ws.GetAll().Where(x => x.IsActive == true && x.IsPay == true && x.CreatedBy == 6 && x.Created.Month == 9).Select(x => x.Price).Sum());
                ViewBag.TotalPriceMonthCavcuOct = Math.Round(_ws.GetAll().Where(x => x.IsActive == true && x.IsPay == true && x.CreatedBy == 6 && x.Created.Month == 10).Select(x => x.Price).Sum());
                ViewBag.TotalPriceMonthCavcuNov = Math.Round(_ws.GetAll().Where(x => x.IsActive == true && x.IsPay == true && x.CreatedBy == 6 && x.Created.Month == 11).Select(x => x.Price).Sum());
                ViewBag.TotalPriceMonthCavcuDec = Math.Round(_ws.GetAll().Where(x => x.IsActive == true && x.IsPay == true && x.CreatedBy == 6 && x.Created.Month == 12).Select(x => x.Price).Sum());

                ViewBag.TotalPriceMonthOorkun = Math.Round(_ws.GetAll().Where(x => x.IsActive == true && x.IsPay == true && x.CreatedBy == 7 && x.Created.Month == DateTime.Now.Month).Select(x => x.Price).Sum());
                ViewBag.TotalPriceMonthOorkunJan = Math.Round(_ws.GetAll().Where(x => x.IsActive == true && x.IsPay == true && x.CreatedBy == 7 && x.Created.Month == 1).Select(x => x.Price).Sum());
                ViewBag.TotalPriceMonthOorkunFeb = Math.Round(_ws.GetAll().Where(x => x.IsActive == true && x.IsPay == true && x.CreatedBy == 7 && x.Created.Month == 2).Select(x => x.Price).Sum());
                ViewBag.TotalPriceMonthOorkunMar = Math.Round(_ws.GetAll().Where(x => x.IsActive == true && x.IsPay == true && x.CreatedBy == 7 && x.Created.Month == 3).Select(x => x.Price).Sum());
                ViewBag.TotalPriceMonthOorkunApr = Math.Round(_ws.GetAll().Where(x => x.IsActive == true && x.IsPay == true && x.CreatedBy == 7 && x.Created.Month == 4).Select(x => x.Price).Sum());
                ViewBag.TotalPriceMonthOorkunMay = Math.Round(_ws.GetAll().Where(x => x.IsActive == true && x.IsPay == true && x.CreatedBy == 7 && x.Created.Month == 5).Select(x => x.Price).Sum());
                ViewBag.TotalPriceMonthOorkunJune = Math.Round(_ws.GetAll().Where(x => x.IsActive == true && x.IsPay == true && x.CreatedBy == 7 && x.Created.Month == 6).Select(x => x.Price).Sum());
                ViewBag.TotalPriceMonthOorkunJuly = Math.Round(_ws.GetAll().Where(x => x.IsActive == true && x.IsPay == true && x.CreatedBy == 7 && x.Created.Month == 7).Select(x => x.Price).Sum());
                ViewBag.TotalPriceMonthOorkunAgus = Math.Round(_ws.GetAll().Where(x => x.IsActive == true && x.IsPay == true && x.CreatedBy == 7 && x.Created.Month == 8).Select(x => x.Price).Sum());
                ViewBag.TotalPriceMonthOorkunSep = Math.Round(_ws.GetAll().Where(x => x.IsActive == true && x.IsPay == true && x.CreatedBy == 7 && x.Created.Month == 9).Select(x => x.Price).Sum());
                ViewBag.TotalPriceMonthOorkunOct = Math.Round(_ws.GetAll().Where(x => x.IsActive == true && x.IsPay == true && x.CreatedBy == 7 && x.Created.Month == 10).Select(x => x.Price).Sum());
                ViewBag.TotalPriceMonthOorkunNov = Math.Round(_ws.GetAll().Where(x => x.IsActive == true && x.IsPay == true && x.CreatedBy == 7 && x.Created.Month == 11).Select(x => x.Price).Sum());
                ViewBag.TotalPriceMonthOorkunDec = Math.Round(_ws.GetAll().Where(x => x.IsActive == true && x.IsPay == true && x.CreatedBy == 7 && x.Created.Month == 12).Select(x => x.Price).Sum());

                ViewBag.TotalPriceYearCavcu = Math.Round(_ws.GetAll().Where(x => x.IsActive == true && x.IsPay == true && x.CreatedBy == 6 && x.Created.Year == DateTime.Now.Year).Select(x => x.Price).Sum());
                ViewBag.TotalPriceYearCavcu2017 = Math.Round(_ws.GetAll().Where(x => x.IsActive == true && x.IsPay == true && x.CreatedBy == 6 && x.Created.Year == 2017).Select(x => x.Price).Sum());
                ViewBag.TotalPriceYearCavcu2018 = Math.Round(_ws.GetAll().Where(x => x.IsActive == true && x.IsPay == true && x.CreatedBy == 6 && x.Created.Year == 2018).Select(x => x.Price).Sum());
                ViewBag.TotalPriceYearCavcu2019 = Math.Round(_ws.GetAll().Where(x => x.IsActive == true && x.IsPay == true && x.CreatedBy == 6 && x.Created.Year == 2019).Select(x => x.Price).Sum());
                ViewBag.TotalPriceYearCavcu2020 = Math.Round(_ws.GetAll().Where(x => x.IsActive == true && x.IsPay == true && x.CreatedBy == 6 && x.Created.Year == 2020).Select(x => x.Price).Sum());

                ViewBag.TotalPriceYearOorkun = Math.Round(_ws.GetAll().Where(x => x.IsActive == true && x.IsPay == true && x.CreatedBy == 7 && x.Created.Year == DateTime.Now.Year).Select(x => x.Price).Sum());
                ViewBag.TotalPriceYearOorkun2017 = Math.Round(_ws.GetAll().Where(x => x.IsActive == true && x.IsPay == true && x.CreatedBy == 7 && x.Created.Year == 2017).Select(x => x.Price).Sum());
                ViewBag.TotalPriceYearOorkun2018 = Math.Round(_ws.GetAll().Where(x => x.IsActive == true && x.IsPay == true && x.CreatedBy == 7 && x.Created.Year == 2018).Select(x => x.Price).Sum());
                ViewBag.TotalPriceYearOorkun2019 = Math.Round(_ws.GetAll().Where(x => x.IsActive == true && x.IsPay == true && x.CreatedBy == 7 && x.Created.Year == 2019).Select(x => x.Price).Sum());
                ViewBag.TotalPriceYearOorkun2020 = Math.Round(_ws.GetAll().Where(x => x.IsActive == true && x.IsPay == true && x.CreatedBy == 7 && x.Created.Year == 2020).Select(x => x.Price).Sum());

                ViewBag.CustomerCount = _cus.GetAll().Where(x => x.IsActive == true && x.CreatedBy == SessionManager.ActiveUser.Id).Count();
                ViewBag.CustomerCountDaily = _cus.GetAll().Where(x => x.IsActive == true && x.Created.Day == DateTime.Now.Day && x.CreatedBy == SessionManager.ActiveUser.Id).Count();

                List<ProjectListVM> list = _ws.GetAll()
                    .Where(x => x.IsActive == true && x.CreatedBy == SessionManager.ActiveUser.Id)
                    .OrderByDescending(x => x.Created)
                    .Select(x => new ProjectListVM()
                    {
                        Id = x.Id,
                        Personnel = x.Personnel,
                        Model = x.Model,
                        CompanyName = x.CompanyName,
                        StartDate = x.StartDate,
                        EndDate = x.EndDate,
                        BillDate = x.BillDate,
                        BillNumber = x.BillNumber,
                        Price = Math.Round(x.Price, 2),
                        IsPay = x.IsPay,
                        Description = x.Description,
                    }).ToList();
                return View(list);
            }
        }

        public ActionResult Agenda()
        {
            return View();
        }

        public ActionResult Map()
        {
            return View();
        }

        #region Task Task CRUD

        public ActionResult Task()
        {
            if (SessionManager.ActiveUser.Id == 1 || SessionManager.ActiveUser.Id == 5)
            {
                List<TaskListVM> list = _ts.GetAll()
                    .Where(x => x.IsActive == true)
                    .OrderByDescending(x => x.Modified)
                    .Select(x => new TaskListVM()
                    {
                        Id = x.Id,
                        UserId = x.UserId,
                        FromAss = _us.GetAll()
                                        .Where(y => y.Id == x.CreatedBy)
                                        .Select(y => y.Photo)
                                        .FirstOrDefault(),
                        ToAss = _us.GetAll()
                                        .Where(y => y.Id == x.UserId)
                                        .Select(y => y.Photo)
                                        .FirstOrDefault(),
                        Created = x.Created,
                        Name = x.Name,
                        State = x.State,
                        Modified = x.Modified,
                        Description = x.Description,
                        ShowToAss = true,
                        ShowFromAss = true
                    }).ToList();
                return View(list);
            }

            else if (SessionManager.ActiveUser.Id == 6 || SessionManager.ActiveUser.Id == 7 || SessionManager.ActiveUser.Id == 1002 || SessionManager.ActiveUser.Id == 1003)
            {
                List<TaskListVM> list = _ts.GetAll()
                    .Where(x => x.IsActive == true && x.CreatedBy == SessionManager.ActiveUser.Id || x.ToAss == SessionManager.ActiveUser.Photo)
                    .OrderByDescending(x => x.Created)
                    .Select(x => new TaskListVM()
                    {
                        Id = x.Id,
                        UserId = x.UserId,
                        FromAss = _us.GetAll()
                                        .Where(y => y.Id == x.CreatedBy)
                                        .Select(y => y.Photo)
                                        .FirstOrDefault(),
                        ToAss = _us.GetAll()
                                        .Where(y => y.Id == x.UserId)
                                        .Select(y => y.Photo)
                                        .FirstOrDefault(),
                        Created = x.Created,
                        Name = x.Name,
                        State = x.State,
                        Modified = x.Modified,
                        Description = x.Description,
                        ShowToAss = true,
                        ShowFromAss = false
                    }).ToList();
                return View(list);
            }

            else
            {
                List<TaskListVM> list = _ts.GetAll()
                    .Where(x => x.IsActive == true && x.CreatedBy != SessionManager.ActiveUser.Id)
                    .OrderByDescending(x => x.Created)
                    .Select(x => new TaskListVM()
                    {
                        Id = x.Id,
                        UserId = x.UserId,
                        FromAss = _us.GetAll()
                                        .Where(y => y.Id == x.CreatedBy)
                                        .Select(y => y.Photo)
                                        .FirstOrDefault(),
                        ToAss = _us.GetAll()
                                        .Where(y => y.Id == x.UserId)
                                        .Select(y => y.Photo)
                                        .FirstOrDefault(),
                        Created = x.Created,
                        Name = x.Name,
                        State = x.State,
                        Modified = x.Modified,
                        Description = x.Description,
                        ShowToAss = false,
                        ShowFromAss = true
                    }).ToList();
                return View(list);
            }
        }

        [HttpPost]
        public JsonResult CreateTask(CreateTaskVM vm)
        {
            try
            {
                Task newTask = new Task();
                newTask.Created = DateTime.Now;
                newTask.CreatedBy = SessionManager.ActiveUser.Id;
                newTask.Modified = DateTime.Now;
                newTask.ModifiedBy = SessionManager.ActiveUser.Id;
                newTask.IsActive = true;

                newTask.Name = vm.Name;
                newTask.State = false;
                newTask.Description = "Bekleniyor";
                newTask.UserId = vm.UserId;
                newTask.FromAss = SessionManager.ActiveUser.Photo;
                newTask.ToAss = _us.GetAll()
                                    .Where(x => x.Id == newTask.UserId)
                                    .Select(x => x.Photo)
                                    .FirstOrDefault();

                _ts.Insert(newTask);

                return Json(new { Result = true, Message = "Görev Başarıyla Kaydedildi." });
            }
            catch (Exception ex)
            {
                return Json(new { Result = false, ex.Message });
            }
        }

        [HttpPost]
        public JsonResult UpdateTask(UpdateTaskVM vm)
        {
            try
            {
                Task task = _ts.GetById(vm.Id);
                task.Modified = DateTime.Now;
                task.ModifiedBy = SessionManager.ActiveUser.Id;

                task.Name = vm.Name;
                task.State = vm.State;
                task.Description = vm.Description;

                _ts.Update(task);

                return Json(new { Result = true, Message = "Görev Başarıyla Güncellendi" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = false, ex.Message });
            }
        }

        public JsonResult DeleteTask(DeleteTaskVM vm)
        {
            try
            {
                Task task = _ts.GetById(vm.Id);
                task.IsActive = false;
                task.Modified = DateTime.Now;
                task.ModifiedBy = SessionManager.ActiveUser.Id;

                _ts.Update(task);

                return Json(new { Result = true });
            }
            catch (Exception ex)
            {
                return Json(new { Result = false, ex.Message });
            }
        }

        #endregion
    }
}