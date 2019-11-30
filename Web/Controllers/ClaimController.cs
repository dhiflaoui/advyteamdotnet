using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service;
using System.IO;

namespace Web.Controllers
{
    public class ClaimController : Controller
    {
        IClaimService CS;
        IEvalService EV;
        IUserService US;
        
        private Statut ouvert;
        
        public ClaimController()
        {
            CS = new ClaimService();
            EV = new EvalService();
            US= new UserService();
        }
        // GET: Claim
        public ActionResult Index()
        {
            return View(CS.GetAll());
        }

        // GET: Claim/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Claim/Create
        public ActionResult Create()
        {
            //return list deroulent de evaluation
            var ListEval = EV.GetAll();
            ViewBag.evaluation_id = new SelectList(ListEval, "id ", "Titre_Eval");
            //return list deroulent users name
            var ListUser = US.GetAll();
            ViewBag.user_id = new SelectList(ListUser, "id ", "nom"+ "prenom");

            return View();
        }

        // POST: Claim/Create
        [HttpPost]
        public ActionResult Create(reclamation claim, HttpPostedFileBase file)
        {
           // //file
           //claim.fich = file.FileName;
           // if (file.ContentLength > 0)

           // {
           //     var path = Path.Combine(Server.MapPath("~/Content/upload"), file.FileName);
           //     file.SaveAs(path);
           // }

            claim.statut = ouvert;
            DateTime dateouvr = DateTime.Now;
            claim.dateopen = dateouvr;

            CS.Add(claim);
            CS.Commit();
          

            return RedirectToAction("Create");

        }

        // GET: Claim/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Claim/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, reclamation claim)
        {
            try
            {
                //DateTime dateclot = DateTime.Now;
                //claim.dateclose = dateclot;

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Claim/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Claim/Delete/5
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
