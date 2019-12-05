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
    public class ParticipationController : Controller
    {
        AdvyteamContext ac = new AdvyteamContext();
        IParticipationService ps;
        ICoursService cs;
        public ParticipationController()
        {
            ps = new ParticipationService();
            cs = new CoursService();
        }
        // GET: Participation
        public ActionResult Index()
        {
            return View(ps.GetAll());
        }

        // GET: Participation/Details/5
        public ActionResult Details(int id)
        {
            affectationenligne a = ps.GetById(id);
            if (a == null)
            {

                return HttpNotFound();

            }

            return View(a);
        }

        // GET: Participation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Participation/Create
        [HttpPost]
        public ActionResult Create(affectationenligne af)
        {
                af.niveau = cs.nbrCours(af.formationEnLigne_formationElLigneId);
            ps.Add(af);
            ps.Commit();


            return RedirectToAction("Index");
        }

        // GET: Participation/Edit/5
        public ActionResult Edit(int id)
        {
            affectationenligne a = ps.GetById(id);

            if (a == null)
            {
                return HttpNotFound();
            }
            return View(a);
        }

        // POST: Participation/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, affectationenligne a)
        {
            affectationenligne a1 = ps.GetById(a.participationId);
            a1.users_id = a.users_id;
            a1.formationEnLigne_formationElLigneId = a.formationEnLigne_formationElLigneId;
            a1.niveau = a.niveau;
            a1.score = a.score;

            if (ModelState.IsValid)
            {
                ps.Update(a1);
                ps.Commit();

                return RedirectToAction("Index");

            }

            return RedirectToAction("Index");
        }

        // GET: Participation/Delete/5
        public ActionResult Delete(int id)
        {
            return View(ps.GetById(id));
        }

        // POST: Participation/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, affectationenligne a)
        {
            a = ps.GetById(id);
            ps.Delete(a);
            ps.Commit();
            return RedirectToAction("Index");
        }
      
        
    }
}
