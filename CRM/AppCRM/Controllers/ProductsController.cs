using BS;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using data = DO.Objects;

namespace AppCRM.Controllers
{
    public class ProductsController : Controller
    {
        products _products = new products();
        
        public ActionResult Index(String search, int page = 1)
        {
            var rols = (byte[])Session["rols"];

            if (rols == null) //redirect to SinIn
            {
                return RedirectToAction("Index", "Home");
            }
            else if (rols.Contains<byte>(2) || rols.Contains<byte>(1))
            {
                IEnumerable<data.product> listProducts = null;

                if (search == "" || search == null)
                {
                    listProducts = _products.GetAll();
                }
                else
                {
                    listProducts = _products.GetByNameOrId(search);
                }

                ViewBag.Search = search;

                PagedList<data.product> model = new PagedList<data.product>(listProducts, page, 8);
                return View(model);
            }
            else//redirect to Home
            {
                return RedirectToAction("Home", "Home");
            }
        }

        public ActionResult Register() 
        {
            var rols = (byte[])Session["rols"];

            if (rols == null) //redirect to SinIn
            {
                return RedirectToAction("Index", "Home");
            }
            else if (rols.Contains<byte>(1))
            {
                categories _categories = new categories();
                ViewBag.Categories = _categories.GetAll();
                return View();
            }
            else//redirect to Home
            {
                return RedirectToAction("Home", "Home");
            }
        }

        [HttpPost]
        public ActionResult Register(String productName, int inventory, Decimal price, int categoryId)
        {
            data.product product = new data.product();
            product.productName = productName;
            product.inventory = inventory;
            product.price = price;
            product.categoryId = categoryId;

            _products.Insert(product);

            return RedirectToAction("Index");
        }

        public ActionResult Update(long id)
        {
            var rols = (byte[])Session["rols"];

            if (rols == null) //redirect to SinIn
            {
                return RedirectToAction("Index", "Home");
            }
            else if (rols.Contains<byte>(1))
            {
                categories _categories = new categories();
                ViewBag.Categories = _categories.GetAll();

                var product = _products.GetOneById(id);
                return View(product);
            }
            else//redirect to Home
            {
                return RedirectToAction("Home", "Home");
            }
        }

        [HttpPost]
        public ActionResult Update(long id, String productName, Decimal price, String categoryId)
        {
            var rols = (byte[])Session["rols"];

            if (rols == null) //redirect to SinIn
            {
                return RedirectToAction("Index", "Home");
            }
            else if (rols.Contains<byte>(1))
            {
                var product = _products.GetOneById(id);
                product.productName = productName;
                product.price = price;

				if (categoryId != "--Select--" && categoryId != "")
				{
                    product.categoryId = Int32.Parse(categoryId);
                }
                product.category = null;

                products newProducto = new products();
                newProducto.Update(product);

                return RedirectToAction("Index");
            }
            else//redirect to Home
            {
                return RedirectToAction("Home", "Home");
            }
        }

        [HttpPost]
        public ActionResult AddInventory(int addInventory, long id)
        {
			try
			{
                var product = _products.GetOneById(id);
                product.inventory += addInventory;

                //create a new BS products for update 
                products newProductos = new products();
                newProductos.Update(product);

                return Json(new { sucess = true }, JsonRequestBehavior.AllowGet);
            }
            catch( Exception ex)
			{

			}
            return RedirectToAction("Index");
        }
    }
}