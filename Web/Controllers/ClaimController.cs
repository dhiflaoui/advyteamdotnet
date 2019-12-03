using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service;
using System.IO;
using System.Net;
using System.Net.Mail;
using Data;
using System.Data.Entity;

namespace Web.Controllers
{
    public class ClaimController : Controller
    {
        IClaimService CS;
        IEvalService EV;
        IUserService US;
        
        

        private AdvyteamContext db = new AdvyteamContext();
        public ClaimController()
        {
            CS = new ClaimService();
            EV = new EvalService();
            US= new UserService();
        }

        // GET: Claim
        public ActionResult Index()
        {
            int o = (int)Statut.Ouvert; 
            int r = (int)Statut.Resolu;
            int e = (int)Statut.Enattente;
            int c = (int)Statut.Cloture;
            return View(CS.GetAll());
        }



        [HttpPost]
        public ActionResult Index(string searchString)
        {
            IEnumerable<reclamation> reclamations = CS.GetAll();

            if (!String.IsNullOrEmpty(searchString))
            {
                reclamations = reclamations.Where(m => m.user_id.ToString().Contains(searchString)).ToList();
            }
            return View(reclamations);
        }

        // GET: Claim/Details/5
        public ActionResult Details(int id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //var claim = from p in db.PurchaseItems
            //                where p.ReclamationID == id
            //                select p;
            //if (claim == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(claim.ToList());
            return View();
        }

        // GET: Claim/Create
        public ActionResult Create()
        {
            //return list deroulent de evaluation
            var ListEval = EV.GetAll();
            ViewBag.EvaluationId = new SelectList(ListEval, "id ", "Titre_Eval");
            //return list deroulent users name
            var ListUser = US.GetAll();
            ViewBag.UserID = new SelectList(ListUser, "id ", "nom");

            return View();
        }

        // POST: Claim/Create
        [HttpPost]
        public ActionResult Create(reclamation claim, HttpPostedFileBase file)
        {
            int evid = Int32.Parse(Request.Form["EvaluationId"].ToString());
            int usid = Int32.Parse(Request.Form["UserID"].ToString());

            string s = ((int)claim.statut).ToString();
            var score = EV.GetAll().Where(m => m.id == evid).Any(x => x.score_Manager >= 15);
           if(score)
            {
                claim.user_id = usid ;
                claim.evaluation_id = evid;
                claim.statut = Statut.Ouvert;
                DateTime dateouvr = DateTime.Now;
                claim.dateopen = dateouvr;
                 //file
                claim.fich = file.FileName;
                CS.Add(claim);
                 if (file.ContentLength > 0)

                 {
                     var path = Path.Combine(Server.MapPath("~/Content/upload"), file.FileName);
                     file.SaveAs(path);
                 }

                //CS.Add(claim);
                CS.Commit();


                // //mail send
                // SmtpClient client = new SmtpClient();
                // client.Host = "smtp.gmail.com";
                // client.Port = 587;
                // client.UseDefaultCredentials = false;
                // client.EnableSsl = true;
                // MailMessage mailMessage = new MailMessage();
                // mailMessage.From = new MailAddress("projectd308@gmail.com");
                // mailMessage.To.Add("dhiflaoui.belgacem@gmail.com");
                // mailMessage.Subject = "Reclamtion enregistrée avec succès";
                // var body = "<p>Merci pour votre reclamation ,Pour bien suivi votre réclamation ,ç'est votre numéro de ticket: "{0}" ,Date d'ouverture du reclamation est le {1}</p>";
                // mailMessage.IsBodyHtml = true;
                // mailMessage.Body = string.Format(body, claim.ReclmationID, claim.dateopen);
                //// mailMessage.Body = "thanks for your claim";
                // NetworkCredential nc = new NetworkCredential("projectd308@gmail.com", "1234578/*" );
                // client.Credentials = nc;
                // client.Send(mailMessage);


                return RedirectToAction("Index");
            }
            
            else
            {
                return RedirectToAction("Create");
            }
            

        }

        // GET: Claim/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reclamation claim = db.reclamations.Find(id);
            if (claim == null)
            {
                return HttpNotFound();
            }
            return View(claim);
        }

        // POST: Claim/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReclmationID,titreclaim,descp,fich,comment,reponse")] reclamation claim)
        {
            
            if (ModelState.IsValid)
            {
                claim.statut = Statut.Enattente;
                db.Entry(claim).State = EntityState.Modified;
                db.SaveChanges();
               
            }
            return RedirectToAction("Index");
            //return View(claim);
        }

        // GET: Claim/Edit/5
        public ActionResult Edit2(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reclamation claim = db.reclamations.Find(id);
            if (claim == null)
            {
                return HttpNotFound();
            }
            return View(claim);
        }

        // POST: Claim/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit2([Bind(Include = "ReclmationID,titreclaim,descp,fich,comment,reponse")] reclamation claim)
        {

            if (ModelState.IsValid)
            {
                DateTime dateclot = DateTime.Now;
                claim.dateclose = dateclot;
                claim.statut = Statut.Cloture;
                db.Entry(claim).State = EntityState.Modified;
                db.SaveChanges();
              
            }
            return RedirectToAction("Index");
        }





        //// GET: Claim/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    reclamation claim = db.reclamations.Find(id);
        //    return View(claim);
        //}

        //// POST: Claim/Delete/5
        //[HttpPost]
        //public ActionResult Delete([Bind(Include = "ReclmationID,titreclaim,descp,fich,comment,reponse")]reclamation claim)
        //{
        //    DateTime dateclot = DateTime.Now;
        //    claim.dateclose = dateclot;
        //    claim.statut = Statut.Cloture;
        //    //CS.Add(claim);
        //    //CS.Commit();        
        //    db.Entry(claim).State = EntityState.Modified;
        //    db.SaveChanges();

        //    return RedirectToAction("Index");
        //}
    }
}
