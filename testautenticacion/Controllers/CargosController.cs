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
    public class CargosController : Controller
    {
        private AADFLDEntities db = new AADFLDEntities();

        // GET: Cargos
        public ActionResult Index()
        {
            return View(db.Cargos.ToList());
        }

        // GET: Cargos/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cargos cargos = db.Cargos.Find(id);
            if (cargos == null)
            {
                return HttpNotFound();
            }
            return View(cargos);
        }

        // GET: Cargos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cargos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Cargo,Nombre_Cargo")] Cargos cargos)
        {
            if (ModelState.IsValid)
            {
                db.Cargos.Add(cargos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cargos);
        }

        // GET: Cargos/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cargos cargos = db.Cargos.Find(id);
            if (cargos == null)
            {
                return HttpNotFound();
            }
            return View(cargos);
        }

        // POST: Cargos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Cargo,Nombre_Cargo")] Cargos cargos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cargos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cargos);
        }

        // GET: Cargos/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cargos cargos = db.Cargos.Find(id);
            if (cargos == null)
            {
                return HttpNotFound();
            }
            return View(cargos);
        }

        // POST: Cargos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Cargos cargos = db.Cargos.Find(id);
            db.Cargos.Remove(cargos);
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
