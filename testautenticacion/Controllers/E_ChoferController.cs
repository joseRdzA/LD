using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using testautenticacion.Models;

namespace testautenticacion.Controllers
{
    [Authorize]
    public class E_ChoferController : Controller
    {
        private AADFLDEntities db = new AADFLDEntities();

        public ActionResult EvaluacionChofer()
        {

            var e_Chofer = db.E_Chofer.Include(e => e.E_Tipo);
            return View(e_Chofer.ToList());

        }

        // GET: E_Chofer
        public ActionResult Index()
        {
            var e_Chofer = db.E_Chofer.Include(e => e.E_Tipo);
            return View(e_Chofer.ToList());
        }

        // GET: E_Chofer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            E_Chofer e_Chofer = db.E_Chofer.Find(id);
            if (e_Chofer == null)
            {
                return HttpNotFound();
            }
            return View(e_Chofer);
        }

        // GET: E_Chofer/Create
        public ActionResult Create()
        {
            ViewBag.Tipo = new SelectList(db.E_Tipo, "ID", "Nombre");
            return View();
        }

        // POST: E_Chofer/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nombre,Tipo")] E_Chofer e_Chofer)
        {
            if (ModelState.IsValid)
            {
                db.E_Chofer.Add(e_Chofer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Tipo = new SelectList(db.E_Tipo, "ID", "Nombre", e_Chofer.Tipo);
            return View(e_Chofer);
        }

        // GET: E_Chofer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            E_Chofer e_Chofer = db.E_Chofer.Find(id);
            if (e_Chofer == null)
            {
                return HttpNotFound();
            }
            ViewBag.Tipo = new SelectList(db.E_Tipo, "ID", "Nombre", e_Chofer.Tipo);
            return View(e_Chofer);
        }

        // POST: E_Chofer/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nombre,Tipo")] E_Chofer e_Chofer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(e_Chofer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Tipo = new SelectList(db.E_Tipo, "ID", "Nombre", e_Chofer.Tipo);
            return View(e_Chofer);
        }

        // GET: E_Chofer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            E_Chofer e_Chofer = db.E_Chofer.Find(id);
            if (e_Chofer == null)
            {
                return HttpNotFound();
            }
            return View(e_Chofer);
        }

        // POST: E_Chofer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            E_Chofer e_Chofer = db.E_Chofer.Find(id);
            db.E_Chofer.Remove(e_Chofer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
