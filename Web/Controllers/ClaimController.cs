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

namespace Web.Controllers
{
    public class ClaimController : Controller
    {
        IClaimService CS;
        IEvalService EV;
        IUserService US;
        
        private Statut ouvert;
        
        public ClaimController()
        {
            CS = new ClaimService();
            EV = new EvalService();
            US= new UserService();
        }
        // GET: Claim
        public ActionResult Index()
        {
            return View(CS.GetAll());
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
            ViewBag.evaluation_id = new SelectList(ListEval, "id ", "Titre_Eval");
            //return list deroulent users name
            var ListUser = US.GetAll();
            ViewBag.user_id = new SelectList(ListUser, "id ", "nom"+ "prenom");

            return View();
        }

        // POST: Claim/Create
        [HttpPost]
        public ActionResult Create(reclamation claim, HttpPostedFileBase file)
        {
            claim.statut = ouvert;
            DateTime dateouvr = DateTime.Now;
            claim.dateopen = dateouvr;
            // //file
            //claim.fich = file.FileName;
            // if (file.ContentLength > 0)

            // {
            //     var path = Path.Combine(Server.MapPath("~/Content/upload"), file.FileName);
            //     file.SaveAs(path);
            // }

            CS.Add(claim);
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
           // mailMessage.Subject = "Information sur votre Reclamtion";
           // var body = "<p>Merci pour votre reclamation ,Pour bien suivi votre réclamation ,ç'est votre numéro de ticket: {0} ,Date d'ouverture {1}</p>";
           // mailMessage.IsBodyHtml = true;
           // mailMessage.Body = string.Format(body, claim.ReclmationID, claim.dateopen);
           //// mailMessage.Body = "thanks for your claim";
           // NetworkCredential nc = new NetworkCredential("projectd308@gmail.com", "1234578/*" );
           // client.Credentials = nc;
           // client.Send(mailMessage);


            return RedirectToAction("Create");

        }

        // GET: Claim/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Claim/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, reclamation claim)
        {
            try
            {
                //DateTime dateclot = DateTime.Now;
                //claim.dateclose = dateclot;

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Claim/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Claim/Delete/5
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
