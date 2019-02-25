using System;
using System.Linq;
using System.Web.Mvc;
using OM.Entity.Domain;
using OM.WebUI.MvcHelper;
using OM.Business.Abstract;
using System.Collections.Generic;
using OM.Entity.Complex.Expense;

namespace OM.WebUI.Areas.DashBoard.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly IExpenseBs _es;

        public ExpenseController(IExpenseBs es)
        {
            _es = es;
        }

        #region Personnel Expense CRUD

        public ActionResult Personnel()
        {
            if (SessionManager.ActiveUser.Id == 1002 || SessionManager.ActiveUser.Id == 1 || SessionManager.ActiveUser.Id == 5)
            {
                List<ExpenseListVM> list = _es.GetAll()
                .Where(x => x.IsActive == true && x.Type == "Personnel")
                .OrderByDescending(x => x.Created)
                .Select(x => new ExpenseListVM()
                {
                    Id = x.Id,
                    ProcessDate = x.ProcessDate,
                    Process = x.Process,
                    CompanyName = x.CompanyName,
                    PayDate = x.PayDate,
                    Price = Math.Round(x.Price, 2),
                    Description = x.Description
                }).ToList();
                return View(list);
            }

            else
            {
                List<ExpenseListVM> list = _es.GetAll()
                .Where(x => x.IsActive == true && x.Type == "Personnel" && x.CreatedBy == SessionManager.ActiveUser.Id)
                .OrderByDescending(x => x.Created)
                .Select(x => new ExpenseListVM()
                {
                    Id = x.Id,
                    ProcessDate = x.ProcessDate,
                    Process = x.Process,
                    CompanyName = x.CompanyName,
                    PayDate = x.PayDate,
                    Price = Math.Round(x.Price, 2),
                    Description = x.Description
                }).ToList();
                return View(list);
            }
        }

        [HttpPost]
        public JsonResult CreatePersonnel(CreateExpenseVM vm)
        {
            try
            {
                Expense newPersonnel = new Expense();
                newPersonnel.Created = DateTime.Now;
                newPersonnel.CreatedBy = SessionManager.ActiveUser.Id;
                newPersonnel.Modified = DateTime.Now;
                newPersonnel.ModifiedBy = SessionManager.ActiveUser.Id;
                newPersonnel.IsActive = true;

                newPersonnel.Type = "Personnel";
                newPersonnel.ProcessDate = vm.ProcessDate;
                newPersonnel.Process = vm.Process;
                newPersonnel.CompanyName = vm.CompanyName;
                newPersonnel.PayDate = vm.PayDate;
                newPersonnel.Price = Math.Round(vm.Price, 2);
                newPersonnel.Description = vm.Description;

                _es.Insert(newPersonnel);

                return Json(new { Result = true, Message = "Personel Gideri Başarıyla Kaydedildi." });
            }
            catch (Exception ex)
            {
                return Json(new { Result = false, ex.Message });
            }
        }

        [HttpPost]
        public JsonResult UpdatePersonnel(UpdateExpenseVM vm)
        {
            try
            {
                Expense personnel = _es.GetById(vm.Id);
                personnel.Modified = DateTime.Now;
                personnel.ModifiedBy = SessionManager.ActiveUser.Id;

                personnel.CompanyName = vm.CompanyName;
                personnel.ProcessDate = vm.ProcessDate;
                personnel.Process = vm.Process;
                personnel.CompanyName = vm.CompanyName;
                personnel.PayDate = vm.PayDate;
                personnel.Price = Math.Round(vm.Price, 2);
                personnel.Description = vm.Description;

                _es.Update(personnel);

                return Json(new { Result = true, Message = "Personel Gideri Başarıyla Güncellendi" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = false, ex.Message });
            }
        }

        public JsonResult DeletePersonnel(DeleteExpenseVM vm)
        {
            try
            {
                Expense personnel = _es.GetById(vm.Id);
                personnel.IsActive = false;
                personnel.Modified = DateTime.Now;
                personnel.ModifiedBy = SessionManager.ActiveUser.Id;

                _es.Update(personnel);

                return Json(new { Result = true });
            }
            catch (Exception ex)
            {
                return Json(new { Result = false, ex.Message });
            }
        }

        #endregion

        #region Machine Expense CRUD

        public ActionResult Machine()
        {
            if (SessionManager.ActiveUser.Id == 1002 || SessionManager.ActiveUser.Id == 1 || SessionManager.ActiveUser.Id == 5)
            {
                List<ExpenseListVM> list = _es.GetAll()
                .Where(x => x.IsActive == true && x.Type == "Machine")
                .OrderByDescending(x => x.Created)
                .Select(x => new ExpenseListVM()
                {
                    Id = x.Id,
                    ProcessDate = x.ProcessDate,
                    Process = x.Process,
                    CompanyName = x.CompanyName,
                    PayDate = x.PayDate,
                    Price = Math.Round(x.Price, 2),
                    Description = x.Description
                }).ToList();
                return View(list);
            }

            else
            {
                List<ExpenseListVM> list = _es.GetAll()
                .Where(x => x.IsActive == true && x.Type == "Machine" && x.CreatedBy == SessionManager.ActiveUser.Id)
                .OrderByDescending(x => x.Created)
                .Select(x => new ExpenseListVM()
                {
                    Id = x.Id,
                    ProcessDate = x.ProcessDate,
                    Process = x.Process,
                    CompanyName = x.CompanyName,
                    PayDate = x.PayDate,
                    Price = Math.Round(x.Price, 2),
                    Description = x.Description
                }).ToList();
                return View(list);
            }
        }

        [HttpPost]
        public JsonResult CreateMachine(CreateExpenseVM vm)
        {
            try
            {
                Expense newExpense = new Expense();
                newExpense.Created = DateTime.Now;
                newExpense.CreatedBy = SessionManager.ActiveUser.Id;
                newExpense.Modified = DateTime.Now;
                newExpense.ModifiedBy = SessionManager.ActiveUser.Id;
                newExpense.IsActive = true;

                newExpense.Type = "Machine";
                newExpense.ProcessDate = vm.ProcessDate;
                newExpense.Process = vm.Process;
                newExpense.CompanyName = vm.CompanyName;
                newExpense.PayDate = vm.PayDate;
                newExpense.Price = Math.Round(vm.Price, 2);
                newExpense.Description = vm.Description;

                _es.Insert(newExpense);

                return Json(new { Result = true, Message = "Makina Gideri Başarıyla Kaydedildi." });
            }
            catch (Exception ex)
            {
                return Json(new { Result = false, ex.Message });
            }
        }

        [HttpPost]
        public JsonResult UpdateMachine(UpdateExpenseVM vm)
        {
            try
            {
                Expense expense = _es.GetById(vm.Id);
                expense.Modified = DateTime.Now;
                expense.ModifiedBy = SessionManager.ActiveUser.Id;

                expense.CompanyName = vm.CompanyName;
                expense.ProcessDate = vm.ProcessDate;
                expense.Process = vm.Process;
                expense.CompanyName = vm.CompanyName;
                expense.PayDate = vm.PayDate;
                expense.Price = Math.Round(vm.Price, 2);
                expense.Description = vm.Description;

                _es.Update(expense);

                return Json(new { Result = true, Message = "Makina Gideri Başarıyla Güncellendi" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = false, ex.Message });
            }
        }

        public JsonResult DeleteMachine(DeleteExpenseVM vm)
        {
            try
            {
                Expense expense = _es.GetById(vm.Id);
                expense.IsActive = false;
                expense.Modified = DateTime.Now;
                expense.ModifiedBy = SessionManager.ActiveUser.Id;

                _es.Update(expense);

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