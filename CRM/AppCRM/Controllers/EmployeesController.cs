using BS;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using data = DO.Objects;

namespace AppCRM.Controllers
{
    public class EmployeesController : Controller
    {
		private employees _employees = new employees();
        
        public ActionResult Index(String search, int page = 1)
        {
            IEnumerable<data.employee> listEmployees = null;

            if (search == "" || search == null)
            {
                listEmployees = _employees.GetAll(true);
            }
            else
            {
                listEmployees = _employees.GetByNameOrId(search, true);
            }

            ViewBag.Search = search;

            PagedList<data.employee> model = new PagedList<data.employee>(listEmployees, page, 8);
            return View(model);
        }

        public ActionResult InActives(String search, int page = 1)
        {
            IEnumerable<data.employee> listEmployees = null;

            if (search == "" || search == null)
            {
                listEmployees = _employees.GetAll(false);
            }
            else
            {
                listEmployees = _employees.GetByNameOrId(search, false);
            }

            ViewBag.Search = search;

            PagedList<data.employee> model = new PagedList<data.employee>(listEmployees, page, 8);
            return View(model);
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(data.employee employee, String countryCode, Boolean isAdmin, Boolean isSeller)
        {
            employee.phone = "+" + countryCode + employee.phone;
            employee.registerDate = DateTime.Now;
            employee.isActive = true;
            _employees.Insert(employee);

			#region user
			//import AES
			data.AES aes = new data.AES();

            //get keys for encrypt
            keys _keys = new keys();
            data.key key = new data.key();
            key = _keys.GetOneById(1);

            //create and encrypt user
            data.user user = new data.user();
            users _user = new users();

            user.employeeId = _employees.GetLastOrDefault().employeeId;
            user.userName = aes.Encriptar(CreatePassword(6), key.C_Key, key.C_IV);
            user.userPassword = aes.Encriptar(CreatePassword(6), key.C_Key, key.C_IV);
            _user.Insert(user);

            //add rols
            data.user_x_rols user_x_rols = new data.user_x_rols();
            users_x_rols _users_x_rols = new users_x_rols();

            user_x_rols.userId = _user.GetLastOrDefault().userId;
			for (int i = 0; i < 2; i++)
			{
				if (isAdmin)
				{
                    isAdmin = false;
                    user_x_rols.rolId = 1;
                    _users_x_rols.Insert(user_x_rols);
                }
                else if (isSeller)
				{
                    isSeller = false;
                    user_x_rols.rolId = 2;
                    _users_x_rols.Insert(user_x_rols);
                }
            }
            #endregion user

            return RedirectToAction("Index");
        }

        public ActionResult Update(long id)
        {
            var employee = _employees.GetOneById(id);

            users_x_rols _users_x_rols = new users_x_rols();
            ViewBag.rols = _users_x_rols.GetAllByUserId(employee.users.FirstOrDefault().userId);
            return View(employee);
        }

        [HttpPost]
        public ActionResult Update(data.employee employee, long id, Boolean isAdmin, Boolean isSeller)
        {
            employee.employeeId = id;
            employee.isActive = true;
            _employees.Update(employee);

			#region rols
			//get user
			users _user = new users();
            data.user user = _user.GetOneByEmployeeId(id);

            //get list of rols by id user
            users_x_rols _users_x_rols = new users_x_rols();
            var listUser_x_rols = _users_x_rols.GetAllByUserId(user.userId);

            data.user_x_rols user_x_rols = new data.user_x_rols();
            user_x_rols.userId = listUser_x_rols.FirstOrDefault().userId;

            //this bs is because if I use _users_x_rols generete conflict with tha primary key
            users_x_rols deleteElemento = new users_x_rols();

            if (isAdmin)
            {
                //check if exist the administrator rol
                if (listUser_x_rols.Where(x => x.rolId == 1).Count() == 0)
                {
                    user_x_rols.rolId = 1;
                    _users_x_rols.Insert(user_x_rols);
                }

            }
            else
            {
                //check if exist the administrator rol and check than exist one rol in tha user
                if (listUser_x_rols.Where(x => x.rolId == 1).Count() != 0 &&  (listUser_x_rols.Count() >= 2 || isSeller))
                {
                    deleteElemento.Delete(listUser_x_rols.Where(x => x.rolId == 1).FirstOrDefault());
                }
            }

            if (isSeller)
            {
                //check if exist the seller rol
                if (listUser_x_rols.Where(x => x.rolId == 2).Count() == 0)
                {
                    user_x_rols.rolId = 2;
                    _users_x_rols.Insert(user_x_rols);
                }
            }
            else
            {
                //check if exist the seller rol and check than exist one rol in tha user
                if (listUser_x_rols.Where(x => x.rolId == 2).Count() != 0 && (listUser_x_rols.Count() >= 2 || isAdmin)) 
                {
                    deleteElemento.Delete(listUser_x_rols.Where(x => x.rolId == 2).FirstOrDefault());
                }
            }
			#endregion rols

			return RedirectToAction("Index");
        }

        public ActionResult InActive(long id)
        {
            //create new BS.clients, because when find one by id I can't update the entity
            employees _newEmployees = new employees();
            data.employee employee = _newEmployees.GetOneById(id);

            employee.isActive = false;
            _employees.Update(employee);
            return RedirectToAction("Index");
        }

        public ActionResult Active(long id)
        {

            //create new BS.clients, because when find one by id I can't update the entity
            employees _newEmployees = new employees();
            data.employee employee = _newEmployees.GetOneById(id);

            employee.isActive = true;
            _employees.Update(employee);
            return RedirectToAction("InActives");
        }

        public string CreatePassword(int length)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
        }
    }
}