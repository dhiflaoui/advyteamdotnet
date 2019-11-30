using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service;

namespace Web.Controllers
{
    public class ClaimController : Controller
    {
        IClaimService CS;
        IEvalService EV;
        IUserService US;

        public ClaimController()
        {
            CS = new ClaimService();
            EV = new EvalService();
            US= new UserService();
        }
        // GET: Claim
        public ActionResult Index()
        {
            return View();
        }

        // GET: Claim/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Claim/Create
        public ActionResult Create()
        {
            ////return list deroulent de evaluation
            //var ListEval = EV.GetAll();
            //ViewBag.EvalID = new SelectList(ListEval, "EvalID ", "Titre_Eval");
            ////return list deroulent users name
            //var ListUser = US.GetAll();
            //ViewBag.EvalID = new SelectList(ListUser, "user_id ", "nom"+ "prenom");

            return View();
        }

        // POST: Claim/Create
        [HttpPost]
        public ActionResult Create(reclamation claim)
        {
           
            CS.Add(claim);
            CS.Commit();
            // TODO: Add insert logic here

            return RedirectToAction("Create");

        }

        // GET: Claim/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Claim/Edit/5
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
