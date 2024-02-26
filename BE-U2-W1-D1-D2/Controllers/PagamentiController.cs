using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BE_U2_W1_D1_D2.Controllers
{
    public class PagamentiController : Controller
    {
        // GET: Pagamenti
        public ActionResult Index()
        {
            private ApplicationDbContext db = new ApplicationDbContext(); //Assuming ApplicationDbContext is your EF context

        public ActionResult Index()
        {
            var payments = db.Payments.ToList();
            return View(payments);
        }

        public ActionResult Create()
        {
            // Assuming you have a dropdown list to select the employee for the payment
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "Nome");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Payment payment)
        {
            if (ModelState.IsValid)
            {
                db.Payments.Add(payment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "Nome", payment.EmployeeId);
            return View(payment);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payment payment = db.Payments.Find(id);
            if (payment == null)
            {
                return HttpNotFound();
            }
            return View(payment);
        }

        // Implementa le azioni per Update e Delete
    }
}
}