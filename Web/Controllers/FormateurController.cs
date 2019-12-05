using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Mvc;
using Domain.Entities;

namespace Web.Controllers
{
    public class FormateurController : Controller
    {

        public ActionResult Index()
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:9080/PIDEV_project-web/");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("rest/formateur/liste").Result;
            if (response.IsSuccessStatusCode)
            {
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<formateur>>().Result;

            }
            else
            {
                ViewBag.result = "error";
            }
            return View();
        }
        [HttpGet]
        public ActionResult create()
        {
            return View("create");
        }
        [HttpPost]
        public ActionResult create(formateur fo)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:9080/PIDEV_project-web/");

            HttpContent content = new StringContent("");
            client.PostAsJsonAsync("rest/formateur/add/" + fo.nom + "/" + fo.prenom + "/" + fo.email + "/" + fo.numero + "/" + fo.Disponible + "/"
                + fo.Specialite , content).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());
            //return View();
            return RedirectToAction("index");

        }
        public ActionResult Delete(int id)
        {
            return View();

        }
        [HttpPost]
        public ActionResult Delete(int id, formateur collection)
        {
           
            
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:9080/PIDEV_project-web/");
                client.DeleteAsync("rest/formateur/delete/" + id).ContinueWith((deleteTask) => deleteTask.Result.EnsureSuccessStatusCode());

                return RedirectToAction("index");

            
           
        }
        [HttpGet]
        public ActionResult update()
        {
            return View("update");
        }
        [HttpPut]
        public ActionResult update(formateur fo)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:9080/PIDEV_project-web/");

            client.PostAsXmlAsync<formateur>("rest/formateur/update", fo).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());

            return RedirectToAction("index");

        }
    }
}