using BS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using data = DO.Objects;

namespace AppCRM.Controllers
{
	public class HomeController : Controller
	{
		private employees _employees = new employees();

		public ActionResult Index()
		{
			return View();
		}

		//SingIn
		[HttpPost]
		public ActionResult SingIn(String userName, String password)
		{

			keys _keys = new keys();
			data.AES aes = new data.AES();

			var key = _keys.GetOneById(1);

			var employee = _employees.SingIn(aes.Encriptar(userName, key.C_Key, key.C_IV), aes.Encriptar(password, key.C_Key, key.C_IV));

			if (employee != null)
			{
				//save employee ID in Session
				HttpContext.Session.Add("employeeId", employee.employeeId);

				users_x_rols _users_x_rols = new users_x_rols();
				//find rols by user id
				byte[] rols = _users_x_rols.GetAllByUserId(employee.users.FirstOrDefault().userId).Select(x => x.rolId).ToArray();

				//save rols in Session
				HttpContext.Session.Add("rols", rols);

				return Json( new { rols },JsonRequestBehavior.AllowGet);
			}
			else
			{
				return null;
			}
		}

		public ActionResult SingOut()
		{
			HttpContext.Session.Remove("employeeId");
			return Json(new { sucess = true},JsonRequestBehavior.AllowGet);
		}

		public ActionResult Home()
		{
			return View();
		}

		public ActionResult Profile()
		{
			var employeeId = Int64.Parse(Session["employeeId"].ToString());
			var employee = _employees.GetOneById(employeeId);

			var rols = (byte[])Session["rols"];
			ViewBag.rols = rols.ToList();

			return View(employee);
		}

		public ActionResult ChangePassword(String password)
		{
			var employeeId = Int64.Parse(Session["employeeId"].ToString());

			keys _keys = new keys();
			data.AES aes = new data.AES();
			var key = _keys.GetOneById(1);

			users _users = new users();
			var user = _users.GetOneByEmployeeId(employeeId);
			
			user.userPassword = aes.Encriptar(password, key.C_Key, key.C_IV);

			//I need a second BS user for update
			users _users02 = new users();
			try
			{
				_users02.Update(user);
				return Json(new { sucess = true }, JsonRequestBehavior.AllowGet);
			}
			catch (Exception ex)
			{
				return null;
			}
		}

		public ActionResult ChangeUserName(String userName)
		{
			var employeeId = Int64.Parse(Session["employeeId"].ToString());

			keys _keys = new keys();
			data.AES aes = new data.AES();
			var key = _keys.GetOneById(1);

			users _users = new users();
			var user = _users.GetOneByEmployeeId(employeeId);

			user.userName = aes.Encriptar(userName, key.C_Key, key.C_IV);

			//I need a second BS user for update
			users _users02 = new users();
			try
			{
				_users02.Update(user);
				return Json(new { sucess = true }, JsonRequestBehavior.AllowGet);
			}
			catch (Exception ex)
			{
				return null;
			}
		}

		public ActionResult PasswordExist(String password)
		{
			var employeeId = Int64.Parse(Session["employeeId"].ToString());

			keys _keys = new keys();
			data.AES aes = new data.AES();

			var key = _keys.GetOneById(1);

			users _users = new users();

			return Json(new { passwordExist = _users.PasswordExist(aes.Encriptar(password, key.C_Key, key.C_IV), employeeId) }, JsonRequestBehavior.AllowGet);
		}

		public ActionResult UserNameExist(String userName)
		{
			keys _keys = new keys();
			data.AES aes = new data.AES();

			var key = _keys.GetOneById(1);

			users _users = new users();

			return Json(new { userNameExist = _users.UserNameExist(aes.Encriptar(userName, key.C_Key, key.C_IV))}, JsonRequestBehavior.AllowGet);
		}
	}
}