using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class EmployeController : Controller
    {
        // GET: Employe
        public ActionResult Index()
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:9080/PIDEV_project-web/");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("rest/users/liste").Result;
            if (response.IsSuccessStatusCode)
            {
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<user>>().Result;
            }
            else
            {
                ViewBag.result = "error";
            }
            return View();
        }

        // GET: Employe/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Employe/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employe/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employe/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Employe/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employe/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Employe/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
