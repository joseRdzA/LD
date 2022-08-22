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
    public class E_PsicologiaController : Controller
    {
        private AADFLDEntities db = new AADFLDEntities();




        public ActionResult EvaluacionPsicologia()
        {

            var e_Psicologia = db.E_Psicologia.Include(e => e.E_Tipo).OrderBy(x => x.Tipo);
            return View(e_Psicologia.ToList());

        }

        // GET: E_Psicologia
        public ActionResult Index()
        {
            var e_Psicologia = db.E_Psicologia.Include(e => e.E_Tipo);
            return View(e_Psicologia.ToList());
        }

        // GET: E_Psicologia/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            E_Psicologia e_Psicologia = db.E_Psicologia.Find(id);
            if (e_Psicologia == null)
            {
                return HttpNotFound();
            }
            return View(e_Psicologia);
        }

        // GET: E_Psicologia/Create
        public ActionResult Create()
        {
            ViewBag.Tipo = new SelectList(db.E_Tipo, "ID", "Nombre");
            return View();
        }

        // POST: E_Psicologia/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nombre,Tipo")] E_Psicologia e_Psicologia)
        {
            if (ModelState.IsValid)
            {
                db.E_Psicologia.Add(e_Psicologia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Tipo = new SelectList(db.E_Tipo, "ID", "Nombre", e_Psicologia.Tipo);
            return View(e_Psicologia);
        }

        // GET: E_Psicologia/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            E_Psicologia e_Psicologia = db.E_Psicologia.Find(id);
            if (e_Psicologia == null)
            {
                return HttpNotFound();
            }
            ViewBag.Tipo = new SelectList(db.E_Tipo, "ID", "Nombre", e_Psicologia.Tipo);
            return View(e_Psicologia);
        }

        // POST: E_Psicologia/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nombre,Tipo")] E_Psicologia e_Psicologia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(e_Psicologia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Tipo = new SelectList(db.E_Tipo, "ID", "Nombre", e_Psicologia.Tipo);
            return View(e_Psicologia);
        }

        // GET: E_Psicologia/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            E_Psicologia e_Psicologia = db.E_Psicologia.Find(id);
            if (e_Psicologia == null)
            {
                return HttpNotFound();
            }
            return View(e_Psicologia);
        }

        // POST: E_Psicologia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            E_Psicologia e_Psicologia = db.E_Psicologia.Find(id);
            db.E_Psicologia.Remove(e_Psicologia);
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
