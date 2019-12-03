using Domain.Entities;
using System;
using System.Collections.Generic;
using System.IO;
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
                ViewBag.result = "error1";
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
        public ActionResult Create(user u, HttpPostedFileBase file1 , HttpPostedFileBase file2)
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:9080/PIDEV_project-web/");
            HttpContent content = new StringContent("");
            
            try
            {
                if (file1.ContentLength > 0 && file2.ContentLength >0)
                {
                   
                    var path = Path.Combine(Server.MapPath("~/Content/upload/"), file1.FileName);
                    file1.SaveAs(path);
                    var path1 = Path.Combine(Server.MapPath("~/Content/upload/"), file2.FileName);
                    file2.SaveAs(path1);
                    Client.PostAsJsonAsync("rest/users/add/" + u.cin + "/" + u.nom + "/" + u.prenom + "/" + u.adresseMail + "/" + u.motdp + "/"
                + file1.FileName + "/" + file2.FileName + "/" + u.ville + "/" + u.tel + "/" + u.solde_conge + "/" + u.solde_absence + "/"
                + u.salaire + "/" + u.role + "/" + u.specialite, content).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());
                }
                }
            catch (Exception ex)
            {
                u.photo = "null";
                u.cv = "null";

                Client.PostAsJsonAsync("rest/users/add/" + u.cin + "/" + u.nom + "/" + u.prenom + "/" + u.adresseMail + "/" + u.motdp + "/"
                               + u.photo + "/" + u.cv + "/" + u.ville + "/" + u.tel + "/" + u.solde_conge + "/" + u.solde_absence + "/"
                               + u.salaire + "/" + u.role + "/" + u.specialite, content).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());
            }
            return RedirectToAction("Index", "Employe");
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
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:9080/PIDEV_project-web/");
            client.DeleteAsync("rest/users/delete/" + id).ContinueWith((deleteTask) => deleteTask.Result.EnsureSuccessStatusCode());

            return RedirectToAction("Index", "Employe");
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
