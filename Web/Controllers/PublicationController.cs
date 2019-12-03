using Data;
using Domain.Entities;
using Microsoft.Ajax.Utilities;
using Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;


namespace Web.Controllers
{
    public class PublicationController : Controller
    {
        private AdvyteamContext db = new AdvyteamContext();

        IPublicationService publicationService;
        IFeedbackService fb;
        ILikeService fl;


        //  ILikeService lp;
        public PublicationController()
        {
          //  lp = new LikeService();
            publicationService = new PublicationService();
            fb = new FeedbackService();
            fl = new LikeService();


        }
        // GET: Publication
        public ActionResult allPub()
        {
            //  ViewBag.result = (publicationService.GetAll().OrderByDescending(x => x.date)); 
            ViewBag.result = (db.publications.Include(cs => cs.feedbacks).OrderByDescending(x => x.date).ToList());
            return View();
        }

        public ActionResult DeleteC(int id)
        {
            var r = fb.GetById(id);
            fb.Delete(r);
            fb.Commit();
            return RedirectToAction("allPub", "Publication");
        }
        // GET: Publication/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        public ActionResult MesPub()
        {
            ViewBag.result3 = db.publications.Include(cs => cs.feedbacks).ToList().Where(x => x.user_id.Equals(LoginController.currentUser.id));

            return View();
        }

        // GET: Publication/Create

        //  POST: Publication/Create
        [HttpPost]
        public ActionResult Create(publication pu, HttpPostedFileBase file1)
        {
            String chain = pu.statut;
            String mot = "rouge";
            String mot1 = "bleu";
            String mot2 = "vert";
            if (chain.Contains(mot))
            {
                chain = chain.Replace(mot, "*****");
                pu.statut = chain;

            }
            if (chain.Contains(mot1))
            {
                chain = chain.Replace(mot1, "*****");
                pu.statut = chain;

            }
            if (chain.Contains(mot2))
            {
                chain = chain.Replace(mot2, "*****");
                pu.statut = chain;

            }



            pu.user_id = LoginController.currentUser.id;
            pu.date = DateTime.Now;
           
            try
            {
                if (file1.ContentLength > 0)
                {
                    pu.file = file1.FileName;

                    var path = Path.Combine(Server.MapPath("~/Content/upload/"), file1.FileName);
                    file1.SaveAs(path);
                }
                publicationService.Add(pu);

                publicationService.Commit();
                return RedirectToAction("allPub", "Publication");
            }
            catch (Exception ex)
            {

                publicationService.Add(pu);

                publicationService.Commit();
                return RedirectToAction("allPub", "Publication");
            }
          
        }
        public ActionResult Like(int idp)
        {
            int fazaLike = fl.LikeExist(idp, LoginController.currentUser.id);
            try
            {
                if (fazaLike == 0)
                {
                    reactp r = new reactp();
                    r.publication_id = idp;
                    r.user_id = LoginController.currentUser.id;
                  //db.users.Find(LoginController.currentUser.id).badge = "kjqsgkjfs";

                    fl.Add(r);
                    fl.Commit();
                    return RedirectToAction("allPub", "Publication");
                }
                else
                    return null ;
            }
            catch (Exception ex)
            {
               
                return RedirectToAction("allPub", "Publication");
            }
            return RedirectToAction("allPub", "Publication");

        }

        // GET: Comment/Edit/5
        public ActionResult Edit(int id)
        {
            publication p = publicationService.GetById(id);

            if (p == null)
            {
                return HttpNotFound();
            }
            return View(p);
        }

        // POST: Participation/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, publication a)
        {
            publication a1 = publicationService.GetById(a.id);
            a1.date = a.date;
            a1.feedbacks = a.feedbacks;
            a1.file = a.file;
            a1.reactps = a.reactps;
            a1.statut = a.statut;
            a1.reactps = a.reactps;


            if (ModelState.IsValid)
            {
                publicationService.Update(a1);
                publicationService.Commit();

                return RedirectToAction("allPub");

            }

            return RedirectToAction("allPub");
        }

        // GET: Publication/Delete/5
        public ActionResult Delete(int id)
        {
            publication pp = db.publications.Find(id);
            
           //db.feedbacks.Remove( db.feedbacks.Where(c => c.publication_id.Equals(id)));
           // db.SaveChanges();

           // db.reactps.RemoveRange(db.reactps.Where(c => c.publication_id.Equals(id)));
           // db.SaveChanges();

            db.publications.Remove(pp);
            db.SaveChanges();

            //  var r = publicationService.GetById(id);
            ////  List<feedback> = db.feedbacks.Single(s => s.publication_id.Equals(id));
            //  publicationService.Delete(r);
            //  publicationService.Commit();
            return RedirectToAction("allPub", "Publication");
        }

        // POST: Publication/Delete/5
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
