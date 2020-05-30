using Newtonsoft.Json;
using OnlineShoppingBazar.DAL_Data_Access_Layer_;
using OnlineShoppingBazar.Models;
using OnlineShoppingBazar.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShoppingBazar.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public GenericUnitOfWork _unitOfWork = new GenericUnitOfWork();
        public ActionResult Dashboard()
        {
            return View();
        }


        public ActionResult Categories()
        {
            List<Tbl_Category> allcategories = _unitOfWork.GetRepositoryInstance<Tbl_Category>().GetAllRecordsIQueryable().Where(i => i.IsDelete == false).ToList();
            return View(allcategories);
        }

        public ActionResult AddCategory()
        {

            return UpdateCategory(0);
        }

        public ActionResult UpdateCategory(int categoryId)
        {
            CategoryDetail cd;
            if (categoryId!=0)
            {
                cd = JsonConvert.DeserializeObject<CategoryDetail>(JsonConvert.SerializeObject(_unitOfWork.GetRepositoryInstance<Tbl_Category>().GetFirstorDefault(categoryId)));
            }
            else
            {
                cd = new CategoryDetail();
            }
                
            return View("UpdateCategory",cd);
        }

        public ActionResult Product()
        {
            using (dbMyOnlineStoreEntities db=new dbMyOnlineStoreEntities())
            {
               var data= db.Tbl_Product.ToList();
                return View(data);
            }
               
        }
        [HttpGet]
        public ActionResult AddProduct()
        {
            

            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(Tbl_Product product)
        {
            _unitOfWork.GetRepositoryInstance<Tbl_Product>().Add(product);
            _unitOfWork.SaveChanges();

            return View();
        }
    }
}