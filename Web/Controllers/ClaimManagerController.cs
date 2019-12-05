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
            var instructors = db.reclamations.Include(i => i.user).Include(i => i.evaluation);

            return View(instructors.ToList());
           // return View(CS.GetAll());
        }


        [HttpPost]
        public ActionResult Index(string searchString)
        {
            IEnumerable<reclamation> reclamations = CS.GetAll();

            if (!String.IsNullOrEmpty(searchString))
            {
                reclamations = reclamations.Where(m => m.statut.ToString().Contains(searchString)).ToList();
            }
            return View(reclamations);
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
        public ActionResult Edit(int id, reclamation claim)
        {
            //return View(CS.GetById(id));
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           claim = db.reclamations.Find(id);
            if (claim == null)
            {
                return HttpNotFound();
            }
            return View(claim);
        }

        // POST: ClaimManager/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( reclamation claim)
        {

            reclamation c2 = CS.GetById(claim.ReclmationID);
            c2.reponse = claim.reponse;
            c2.statut = Statut.Resolu;
            c2.ReclmationID = c2.ReclmationID;
            c2.user_id = c2.user_id;
            c2.evaluation_id = c2.evaluation_id;

            if (ModelState.IsValid)
            {
                CS.Update(c2);
                CS.Commit();
                //claim.statut = Statut.Resolu;
                //db.Entry(claim).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(claim);
        }
    

        // GET: ClaimManager/Delete/5
        public ActionResult Delete(int id)
        {
            return View(CS.GetById(id));
        }

        // POST: ClaimManager/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, reclamation claim)
        {
            claim = CS.GetById(id);
            CS.Delete(claim);
            CS.Commit();
            return RedirectToAction("Index");
        }
    }
}
