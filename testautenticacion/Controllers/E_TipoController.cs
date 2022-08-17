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
   // [Authorize]
    public class E_TipoController : Controller
    {
        private AADFLDEntities db = new AADFLDEntities();

        // GET: E_Tipo
        public ActionResult Index()
        {
            return View(db.E_Tipo.ToList());
        }

        // GET: E_Tipo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            E_Tipo e_Tipo = db.E_Tipo.Find(id);
            if (e_Tipo == null)
            {
                return HttpNotFound();
            }
            return View(e_Tipo);
        }

        // GET: E_Tipo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: E_Tipo/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nombre")] E_Tipo e_Tipo)
        {
            if (ModelState.IsValid)
            {
                db.E_Tipo.Add(e_Tipo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(e_Tipo);
        }

        // GET: E_Tipo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            E_Tipo e_Tipo = db.E_Tipo.Find(id);
            if (e_Tipo == null)
            {
                return HttpNotFound();
            }
            return View(e_Tipo);
        }

        // POST: E_Tipo/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nombre")] E_Tipo e_Tipo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(e_Tipo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(e_Tipo);
        }

        // GET: E_Tipo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            E_Tipo e_Tipo = db.E_Tipo.Find(id);
            if (e_Tipo == null)
            {
                return HttpNotFound();
            }
            return View(e_Tipo);
        }

        // POST: E_Tipo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            E_Tipo e_Tipo = db.E_Tipo.Find(id);
            db.E_Tipo.Remove(e_Tipo);
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
