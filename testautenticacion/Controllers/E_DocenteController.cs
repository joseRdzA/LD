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
    public class E_DocenteController : Controller
    {
        private AADFLDEntities db = new AADFLDEntities();

        public ActionResult EvaluacionDocente()
        {

            var e_Docente = db.E_Docente.Include(e => e.E_Tipo);
            return View(e_Docente.ToList());

        }
        // GET: E_Docente
        public ActionResult Index()
        {
            var e_Docente = db.E_Docente.Include(e => e.E_Tipo);
            return View(e_Docente.ToList());
        }

        // GET: E_Docente/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            E_Docente e_Docente = db.E_Docente.Find(id);
            if (e_Docente == null)
            {
                return HttpNotFound();
            }
            return View(e_Docente);
        }

        // GET: E_Docente/Create
        public ActionResult Create()
        {
            ViewBag.Tipo = new SelectList(db.E_Tipo, "ID", "Nombre");
            return View();
        }

        // POST: E_Docente/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nombre,Tipo")] E_Docente e_Docente)
        {
            if (ModelState.IsValid)
            {
                db.E_Docente.Add(e_Docente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Tipo = new SelectList(db.E_Tipo, "ID", "Nombre", e_Docente.Tipo);
            return View(e_Docente);
        }

        // GET: E_Docente/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            E_Docente e_Docente = db.E_Docente.Find(id);
            if (e_Docente == null)
            {
                return HttpNotFound();
            }
            ViewBag.Tipo = new SelectList(db.E_Tipo, "ID", "Nombre", e_Docente.Tipo);
            return View(e_Docente);
        }

        // POST: E_Docente/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nombre,Tipo")] E_Docente e_Docente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(e_Docente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Tipo = new SelectList(db.E_Tipo, "ID", "Nombre", e_Docente.Tipo);
            return View(e_Docente);
        }

        // GET: E_Docente/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            E_Docente e_Docente = db.E_Docente.Find(id);
            if (e_Docente == null)
            {
                return HttpNotFound();
            }
            return View(e_Docente);
        }

        // POST: E_Docente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            E_Docente e_Docente = db.E_Docente.Find(id);
            db.E_Docente.Remove(e_Docente);
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
