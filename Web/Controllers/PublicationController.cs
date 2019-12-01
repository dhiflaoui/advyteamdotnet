using Domain.Entities;
using Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class PublicationController : Controller
    {
        IPublicationService publicationService;
        public PublicationController()
        {
            publicationService = new PublicationService();
            }
        // GET: Publication
        public ActionResult allPub()
        {
            ViewBag.result = publicationService.GetAll();
            return View();
        }

        // GET: Publication/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Publication/Create
        public ActionResult Create()
        {
            return View();
        }

      //  POST: Publication/Create
       [HttpPost]
        public ActionResult Create(publication pu, HttpPostedFileBase file1)
        {
            pu.user_id = LoginController.currentUser.id;
            pu.date = DateTime.Now;
            pu.file = file1.FileName;
            publicationService.Add(pu);
            if (file1.ContentLength > 0)
            {
                var path = Path.Combine(Server.MapPath("~/Content/upload/"), file1.FileName);
                file1.SaveAs(path);
            }
            publicationService.Commit();
            return View();
        }

        //  GET: Publication/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Publication/Edit/5
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

        // GET: Publication/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Publication/Delete/5
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
