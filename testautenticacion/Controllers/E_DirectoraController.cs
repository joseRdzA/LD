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
    public class E_DirectoraController : Controller
    {
        private AADFLDEntities db = new AADFLDEntities();


        public ActionResult EvaluacionDirectora()
        {

            var e_Directora = db.E_Directora.Include(e => e.E_Tipo);
            return View(e_Directora.ToList());

        }
        // GET: E_Directora
        public ActionResult Index()
        {
            var e_Directora = db.E_Directora.Include(e => e.E_Tipo);
            return View(e_Directora.ToList());
        }

        // GET: E_Directora/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            E_Directora e_Directora = db.E_Directora.Find(id);
            if (e_Directora == null)
            {
                return HttpNotFound();
            }
            return View(e_Directora);
        }

        // GET: E_Directora/Create
        public ActionResult Create()
        {
            ViewBag.Tipo = new SelectList(db.E_Tipo, "ID", "Nombre");
            return View();
        }

        // POST: E_Directora/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nombre,Tipo")] E_Directora e_Directora)
        {
            if (ModelState.IsValid)
            {
                db.E_Directora.Add(e_Directora);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Tipo = new SelectList(db.E_Tipo, "ID", "Nombre", e_Directora.Tipo);
            return View(e_Directora);
        }

        // GET: E_Directora/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            E_Directora e_Directora = db.E_Directora.Find(id);
            if (e_Directora == null)
            {
                return HttpNotFound();
            }
            ViewBag.Tipo = new SelectList(db.E_Tipo, "ID", "Nombre", e_Directora.Tipo);
            return View(e_Directora);
        }

        // POST: E_Directora/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nombre,Tipo")] E_Directora e_Directora)
        {
            if (ModelState.IsValid)
            {
                db.Entry(e_Directora).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Tipo = new SelectList(db.E_Tipo, "ID", "Nombre", e_Directora.Tipo);
            return View(e_Directora);
        }

        // GET: E_Directora/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            E_Directora e_Directora = db.E_Directora.Find(id);
            if (e_Directora == null)
            {
                return HttpNotFound();
            }
            return View(e_Directora);
        }

        // POST: E_Directora/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            E_Directora e_Directora = db.E_Directora.Find(id);
            db.E_Directora.Remove(e_Directora);
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
