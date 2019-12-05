using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service;
using Domain.Entities;
using Data;

namespace Web.Controllers
{
    public class QsmController : Controller
    { AdvyteamContext db = new AdvyteamContext();
        IQcmService qs;
        int quesId = 1;
        public QsmController()
        {
            qs = new QcmService();
        }

        // GET: Qsm
        public ActionResult Index()
        {
            return View(qs.GetAll());
        }

        // GET: Qsm/Details/5
        public ActionResult Details(int id)
        {
            qcm q = qs.GetById(id);
            if (q == null)
            {

                return HttpNotFound();

            }

            return View(q);
        }

        // GET: Qsm/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Qsm/Create
        [HttpPost]
        public ActionResult Create(qcm qc)
        {
            qs.Add(qc);
            qs.Commit();


            return RedirectToAction("Index");
        }

        // GET: Qsm/Edit/5
        public ActionResult Edit(int id)
        {
            qcm q = qs.GetById(id);

            if (q == null)
            {
                return HttpNotFound();
            }
            return View(q);
        }

        // POST: Qsm/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, qcm q)
        {
            qcm q1 = qs.GetById(q.qcmId);
            q1.COP = q.COP;
            q1.OPA = q.OPA;
            q1.OPB = q.OPB;
            q1.OPC = q.OPC;
            q1.OPD = q.OPD;
            q1.Qtext = q.Qtext;
            q1.formationEnLigne_formationElLigneId = q.formationEnLigne_formationElLigneId;

            q1.Specialite = q.Specialite;
           

            if (ModelState.IsValid)
            {
                qs.Update(q1);
                qs.Commit();

                return RedirectToAction("Index");

            }

            return RedirectToAction("Index");
        }

        // GET: Qsm/Delete/5
        public ActionResult Delete(int id)
        {
            return View(qs.GetById(id));
        }

        // POST: Qsm/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, qcm q)
        {
            q = qs.GetById(id);
            qs.Delete(q);
            qs.Commit();
            return RedirectToAction("Index");
        }
        //        public ActionResult Quiz() { 
        //        //{
        //        //    bool canMove = false;
        //        //    if (db.qcms.Count() > quesId)
        //        //        quesId++;
        //        //int y = db.qcms.Count();
        //      //  var y = qs.GetAll();
        //        qcm q = null;
        //       //     int i= 0;
        //         //  foreach(var i in y  ) { 
        //           TempData["qid"]=1;
        //            int examid = Convert.ToInt32(TempData["qid"].ToString());
        //        q = db.qcms.Where(x => x.qcmId == examid).SingleOrDefault();
        //            TempData["qid"] = q.qcmId+1;
        //                // q = db.qcms.Where(x => x.qcmId == q.qcmId+1).SingleOrDefault();
        //          //  }
        //    TempData.Keep();
        //            return View(q);
        //}
        public ActionResult Quiz()
        {

            if (db.qcms.Count() > quesId)
            {
                quesId++;
                

            }

            return View();
        }
        [HttpPost]
        public ActionResult Quiz(qcm q)
        {
            TempData["score"] = 0;
            if (q.OPA != null)
            {
                if (q.OPA.Equals("A"))
                {
                    TempData["score"] = Convert.ToInt32(TempData["score"]) + 1;

                }
            }
            else if (q.OPB != null)
            {
                if (q.OPB.Equals("B"))
                {
                    TempData["score"] = Convert.ToInt32(TempData["score"]) + 1;

                }
            }
            else if (q.OPC != null)
            {
                if (q.OPC.Equals("C"))
                {
                    TempData["score"] = Convert.ToInt32(TempData["score"]) + 1;

                }

            }
            else if (q.OPD != null)
            {
                if (q.OPD.Equals("D"))
                {
                    TempData["score"] = Convert.ToInt32(TempData["score"]) + 1;

                }
            }
            return RedirectToAction("Quiz");
        }
    }
}
