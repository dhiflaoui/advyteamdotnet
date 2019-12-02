using Data;
using Domain.Entities;
using Service;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    

    public class ClaimManagerController : Controller
    {
        private AdvyteamContext db = new AdvyteamContext();
        IClaimService CS;
        IEvalService EV;
        IUserService US;
        public ClaimManagerController()
        {
            CS = new ClaimService();
            EV = new EvalService();
            US = new UserService();
        }
        // GET: ClaimManager
        public ActionResult Index(reclamation claim)
        {

            //string statut = ((int)claim.statut).ToString();
            return View(CS.GetAll());
        }



        // GET: ClaimManager/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ClaimManager/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClaimManager/Create
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

        // GET: ClaimManager/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reclamation claim = db.reclamations.Find(id);
            if (claim == null)
            {
                return HttpNotFound();
            }
            return View(claim);
        }

        // POST: ClaimManager/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReclmationID,titreclaim,descp,fich,comment,reponse")] reclamation claim)
        {

            if (ModelState.IsValid)
            {
                claim.statut = Statut.Enattente;
                db.Entry(claim).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(claim);
        }
    

        // GET: ClaimManager/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ClaimManager/Delete/5
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
