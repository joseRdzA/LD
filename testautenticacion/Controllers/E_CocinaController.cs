using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using testautenticacion.Models;
using testautenticacion.Permisos;

namespace testautenticacion.Controllers
{
    [Authorize]
    [PermisosRol(Rol1.Administrador)]
    public class E_CocinaController : Controller
    {
        private AADFLDEntities db = new AADFLDEntities();

        public ActionResult EvaluacionCocina()
        {

            var e_Cocina = db.E_Cocina.Include(e => e.E_Tipo);
            return View(e_Cocina.ToList());

        }

        // GET: E_Cocina
        public ActionResult Index()
        {
            var e_Cocina = db.E_Cocina.Include(e => e.E_Tipo);
            return View(e_Cocina.ToList());
        }

        // GET: E_Cocina/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            E_Cocina e_Cocina = db.E_Cocina.Find(id);
            if (e_Cocina == null)
            {
                return HttpNotFound();
            }
            return View(e_Cocina);
        }

        // GET: E_Cocina/Create
        public ActionResult Create()
        {
            ViewBag.Tipo = new SelectList(db.E_Tipo, "ID", "Nombre");
            return View();
        }

        // POST: E_Cocina/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nombre,Tipo")] E_Cocina e_Cocina)
        {
            if (ModelState.IsValid)
            {
                db.E_Cocina.Add(e_Cocina);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Tipo = new SelectList(db.E_Tipo, "ID", "Nombre", e_Cocina.Tipo);
            return View(e_Cocina);
        }

        // GET: E_Cocina/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            E_Cocina e_Cocina = db.E_Cocina.Find(id);
            if (e_Cocina == null)
            {
                return HttpNotFound();
            }
            ViewBag.Tipo = new SelectList(db.E_Tipo, "ID", "Nombre", e_Cocina.Tipo);
            return View(e_Cocina);
        }

        // POST: E_Cocina/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nombre,Tipo")] E_Cocina e_Cocina)
        {
            if (ModelState.IsValid)
            {
                db.Entry(e_Cocina).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Tipo = new SelectList(db.E_Tipo, "ID", "Nombre", e_Cocina.Tipo);
            return View(e_Cocina);
        }

        // GET: E_Cocina/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            E_Cocina e_Cocina = db.E_Cocina.Find(id);
            if (e_Cocina == null)
            {
                return HttpNotFound();
            }
            return View(e_Cocina);
        }

        // POST: E_Cocina/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            E_Cocina e_Cocina = db.E_Cocina.Find(id);
            db.E_Cocina.Remove(e_Cocina);
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
