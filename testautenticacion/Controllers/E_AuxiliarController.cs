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
    public class E_AuxiliarController : Controller
    {
        private AADFLDEntities db = new AADFLDEntities();
        public ActionResult EvaluacionAuxiliar()
        {

            var e_Auxiliar = db.E_Auxiliar.Include(e => e.E_Tipo);
            return View(e_Auxiliar.ToList());

        }
        // GET: E_Auxiliar
        public ActionResult Index()
        {
            var e_Auxiliar = db.E_Auxiliar.Include(e => e.E_Tipo);
            return View(e_Auxiliar.ToList());
        }

        // GET: E_Auxiliar/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            E_Auxiliar e_Auxiliar = db.E_Auxiliar.Find(id);
            if (e_Auxiliar == null)
            {
                return HttpNotFound();
            }
            return View(e_Auxiliar);
        }

        // GET: E_Auxiliar/Create
        public ActionResult Create()
        {
            ViewBag.Tipo = new SelectList(db.E_Tipo, "ID", "Nombre");
            return View();
        }

        // POST: E_Auxiliar/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nombre,Tipo")] E_Auxiliar e_Auxiliar)
        {
            if (ModelState.IsValid)
            {
                db.E_Auxiliar.Add(e_Auxiliar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Tipo = new SelectList(db.E_Tipo, "ID", "Nombre", e_Auxiliar.Tipo);
            return View(e_Auxiliar);
        }

        // GET: E_Auxiliar/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            E_Auxiliar e_Auxiliar = db.E_Auxiliar.Find(id);
            if (e_Auxiliar == null)
            {
                return HttpNotFound();
            }
            ViewBag.Tipo = new SelectList(db.E_Tipo, "ID", "Nombre", e_Auxiliar.Tipo);
            return View(e_Auxiliar);
        }

        // POST: E_Auxiliar/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nombre,Tipo")] E_Auxiliar e_Auxiliar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(e_Auxiliar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Tipo = new SelectList(db.E_Tipo, "ID", "Nombre", e_Auxiliar.Tipo);
            return View(e_Auxiliar);
        }

        // GET: E_Auxiliar/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            E_Auxiliar e_Auxiliar = db.E_Auxiliar.Find(id);
            if (e_Auxiliar == null)
            {
                return HttpNotFound();
            }
            return View(e_Auxiliar);
        }

        // POST: E_Auxiliar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            E_Auxiliar e_Auxiliar = db.E_Auxiliar.Find(id);
            db.E_Auxiliar.Remove(e_Auxiliar);
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
