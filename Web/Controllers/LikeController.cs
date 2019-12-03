using Data;
using Domain.Entities;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class LikeController : Controller
    {
        private AdvyteamContext db = new AdvyteamContext();

        ILikeService fb;
        public LikeController()
        {
            fb = new LikeService();

        }

        // GET: Like
        public ActionResult Index()
        {
            return View();
        }
        public IList<reactp> listereactImage(int? idp)
        {
            var p = db.reactps.Where(com => com.publication_id == idp).ToList();
            return  p;
        }

        // GET: Like/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        public int Count(int idp)
        {
            return fb.nb_like(idp);
        }
        // GET: Like/Create
        public ActionResult Create(int idp)
        {
            reactp r = new reactp();
            r.publication_id = idp;
            r.user_id = LoginController.currentUser.id;
            db.users.Find(LoginController.currentUser.id).badge = "kjqsgkjfs";
            fb.Add(r);
            fb.Commit();
            return RedirectToAction("allPub", "Publication");

        }

        // POST: Like/Create
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

        // GET: Like/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Like/Edit/5
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

        // GET: Like/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Like/Delete/5
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
