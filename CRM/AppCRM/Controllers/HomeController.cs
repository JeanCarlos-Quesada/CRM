using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppCRM.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		//SingIn
		[HttpPost]
		public ActionResult Index(String userName, String password)
		{
			return RedirectToAction("Home");
		}

		public ActionResult Home()
		{
			return View();
		}
	}
}