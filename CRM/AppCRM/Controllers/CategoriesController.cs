using BS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using data = DO.Objects;

namespace AppCRM.Controllers
{
    public class CategoriesController : Controller
    {
        categories _categories = new categories();

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(String categoryName)
        {
            data.category category = new data.category();
            category.categoryName = categoryName;

            try
            {
                _categories.Insert(category);

                return Json(new { sucess = true }, JsonRequestBehavior.AllowGet);
            }
            catch( Exception ex)
			{
                return null;
			}
        }

        public ActionResult Update()
        {
            var listCategories = _categories.GetAll();
            return View(listCategories);
        }

        [HttpPost]
        public ActionResult Update(long id, String name)
        {
            return View();
        }

        public ActionResult getOneById(long id)
        {
            var category = _categories.GetOneById(id);
            return Json(new { category = category }, JsonRequestBehavior.AllowGet);
        }
    }
}