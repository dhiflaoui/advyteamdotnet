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
        public ActionResult Score()
        {
            return View();
        }
        public ActionResult Quiz() {
            //TempData["score"] = 18;
            //int fin = db.qcms.Count();
            //if (Convert.ToInt32(TempData["idq"])>= fin)
            //{
            //    return RedirectToRoute("Index");
            //}
       try
            {
                if (TempData["idq"] == null)
                {
                    qcm q = db.qcms.First();
                    TempData["idq"] = q.qcmId;
                    return View(q);
                }
                else
                {
                    int idq = Convert.ToInt32(TempData["idq"]);
                    int? idNew = idq + 1;
                    qcm q = db.qcms.Find(idNew);
                    TempData["idq"] = q.qcmId;

                    return View(q);
                }
            }
            catch (Exception) {

                return RedirectToAction("Score");


            }

        }
        [HttpPost]
        public ActionResult Quiz(qcm qc)
        {
            string corrections = null; 
           // TempData["score"] = 0;
            if (qc.OPA != null)
            {
                corrections = "A";
            }
            else if (qc.OPB != null)
            {
                corrections = "B";

            }
            else if (qc.OPC != null)
            {

                corrections = "C";

            }
            else if (qc.OPD != null)
            {
                corrections = "D";

            }

            if(corrections.Equals(qc.COP))
            {
                TempData["score"] = Convert.ToInt32(TempData["score"])+1;
            }
            else
            {
                TempData["score"] = Convert.ToInt32(TempData["score"]);

            }
            TempData.Keep();

            return RedirectToAction("Quiz");
        }
    }
}
