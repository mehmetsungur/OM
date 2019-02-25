using System;
using System.IO;
using System.Web;
using System.Linq;
using System.Web.Mvc;
using OM.Entity.Domain;
using OM.WebUI.MvcHelper;
using OM.Business.Abstract;
using OIT.Core.Utilities.Common;
using System.Collections.Generic;
using OM.Entity.Complex.Customer.Meet;
using OM.Entity.Complex.Customer.Company;
using OM.Entity.Complex.Customer.Project;
using OM.Entity.Complex.Customer.Portfolio;

namespace OM.WebUI.Areas.DashBoard.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICompanyBs _cs;
        private readonly IMeetBs _ms;
        private readonly ICustomerBs _cus;
        private readonly IWorkBs _ws;

        public CustomerController(ICompanyBs cs, IMeetBs ms, ICustomerBs cus, IWorkBs ws)
        {
            _cs = cs;
            _ms = ms;
            _cus = cus;
            _ws = ws;
        }

        #region Company CRUD

        public ActionResult Company()
        {
            if (SessionManager.ActiveUser.Id == 1002 || SessionManager.ActiveUser.Id == 1 || SessionManager.ActiveUser.Id == 5)
            {
                List<CompanyListVM> list = _cs.GetAll()
                .Where(x => x.IsActive == true)
                .OrderByDescending(x => x.Created)
                .Select(x => new CompanyListVM()
                {
                    Id = x.Id,
                    Logo = x.Logo,
                    Name = x.Name,
                    District = x.District,
                    City = x.City,
                    Description = x.Description,
                    Email = x.Email,
                    State = x.State,
                    Phone = x.Phone
                }).ToList();
                return View(list);
            }
            else
            {
                List<CompanyListVM> list = _cs.GetAll()
                    .Where(x => x.IsActive == true && x.CreatedBy == SessionManager.ActiveUser.Id)
                    .OrderByDescending(x => x.Created)
                    .Select(x => new CompanyListVM()
                    {
                        Id = x.Id,
                        Logo = x.Logo,
                        Name = x.Name,
                        District = x.District,
                        City = x.City,
                        Description = x.Description,
                        Email = x.Email,
                        State = x.State,
                        Phone = x.Phone
                    }).ToList();
                return View(list);
            }
        }

        [HttpPost]
        public JsonResult CreateCompany(CreateCompanyVM vm)
        {
            try
            {
                Company newCompany = new Company();
                newCompany.Created = DateTime.Now;
                newCompany.CreatedBy = SessionManager.ActiveUser.Id;
                newCompany.Modified = DateTime.Now;
                newCompany.ModifiedBy = SessionManager.ActiveUser.Id;
                newCompany.IsActive = true;

                newCompany.Logo = vm.Logo;
                newCompany.Name = vm.Name;
                newCompany.City = vm.City;
                newCompany.District = vm.District;
                newCompany.Email = vm.Email;
                newCompany.Phone = vm.Phone;
                newCompany.State = vm.State;
                newCompany.Description = vm.Description;

                _cs.Insert(newCompany);

                return Json(new { Result = true, Message = "Şirket Başarıyla Kaydedildi." });
            }
            catch (Exception ex)
            {
                return Json(new { Result = false, ex.Message });
            }
        }

        [HttpPost]
        public JsonResult UpdateCompany(UpdateCompanyVM vm)
        {
            try
            {
                Company company = _cs.GetById(vm.Id);
                company.Modified = DateTime.Now;
                company.ModifiedBy = SessionManager.ActiveUser.Id;

                company.Name = vm.Name;
                company.City = vm.City;
                company.District = vm.District;
                company.Email = vm.Email;
                company.Phone = vm.Phone;
                company.State = vm.State;
                company.Description = vm.Description;

                _cs.Update(company);

                return Json(new { Result = true, Message = "Şirket Başarıyla Güncellendi" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = false, ex.Message });
            }
        }

        public JsonResult UploadCompanyLogo()
        {
            try
            {
                HttpFileCollectionBase col = Request.Files;
                if (col != null)
                {
                    HttpPostedFileBase hpf = col[0];
                    string path = "~/Areas/DashBoard/Content/img/Custom/Company/";
                    string extension = Path.GetExtension(hpf.FileName);
                    string fileName = RandomValueGenerator.GenerateRandomGuid(15) + extension;
                    string logoPath = path + fileName;
                    hpf.SaveAs(Server.MapPath(logoPath));

                    return Json(new { Result = true, Logo = logoPath.Remove(0, 1) });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = false, ex.Message });
            }


            return Json(new { Result = false, });
        }

        public JsonResult DeleteCompany(DeleteCompanyVM vm)
        {
            try
            {
                Company company = _cs.GetById(vm.Id);
                company.IsActive = false;
                company.Modified = DateTime.Now;
                company.ModifiedBy = SessionManager.ActiveUser.Id;

                _cs.Update(company);

                return Json(new { Result = true });
            }
            catch (Exception ex)
            {
                return Json(new { Result = false, ex.Message });
            }
        }

        #endregion

        #region Customer CRUD

        public ActionResult Customer()
        {
            if (SessionManager.ActiveUser.Id == 1002 || SessionManager.ActiveUser.Id == 1 || SessionManager.ActiveUser.Id == 5)
            {
                List<CustomerListVM> list = _cus.GetAll()
                .Where(x => x.IsActive == true)
                .OrderByDescending(x => x.Created)
                .Select(x => new CustomerListVM()
                {
                    Id = x.Id,
                    Created = x.Created,
                    CompanyName = x.CompanyName,
                    Contact = x.Contact,
                    Caption = x.Caption,
                    City = x.City,
                    District = x.District,
                    Email = x.Email,
                    Phone = x.Phone,
                    Description = x.Description
                }).ToList();
                return View(list);
            }
            else
            {
                List<CustomerListVM> list = _cus.GetAll()
                .Where(x => x.IsActive == true && x.CreatedBy == SessionManager.ActiveUser.Id)
                .OrderByDescending(x => x.Created)
                .Select(x => new CustomerListVM()
                {
                    Id = x.Id,
                    Created = x.Created,
                    CompanyName = x.CompanyName,
                    Contact = x.Contact,
                    Caption = x.Caption,
                    City = x.City,
                    District = x.District,
                    Email = x.Email,
                    Phone = x.Phone,
                    Description = x.Description
                }).ToList();
                return View(list);
            }
        }

        [HttpPost]
        public JsonResult CreateCustomer(CreateCustomerVM vm)
        {
            try
            {
                Customer newCustomer = new Customer();
                newCustomer.Created = DateTime.Now;
                newCustomer.CreatedBy = SessionManager.ActiveUser.Id;
                newCustomer.Modified = DateTime.Now;
                newCustomer.ModifiedBy = SessionManager.ActiveUser.Id;
                newCustomer.IsActive = true;

                newCustomer.CompanyName = vm.CompanyName;
                newCustomer.Contact = vm.Contact;
                newCustomer.Caption = vm.Caption;
                newCustomer.City = vm.City;
                newCustomer.District = vm.District;
                newCustomer.Email = vm.Email;
                newCustomer.Phone = vm.Phone;
                newCustomer.Description = vm.Description;

                _cus.Insert(newCustomer);

                return Json(new { Result = true, Message = "Müşteri Başarıyla Kaydedildi." });
            }
            catch (Exception ex)
            {
                return Json(new { Result = false, ex.Message });
            }
        }

        [HttpPost]
        public JsonResult UpdateCustomer(UpdateCustomerVM vm)
        {
            try
            {
                Customer customer = _cus.GetById(vm.Id);
                customer.Modified = DateTime.Now;
                customer.ModifiedBy = SessionManager.ActiveUser.Id;

                customer.CompanyName = vm.CompanyName;
                customer.Contact = vm.Contact;
                customer.Caption = vm.Caption;
                customer.City = vm.City;
                customer.District = vm.District;
                customer.Email = vm.Email;
                customer.Phone = vm.Phone;
                customer.Description = vm.Description;

                _cus.Update(customer);

                return Json(new { Result = true, Message = "Müşteri Başarıyla Güncellendi" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = false, ex.Message });
            }
        }

        public JsonResult DeleteCustomer(DeleteCustomerVM vm)
        {
            try
            {
                Customer customer = _cus.GetById(vm.Id);
                customer.IsActive = false;
                customer.Modified = DateTime.Now;
                customer.ModifiedBy = SessionManager.ActiveUser.Id;

                _cus.Update(customer);

                return Json(new { Result = true });
            }
            catch (Exception ex)
            {
                return Json(new { Result = false, ex.Message });
            }
        }

        #endregion

        #region Meet CRUD

        public ActionResult Meet()
        {
            if (SessionManager.ActiveUser.Id == 1002 || SessionManager.ActiveUser.Id == 1 || SessionManager.ActiveUser.Id == 5)
            {
                List<MeetListVM> list = _ms.GetAll()
                .Where(x => x.IsActive == true)
                .OrderByDescending(x => x.Created)
                .Select(x => new MeetListVM()
                {
                    Id = x.Id,
                    Created = x.Created,
                    CompanyName = x.CompanyName,
                    Contact = x.Contact,
                    Caption = x.Caption,
                    Type = x.Type,
                    City = x.City,
                    District = x.District,
                    Email = x.Email,
                    Phone = x.Phone,
                    Description = x.Description
                }).ToList();
                return View(list);
            }
            else
            {
                List<MeetListVM> list = _ms.GetAll()
                .Where(x => x.IsActive == true && x.CreatedBy == SessionManager.ActiveUser.Id)
                .OrderByDescending(x => x.Created)
                .Select(x => new MeetListVM()
                {
                    Id = x.Id,
                    Created = x.Created,
                    CompanyName = x.CompanyName,
                    Contact = x.Contact,
                    Caption = x.Caption,
                    Type = x.Type,
                    City = x.City,
                    District = x.District,
                    Email = x.Email,
                    Phone = x.Phone,
                    Description = x.Description
                }).ToList();
                return View(list);
            }
        }

        [HttpPost]
        public JsonResult CreateMeet(CreateMeetVM vm)
        {
            try
            {
                Meet newMeet = new Meet();
                newMeet.Created = DateTime.Now;
                newMeet.CreatedBy = SessionManager.ActiveUser.Id;
                newMeet.Modified = DateTime.Now;
                newMeet.ModifiedBy = SessionManager.ActiveUser.Id;
                newMeet.IsActive = true;

                newMeet.Type = vm.Type;
                newMeet.CompanyName = vm.CompanyName;
                newMeet.Contact = vm.Contact;
                newMeet.Caption = vm.Caption;
                newMeet.City = vm.City;
                newMeet.District = vm.District;
                newMeet.Email = vm.Email;
                newMeet.Phone = vm.Phone;
                newMeet.Description = vm.Description;

                _ms.Insert(newMeet);

                return Json(new { Result = true, Message = "Görüşme Başarıyla Kaydedildi." });
            }
            catch (Exception ex)
            {
                return Json(new { Result = false, ex.Message });
            }
        }

        [HttpPost]
        public JsonResult UpdateMeet(UpdateMeetVM vm)
        {
            try
            {
                Meet meet = _ms.GetById(vm.Id);
                meet.Modified = DateTime.Now;
                meet.ModifiedBy = SessionManager.ActiveUser.Id;

                meet.Type = vm.Type;
                meet.CompanyName = vm.CompanyName;
                meet.Contact = vm.Contact;
                meet.Caption = vm.Caption;
                meet.City = vm.City;
                meet.District = vm.District;
                meet.Email = vm.Email;
                meet.Phone = vm.Phone;
                meet.Description = vm.Description;

                _ms.Update(meet);

                return Json(new { Result = true, Message = "Görüşme Başarıyla Güncellendi" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = false, ex.Message });
            }
        }

        public JsonResult DeleteMeet(DeleteMeetVM vm)
        {
            try
            {
                Meet meet = _ms.GetById(vm.Id);
                meet.IsActive = false;
                meet.Modified = DateTime.Now;
                meet.ModifiedBy = SessionManager.ActiveUser.Id;

                _ms.Update(meet);

                return Json(new { Result = true });
            }
            catch (Exception ex)
            {
                return Json(new { Result = false, ex.Message });
            }
        }

        #endregion

        #region Project CRUD

        public ActionResult Project()
        {
            if (SessionManager.ActiveUser.Id == 1002 || SessionManager.ActiveUser.Id == 1 || SessionManager.ActiveUser.Id == 5)
            {
                List<ProjectListVM> list = _ws.GetAll()
                .Where(x => x.IsActive == true)
                .OrderByDescending(x => x.Created)
                .Select(x => new ProjectListVM()
                {
                    Id = x.Id,
                    CompanyName = x.CompanyName,
                    Model = x.Model,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    BillDate = x.BillDate,
                    BillNumber = x.BillNumber,
                    Price = Math.Round(x.Price, 2),
                    IsPay = x.IsPay,
                    Description = x.Description
                }).ToList();
                return View(list);
            }
            else
            {
                List<ProjectListVM> list = _ws.GetAll()
                .Where(x => x.IsActive == true && x.CreatedBy == SessionManager.ActiveUser.Id)
                .OrderByDescending(x => x.Created)
                .Select(x => new ProjectListVM()
                {
                    Id = x.Id,
                    CompanyName = x.CompanyName,
                    Model = x.Model,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    BillDate = x.BillDate,
                    BillNumber = x.BillNumber,
                    Price = Math.Round(x.Price, 2),
                    IsPay = x.IsPay,
                    Description = x.Description
                }).ToList();
                return View(list);
            }
        }

        [HttpPost]
        public JsonResult CreateProject(CreateProjectVM vm)
        {
            try
            {
                Work newWork = new Work();
                newWork.Created = DateTime.Now;
                newWork.CreatedBy = SessionManager.ActiveUser.Id;
                newWork.Modified = DateTime.Now;
                newWork.ModifiedBy = SessionManager.ActiveUser.Id;
                newWork.Personnel = SessionManager.ActiveUser.Photo;
                newWork.IsActive = true;

                newWork.CompanyName = vm.CompanyName;
                newWork.Model = vm.Model;
                newWork.StartDate = vm.StartDate;
                newWork.EndDate = vm.EndDate;
                newWork.BillDate = vm.BillDate;
                newWork.BillNumber = vm.BillNumber;
                newWork.Price = Math.Round(vm.Price, 2);
                newWork.IsPay = false;
                newWork.Description = vm.Description;

                _ws.Insert(newWork);

                return Json(new { Result = true, Message = "Proje Başarıyla Kaydedildi." });
            }
            catch (Exception ex)
            {
                return Json(new { Result = false, ex.Message });
            }
        }

        [HttpPost]
        public JsonResult UpdateProject(UpdateProjectVM vm)
        {
            try
            {
                Work work = _ws.GetById(vm.Id);
                work.Modified = DateTime.Now;
                work.ModifiedBy = SessionManager.ActiveUser.Id;

                work.CompanyName = vm.CompanyName;
                work.Model = vm.Model;
                work.StartDate = vm.StartDate;
                work.EndDate = vm.EndDate;
                work.BillDate = vm.BillDate;
                work.BillNumber = vm.BillNumber;
                work.Price = Math.Round(vm.Price, 2);
                work.IsPay = vm.IsPay;
                work.Description = vm.Description;

                _ws.Update(work);

                return Json(new { Result = true, Message = "Proje Başarıyla Güncellendi" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = false, ex.Message });
            }
        }

        public JsonResult DeleteProject(DeleteProjectVM vm)
        {
            try
            {
                Work work = _ws.GetById(vm.Id);
                work.IsActive = false;
                work.Modified = DateTime.Now;
                work.ModifiedBy = SessionManager.ActiveUser.Id;

                _ws.Update(work);

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