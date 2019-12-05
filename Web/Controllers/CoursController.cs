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
    public class CoursController : Controller
    {
        public int selectCoursId;
        public int selectformationId;
        public int selectpaticpationId;

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
        public ActionResult mesCours()
        {
                return View(cs.GetByformation(1));
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
        public ActionResult Valider (int id,affectationenligne f)
        {
            affectationenligne c1 = ps.GetById(f.participationId);

            c1.niveau = (f.niveau) - 1;
            ps.Update(c1);
            ps.Commit();
            return RedirectToAction("Index");
        }
       
    }
}
