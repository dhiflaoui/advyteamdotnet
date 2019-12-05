using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class EvaluationController : Controller
    {
        // GET: Evaluation
        public ActionResult Index()
        { 

        HttpClient Client = new HttpClient();
        Client.BaseAddress = new Uri("http://localhost:9080/PIDEV_project-web/");
        Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("rest/evaluations/liste").Result;
            if (response.IsSuccessStatusCode)
            {
               /* DateTime FinalDate = DateTime.Now;//your fitro object date will be here
                string xdate = String.Format(" Data <= '{0}' ", FinalDate.ToString("yyyy-MM-dd") + " 23:59:59");
                Text = xdate;*/
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<evaluation>>().Result;
              

            }
            else
            {
                ViewBag.result = "error";
            }
            return View();
        }

        // GET: Evaluation/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Evaluation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Evaluation/Create
        [HttpPost]
        public ActionResult Create(evaluation Eval)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:9080");
            client.PostAsJsonAsync<evaluation>("rest/evaluations", Eval).ContinueWith((postTask)=> postTask.Result.EnsureSuccessStatusCode());
            return RedirectToAction("index");


        }

        // GET: Evaluation/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Evaluation/Edit/5
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

        // GET: Evaluation/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Evaluation/Delete/5
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
