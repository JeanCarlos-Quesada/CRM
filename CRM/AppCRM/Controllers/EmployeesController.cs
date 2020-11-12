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
        public ActionResult Register(data.employee employee, String countryCode)
        {
            employee.phone = "+" + countryCode + employee.phone;
            employee.registerDate = DateTime.Now;
            employee.isActive = true;
            _employees.Insert(employee);
            return RedirectToAction("Index");
        }

        public ActionResult Update(long id)
        {
            var client = _employees.GetOneById(id);
            return View(client);
        }

        [HttpPost]
        public ActionResult Update(data.employee employee, long id)
        {
            employee.employeeId = id;
            employee.isActive = true;
            _employees.Update(employee);
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
    }
}