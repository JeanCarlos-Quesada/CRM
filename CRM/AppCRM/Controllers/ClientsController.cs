﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BS;
using PagedList;
using PagedList.Mvc;
using data = DO.Objects;

namespace AppCRM.Controllers
{
    public class ClientsController : Controller
    {
        private clients _clients = new clients();

        public ActionResult Index(String search, int page = 1)
        {
            IEnumerable<data.client> listClients = null;

            if (search == "" || search == null)
            {
                listClients = _clients.GetAll(true);
            }
            else
            {
                listClients = _clients.GetByNameOrId(search, true);
            }

            ViewBag.Search = search;

            PagedList<data.client> model = new PagedList<data.client>(listClients, page, 8);
            return View(model);
        }

        public ActionResult InActives(String search, int page = 1)
        {
            IEnumerable<data.client> listClients = null;

            if (search == "" || search == null)
            {
                listClients = _clients.GetAll(false);
            }
            else
            {
                listClients = _clients.GetByNameOrId(search, false);
            }

            ViewBag.Search = search;

            PagedList<data.client> model = new PagedList<data.client>(listClients, page, 8);
            return View(model);
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(data.client client, String countryCode)
        {
            client.phone = "+" + countryCode + client.phone;
            client.registerDate = DateTime.Now;
            client.isActive = true;
            _clients.Insert(client);
            return RedirectToAction("Index");
        }

        public ActionResult Update(long id)
        {
            var client = _clients.GetOneById(id);
            return View(client);
        }

        [HttpPost]
        public ActionResult Update(data.client client, long id)
        {
            client.clientId = id;
            client.isActive = true;
            _clients.Update(client);
            return RedirectToAction("Index");
        }

        public ActionResult InActive(long id)
        {
            //create new BS.clients, because when find one by id I can't update the entity
            clients _newClients = new clients();
            data.client client = _newClients.GetOneById(id);

            client.isActive = false;
            _clients.Update(client);
            return RedirectToAction("Index");
        }

        public ActionResult Active(long id)
        {

            //create new BS.clients, because when find one by id I can't update the entity
            clients _newClients = new clients();
            data.client client = _newClients.GetOneById(id);

            client.isActive = true;
            _clients.Update(client);
            return RedirectToAction("InActives");
        }

    }
}