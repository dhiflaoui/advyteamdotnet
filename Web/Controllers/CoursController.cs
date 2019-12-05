using Data;
using Domain.Entities;
using Service;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class CoursController : Controller
    {
        public int selectCoursId;
        public int selectformationId;
        public int selectpaticpationId;
            AdvyteamContext db = new AdvyteamContext();

        IFormationEnLigneService fs;
        ICoursService cs;
        IParticipationService ps;
        public CoursController()
        { fs = new FormationEnLigneService();
            cs = new CoursService();
            ps = new ParticipationService();
        }

        // GET: Cours
        public ActionResult Index()
        {
            return View(cs.GetAll());
        }
    

        // GET: Cours/Details/5
        public ActionResult Details(int id)
        {
            cours c = cs.GetById(id);
            if( c==null)
            {
                return HttpNotFound();
            }
            return View(c);
        }
        public ActionResult DetailsmesCours(int id)
        {
            cours c = cs.GetById(id);
            if (c == null)
            {
                return HttpNotFound();
            }
            return View(c);
        }
        // GET: Cours/Create
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult MesCours()
        {
         //  IEnumerable <cours> fact = cs.GetAll().Where(x => x.formationEnLign_formationElLigneId.Equals(1));
            
            return View(cs.GetAll().Where(x=>x.formationEnLign_formationElLigneId.Equals(1)));
            //    // return View(cs.GetById(Convert.ToInt64(c.formationEnLign_formationElLigneId)));
            //}
            // int employeeId = 1;

        }

        // POST: Cours/Create
        [HttpPost]
        public ActionResult Create(cours co,HttpPostedFileBase file1)
        {

            co.video = file1.FileName;

            if (file1.ContentLength > 0)
            {
                var path = Path.Combine(Server.MapPath("~/Content/upload/"), file1.FileName);
                file1.SaveAs(path);
            }

            cs.Add(co);
            cs.Commit();

            return RedirectToAction("Index");
        }

        // GET: Cours/Edit/5
        public ActionResult Edit(int id)
        {
            cours c = cs.GetById(id);

            if (c == null)
            {
                return HttpNotFound();
            }
            return View(c);


        }

        // POST: Cours/Edit/5
        [HttpPost]
        public ActionResult Edit( cours c)
        {
            cours c1 = cs.GetById(c.courId);
           c1.titre = c.titre;
            c1.cour = c.cour;
            c1.video = c.video;
            if (ModelState.IsValid)
            {
                cs.Update(c1);
                cs.Commit();
                return RedirectToAction("Index");
            }
                return RedirectToAction("Index");
            
        }

        // GET: Cours/Delete/5
        public ActionResult Delete(int id)
        {
            return View(cs.GetById(id));
        }

        // POST: Cours/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, cours c)
        {
            c = cs.GetById(id);
            cs.Delete(c);
            cs.Commit();
            return RedirectToAction("Index");
        }
        public ActionResult betha (int id)
        {
            formationenligne fl = db.formationenlignes.Find(id);

            affectationenligne c1 = db.affectationenlignes.Where(x => x.formationEnLigne_formationElLigneId.Equals(fl.formationElLigneId)).Where(x => x.users_id.Equals(1)).First();

            c1.niveau = c1.niveau - 1;
            ps.Update(c1);
            ps.Commit();
            return RedirectToAction("Index");
        }
       
    }
}
