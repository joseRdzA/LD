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
    public class E_AsitenteController : Controller
    {
        private AADFLDEntities db = new AADFLDEntities();



        public ActionResult EvaluacionAsistente()
        {

            var e_Asitente = db.E_Asitente.Include(e => e.E_Tipo);
            return View(e_Asitente.ToList());

        }

        // GET: E_Asitente
        public ActionResult Index()
        {
            var e_Asitente = db.E_Asitente.Include(e => e.E_Tipo);
            return View(e_Asitente.ToList());
        }

        // GET: E_Asitente/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            E_Asitente e_Asitente = db.E_Asitente.Find(id);
            if (e_Asitente == null)
            {
                return HttpNotFound();
            }
            return View(e_Asitente);
        }

        // GET: E_Asitente/Create
        public ActionResult Create()
        {
            ViewBag.Tipo = new SelectList(db.E_Tipo, "ID", "Nombre");
            return View();
        }

        // POST: E_Asitente/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nombre,Tipo")] E_Asitente e_Asitente)
        {
            if (ModelState.IsValid)
            {
                db.E_Asitente.Add(e_Asitente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Tipo = new SelectList(db.E_Tipo, "ID", "Nombre", e_Asitente.Tipo);
            return View(e_Asitente);
        }

        // GET: E_Asitente/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            E_Asitente e_Asitente = db.E_Asitente.Find(id);
            if (e_Asitente == null)
            {
                return HttpNotFound();
            }
            ViewBag.Tipo = new SelectList(db.E_Tipo, "ID", "Nombre", e_Asitente.Tipo);
            return View(e_Asitente);
        }

        // POST: E_Asitente/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nombre,Tipo")] E_Asitente e_Asitente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(e_Asitente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Tipo = new SelectList(db.E_Tipo, "ID", "Nombre", e_Asitente.Tipo);
            return View(e_Asitente);
        }

        // GET: E_Asitente/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            E_Asitente e_Asitente = db.E_Asitente.Find(id);
            if (e_Asitente == null)
            {
                return HttpNotFound();
            }
            return View(e_Asitente);
        }

        // POST: E_Asitente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            E_Asitente e_Asitente = db.E_Asitente.Find(id);
            db.E_Asitente.Remove(e_Asitente);
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
