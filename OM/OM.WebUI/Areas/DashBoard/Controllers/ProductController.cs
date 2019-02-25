using System;
using System.Linq;
using System.Web.Mvc;
using OM.Entity.Domain;
using OM.WebUI.MvcHelper;
using OM.Business.Abstract;
using OM.Entity.Complex.Product;
using System.Collections.Generic;

namespace OM.WebUI.Areas.DashBoard.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductBs _ps;

        public ProductController(IProductBs ps)
        {
            _ps = ps;
        }

        #region Product CRUD

        public ActionResult Product()
        {
            List<ProductListVM> list = _ps.GetAll()
                .Where(x => x.IsActive == true)
                .OrderByDescending(x => x.Created)
                .Select(x => new ProductListVM()
                {
                    Id = x.Id,
                    BrandName = x.BrandName,
                    Model = x.Model,
                    Serial = x.Serial,
                    WorkHeight = x.WorkHeight,
                    WorkCapacity = x.WorkCapacity,
                    Periodic = x.Periodic,
                    State = x.State,
                    Description = x.Description
                }).ToList();
            return View(list);
        }

        [HttpPost]
        public JsonResult CreateProduct(CreateProductVM vm)
        {
            try
            {
                Product newProduct = new Product();
                newProduct.Created = DateTime.Now;
                newProduct.CreatedBy = SessionManager.ActiveUser.Id;
                newProduct.Modified = DateTime.Now;
                newProduct.ModifiedBy = SessionManager.ActiveUser.Id;
                newProduct.IsActive = true;
                
                newProduct.BrandName = vm.BrandName;
                newProduct.Model = vm.Model;
                newProduct.Serial = vm.Serial;
                newProduct.WorkHeight = vm.WorkHeight;
                newProduct.WorkCapacity = vm.WorkCapacity;
                newProduct.Periodic = vm.Periodic;
                newProduct.State = vm.State;
                newProduct.Description = vm.Description;

                _ps.Insert(newProduct);

                return Json(new { Result = true, Message = "Ürün Başarıyla Kaydedildi." });
            }
            catch (Exception ex)
            {
                return Json(new { Result = false, ex.Message });
            }
        }

        [HttpPost]
        public JsonResult UpdateProduct(UpdateProductVM vm)
        {
            try
            {
                Product product = _ps.GetById(vm.Id);
                product.Modified = DateTime.Now;
                product.ModifiedBy = SessionManager.ActiveUser.Id;
                
                product.BrandName = vm.BrandName;
                product.Model = vm.Model;
                product.Serial = vm.Serial;
                product.WorkHeight = vm.WorkHeight;
                product.WorkCapacity = vm.WorkCapacity;
                product.Periodic = vm.Periodic;
                product.State = vm.State;
                product.Description = vm.Description;

                _ps.Update(product);

                return Json(new { Result = true, Message = "Ürün Başarıyla Güncellendi" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = false, ex.Message });
            }
        }

        public JsonResult DeleteProduct(DeleteProductVM vm)
        {
            try
            {
                Product product = _ps.GetById(vm.Id);
                product.IsActive = false;
                product.Modified = DateTime.Now;
                product.ModifiedBy = SessionManager.ActiveUser.Id;

                _ps.Update(product);

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