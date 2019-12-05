using Data;
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
    public class FormationEnLigneController : Controller
    {
        AdvyteamContext ac = new AdvyteamContext();

        IFormationEnLigneService fs;
        IParticipationService ps;
        ICoursService cs;

        public FormationEnLigneController()
        {
            fs = new FormationEnLigneService();
            ps = new ParticipationService();
            cs = new CoursService();
        }
        // GET: FormationEnLigne
        public ActionResult Index()
        {
            return View(fs.GetAll());
        }
        public ActionResult mesCours(int id)
        {
            return View(cs.GetByformation(id));

        }
        public ActionResult indexuser()
        {
            return View(fs.GetById(1));
            

        }
        // GET: FormationEnLigne/Details/5
        public ActionResult Details(int id)
        {

            formationenligne f = fs.GetById(id);
            if (f == null)
            {

                return HttpNotFound();

            }

            return View(f);
        }

        // GET: FormationEnLigne/Create
        public ActionResult Create()
        {
        //    affectationenligne af = new affectationenligne();
        //    af.users_id = 1;
        //    af.formationEnLigne_formationElLigneId = id;
        //    ps.Add(af);
        //    ps.Commit();
        //    //f = ps.GetById(Convert.ToInt64(idf));
        //    //affectationenligne c1 = ps.GetById(f.participationId);
        //    //c1.formationEnLigne_formationElLigneId = idf;
        //    //c1.users_id = 1;


        //    //    ps.Update(c1);
        //    //    ps.Commit();

            return View();
        }

        // POST: FormationEnLigne/Create
        [HttpPost]
        public ActionResult Create(formationenligne fo, HttpPostedFileBase file1)
        {
            fo.image = file1.FileName;

            if (file1.ContentLength > 0)
            {
                var path = Path.Combine(Server.MapPath("~/Content/upload/"), file1.FileName);
                file1.SaveAs(path);
            }

            fs.Add(fo);
            fs.Commit();
            

            return RedirectToAction("Index");
        }

        // GET: FormationEnLigne/Edit/5
        public ActionResult Edit(int id)
        {
            formationenligne f = fs.GetById(id);

            if (f == null)
            {
                return HttpNotFound();
            }
            return View(f);
           
        }

        // POST: FormationEnLigne/Edit/5
        [HttpPost]
        public ActionResult Edit( formationenligne f)
        {
            formationenligne c1 = fs.GetById(f.formationElLigneId);
            c1.titre = f.titre;
            c1.objectifs = f.objectifs;
            c1.image = f.image;
            c1.formateur_id = f.formateur_id;
            c1.user_id = f.user_id;

            if (ModelState.IsValid)
            {
                fs.Update(c1);
                fs.Commit();

                return RedirectToAction("Index");

            }

            return RedirectToAction("Index");
        }

        // GET: FormationEnLigne/Delete/5
        public ActionResult Delete(int id)
        {
            return View(fs.GetById(id));
        }

        // POST: FormationEnLigne/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, formationenligne f)
        {
            f = fs.GetById(id);
            fs.Delete(f);
            fs.Commit();
            return RedirectToAction("Index");
        
        }

        //public ActionResult mesCours()
        //{
        //    return View(cs.GetByformation(1));
        //}

        public ActionResult Participer(int id)
        {

            affectationenligne af = new affectationenligne();
           // fs.GetById(id);
            af.niveau = cs.nbrCours(id);

            af.users_id = 1;
            af.formationEnLigne_formationElLigneId = id;
            ps.Add(af);
            ps.Commit();
           // return View(cs.GetByformation(id));
            return RedirectToAction("mesCours", "Cours", new { id = id });
        }
    }
}
