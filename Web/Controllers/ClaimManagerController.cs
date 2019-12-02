using Domain.Entities;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class ClaimManagerController : Controller
    {
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
            return View();
        }

        // POST: ClaimManager/Edit/5
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
