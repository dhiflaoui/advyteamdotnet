using Domain.Entities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CaptchaMvc.HtmlHelpers;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace Web.Controllers
{


    public class LoginController : Controller
    {
        public static user currentUser;

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        // GET: Login/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Login/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Login/Create
        [HttpPost]
        public ActionResult Create(user u)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (!this.IsCaptchaValid(""))
            {
                ViewBag.error = "Captcha Invalide !";
                return View();
            }
            else
            {

                var request = (HttpWebRequest)WebRequest.Create("http://localhost:9080/PIDEV_project-web/rest/users/login/" + u.cin + "/" + u.motdp);

                request.Method = "GET";

                request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                var content = string.Empty;
                try
                {

                    var xRES = (HttpWebResponse)request.GetResponse();
                    using (var response = (HttpWebResponse)request.GetResponse())
                    {
                        using (var stream = response.GetResponseStream())
                        {
                            using (var sr = new StreamReader(stream))
                            {
                                content = sr.ReadToEnd();
                            }
                        }
                    }


                    if (content == null)
                    {
                        ViewBag.NoUSER = "Veuillez Vérifier vos coordonnées ";
                        TempData["BadCredentials"] = "Juste Bech ntesti bih mbaad fel Vue";
                        return View();

                    }
                    else {
                        try {
                            JObject json = JObject.Parse(content);

                            int f = -1;
                            foreach (var x in json)
                            {
                                if (x.Key == "id")
                                {
                                    var idid = x.Value;
                                    f = (int)idid;
                                }
                            }
                            var result = JsonConvert.DeserializeObject<user>(content);
                       //     user up = new user(result.nom, result.role, result.specialite);
                            currentUser = result ;


                            //TempData["loggedAdherent"] = f;
                            
                                Session["EmployeeSessionData1"] = currentUser;

                            Session["EmployeeSessionData"] = currentUser.nom;



                            //JavaScriptSerializer j = new JavaScriptSerializer();
                            // object a = j.Deserialize(content, typeof(object));

                            //  return View(result);
                            return RedirectToAction("Index", "Employe") ;
                          


                            //  if(adherentService.GetById(f).DTYPE.Equals("Admin"))

                            // return RedirectToAction("Index", "Admin");
                            //  else



                        }
                        catch(Exception ex)
                        {

                            ViewBag.NoUSER = "Veuillez Vérifier vos coordonnées ";
                            TempData["BadCredentials"] = "Juste Bech ntesti bih mbaad fel Vue";
                            return View();
                        }
                        }
                }
                catch (WebException ex)
                {
                    ViewBag.NoUSER = "Veuillez Vérifier vos coordonnées ";
                    TempData["BadCredentials"] = "Juste Bech ntesti bih mbaad fel Vue";
                    return View();
                }






            }
        }

        // GET: Login/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Login/Edit/5
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

        // GET: Login/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Login/Delete/5
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
