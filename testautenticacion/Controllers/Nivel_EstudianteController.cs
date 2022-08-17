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
    public class Nivel_EstudianteController : Controller
    {
        private AADFLDEntities db = new AADFLDEntities();

        // GET: Nivel_Estudiante
        public ActionResult Index()
        {
            return View(db.Nivel_Estudiante.ToList());
        }

        // GET: Nivel_Estudiante/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nivel_Estudiante nivel_Estudiante = db.Nivel_Estudiante.Find(id);
            if (nivel_Estudiante == null)
            {
                return HttpNotFound();
            }
            return View(nivel_Estudiante);
        }

        // GET: Nivel_Estudiante/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Nivel_Estudiante/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nivel")] Nivel_Estudiante nivel_Estudiante)
        {
            if (ModelState.IsValid)
            {
                db.Nivel_Estudiante.Add(nivel_Estudiante);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nivel_Estudiante);
        }

        // GET: Nivel_Estudiante/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nivel_Estudiante nivel_Estudiante = db.Nivel_Estudiante.Find(id);
            if (nivel_Estudiante == null)
            {
                return HttpNotFound();
            }
            return View(nivel_Estudiante);
        }

        // POST: Nivel_Estudiante/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nivel")] Nivel_Estudiante nivel_Estudiante)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nivel_Estudiante).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nivel_Estudiante);
        }

        // GET: Nivel_Estudiante/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nivel_Estudiante nivel_Estudiante = db.Nivel_Estudiante.Find(id);
            if (nivel_Estudiante == null)
            {
                return HttpNotFound();
            }
            return View(nivel_Estudiante);
        }

        // POST: Nivel_Estudiante/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Nivel_Estudiante nivel_Estudiante = db.Nivel_Estudiante.Find(id);
            db.Nivel_Estudiante.Remove(nivel_Estudiante);
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
