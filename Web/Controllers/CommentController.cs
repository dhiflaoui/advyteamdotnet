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
    public class CommentController : Controller
    {
        private AdvyteamContext db = new AdvyteamContext();

        IFeedbackService fb;

        //  ILikeService lp;
        public CommentController()
        {
            //  lp = new LikeService();
            fb = new FeedbackService();

        }
        [HttpPost]
        public ActionResult Comment(feedback f, HttpPostedFileBase file1, int id)
        {
            f.user_id = LoginController.currentUser.id;
            f.date = DateTime.Now;
            f.publication_id = id;
            try
            {
                if (file1.ContentLength > 0)
                {
                    f.file = file1.FileName;

                    var path = Path.Combine(Server.MapPath("~/Content/upload/"), file1.FileName);
                    file1.SaveAs(path);
                }
                fb.Add(f);
             //   int nbr = db.publications.Where(p => p.user_id == f.publication.user_id && )

                fb.Commit();
                return RedirectToAction("allPub", "Publication");
            }
            catch (Exception ex)
            {
                fb.Add(f);

                fb.Commit();
                return RedirectToAction("allPub", "Publication");

            }

        }

        public int Count(int idp)
        {
            return fb.nb_Comment(idp);
        }
        public String super(int idpu, int idu)
        {
           //IQueryable<feedback> query =
           //     from fe in db.feedbacks where fe.user_id.Equals(idu)
           //    join pub in db.publications o
           //    join us in db.users on 
           //     select emp;

            //return View(query.ToList());
            if (fb.superFun(idpu, idu) == 3)
            { return "Super Fun"; }
            else return "";
        }
        // GET: Comment
        [HttpPost]
        public List<feedback> allComment(int idp)
        {

            
            
                List<feedback> myList = (db.feedbacks.Where(com => com.publication_id == idp).ToList());

            return myList;
           
            /*    feedback fd = new feedback { publication_id = idp };
                FeedbackService fs;
                fs.GetMany();
              */      //return Json(new { data= ViewBag.result}, JsonRequestBehavior.AllowGet);
        }

        // GET: Comment/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Comment/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Comment/Create
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

        // GET: Comment/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Comment/Edit/5
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

        // GET: Comment/Delete/5
        public ActionResult Delete(int id)
        {
            var r = fb.GetById(id);
            fb.Delete(r);
            fb.Commit();
            return RedirectToAction("allPub", "Publication");
        }

        // POST: Comment/Delete/5
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
