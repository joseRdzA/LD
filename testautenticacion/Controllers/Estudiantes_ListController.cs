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
    public class Estudiantes_ListController : Controller
    {
        private AADFLDEntities db = new AADFLDEntities();

        // GET: Estudiantes_List
        public ActionResult Index()
        {
            var estudiantes_List = db.Estudiantes_List.Include(e => e.Nivel_Estudiante);
            return View(estudiantes_List.ToList());
        }

        // GET: Estudiantes_List/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estudiantes_List estudiantes_List = db.Estudiantes_List.Find(id);
            if (estudiantes_List == null)
            {
                return HttpNotFound();
            }
            return View(estudiantes_List);
        }

        // GET: Estudiantes_List/Create
        public ActionResult Create()
        {
            ViewBag.Nivel = new SelectList(db.Nivel_Estudiante, "ID", "Nivel");
            return View();
        }

        // POST: Estudiantes_List/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nombre_Estudiante,Cedula,fechaNacimiento,Numero_Contacto,Nivel")] Estudiantes_List estudiantes_List)
        {
            if (ModelState.IsValid)
            {
                db.Estudiantes_List.Add(estudiantes_List);
                db.SaveChanges();
                return RedirectToAction("Index", "Estudiantes");
            }

            ViewBag.Nivel = new SelectList(db.Nivel_Estudiante, "ID", "Nivel", estudiantes_List.Nivel);
            return View(estudiantes_List);
        }

        // GET: Estudiantes_List/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estudiantes_List estudiantes_List = db.Estudiantes_List.Find(id);
            if (estudiantes_List == null)
            {
                return HttpNotFound();
            }
            ViewBag.Nivel = new SelectList(db.Nivel_Estudiante, "ID", "Nivel", estudiantes_List.Nivel);
            return View(estudiantes_List);
        }

        // POST: Estudiantes_List/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nombre_Estudiante,Cedula,fechaNacimiento,Numero_Contacto,Nivel")] Estudiantes_List estudiantes_List)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estudiantes_List).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Estudiantes");
            }
            ViewBag.Nivel = new SelectList(db.Nivel_Estudiante, "ID", "Nivel", estudiantes_List.Nivel);
            return View(estudiantes_List);
        }

        // GET: Estudiantes_List/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estudiantes_List estudiantes_List = db.Estudiantes_List.Find(id);
            if (estudiantes_List == null)
            {
                return HttpNotFound();
            }
            return View(estudiantes_List);
        }

        // POST: Estudiantes_List/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Estudiantes_List estudiantes_List = db.Estudiantes_List.Find(id);
            db.Estudiantes_List.Remove(estudiantes_List);
            db.SaveChanges();
            return RedirectToAction("Index", "Estudiantes");
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
