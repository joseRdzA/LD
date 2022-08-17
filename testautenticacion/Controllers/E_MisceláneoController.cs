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
    public class E_MisceláneoController : Controller
    {
        private AADFLDEntities db = new AADFLDEntities();


        public ActionResult EvaluacionMisceláneo()
        {

            var e_Miscelanea = db.E_Miscelanea.Include(e => e.E_Tipo);
            return View(e_Miscelanea.ToList());

        }

        // GET: E_Misceláneo
        public ActionResult Index()
        {
            var e_Miscelanea = db.E_Miscelanea.Include(e => e.E_Tipo);
            return View(e_Miscelanea.ToList());
        }

        // GET: E_Misceláneo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            E_Miscelanea e_Miscelanea = db.E_Miscelanea.Find(id);
            if (e_Miscelanea == null)
            {
                return HttpNotFound();
            }
            return View(e_Miscelanea);
        }

        // GET: E_Misceláneo/Create
        public ActionResult Create()
        {
            ViewBag.Tipo = new SelectList(db.E_Tipo, "ID", "Nombre");
            return View();
        }

        // POST: E_Misceláneo/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nombre,Tipo")] E_Miscelanea e_Miscelanea)
        {
            if (ModelState.IsValid)
            {
                db.E_Miscelanea.Add(e_Miscelanea);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Tipo = new SelectList(db.E_Tipo, "ID", "Nombre", e_Miscelanea.Tipo);
            return View(e_Miscelanea);
        }

        // GET: E_Misceláneo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            E_Miscelanea e_Miscelanea = db.E_Miscelanea.Find(id);
            if (e_Miscelanea == null)
            {
                return HttpNotFound();
            }
            ViewBag.Tipo = new SelectList(db.E_Tipo, "ID", "Nombre", e_Miscelanea.Tipo);
            return View(e_Miscelanea);
        }

        // POST: E_Misceláneo/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nombre,Tipo")] E_Miscelanea e_Miscelanea)
        {
            if (ModelState.IsValid)
            {
                db.Entry(e_Miscelanea).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Tipo = new SelectList(db.E_Tipo, "ID", "Nombre", e_Miscelanea.Tipo);
            return View(e_Miscelanea);
        }

        // GET: E_Misceláneo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            E_Miscelanea e_Miscelanea = db.E_Miscelanea.Find(id);
            if (e_Miscelanea == null)
            {
                return HttpNotFound();
            }
            return View(e_Miscelanea);
        }

        // POST: E_Misceláneo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            E_Miscelanea e_Miscelanea = db.E_Miscelanea.Find(id);
            db.E_Miscelanea.Remove(e_Miscelanea);
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
