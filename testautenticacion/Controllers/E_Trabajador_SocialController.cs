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
    public class E_Trabajador_SocialController : Controller
    {
        private AADFLDEntities db = new AADFLDEntities();


        public ActionResult EvaluacionTrabajador_Social()
        {

            var e_Trabajador_Social = db.E_Trabajador_Social.Include(e => e.E_Tipo);
            return View(e_Trabajador_Social.ToList());

        }

        // GET: E_Trabajador_Social
        public ActionResult Index()
        {
            var e_Trabajador_Social = db.E_Trabajador_Social.Include(e => e.E_Tipo);
            return View(e_Trabajador_Social.ToList());
        }

        // GET: E_Trabajador_Social/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            E_Trabajador_Social e_Trabajador_Social = db.E_Trabajador_Social.Find(id);
            if (e_Trabajador_Social == null)
            {
                return HttpNotFound();
            }
            return View(e_Trabajador_Social);
        }

        // GET: E_Trabajador_Social/Create
        public ActionResult Create()
        {
            ViewBag.Tipo = new SelectList(db.E_Tipo, "ID", "Nombre");
            return View();
        }

        // POST: E_Trabajador_Social/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nombre,Tipo")] E_Trabajador_Social e_Trabajador_Social)
        {
            if (ModelState.IsValid)
            {
                db.E_Trabajador_Social.Add(e_Trabajador_Social);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Tipo = new SelectList(db.E_Tipo, "ID", "Nombre", e_Trabajador_Social.Tipo);
            return View(e_Trabajador_Social);
        }

        // GET: E_Trabajador_Social/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            E_Trabajador_Social e_Trabajador_Social = db.E_Trabajador_Social.Find(id);
            if (e_Trabajador_Social == null)
            {
                return HttpNotFound();
            }
            ViewBag.Tipo = new SelectList(db.E_Tipo, "ID", "Nombre", e_Trabajador_Social.Tipo);
            return View(e_Trabajador_Social);
        }

        // POST: E_Trabajador_Social/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nombre,Tipo")] E_Trabajador_Social e_Trabajador_Social)
        {
            if (ModelState.IsValid)
            {
                db.Entry(e_Trabajador_Social).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Tipo = new SelectList(db.E_Tipo, "ID", "Nombre", e_Trabajador_Social.Tipo);
            return View(e_Trabajador_Social);
        }

        // GET: E_Trabajador_Social/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            E_Trabajador_Social e_Trabajador_Social = db.E_Trabajador_Social.Find(id);
            if (e_Trabajador_Social == null)
            {
                return HttpNotFound();
            }
            return View(e_Trabajador_Social);
        }

        // POST: E_Trabajador_Social/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            E_Trabajador_Social e_Trabajador_Social = db.E_Trabajador_Social.Find(id);
            db.E_Trabajador_Social.Remove(e_Trabajador_Social);
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
