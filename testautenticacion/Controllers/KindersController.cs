using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Rotativa;
using testautenticacion.Models;

namespace testautenticacion.Controllers
{
    public class KindersController : Controller
    {
        private AADFLDEntities db = new AADFLDEntities();

        // GET: Kinders
        public ActionResult Index(int? pageNumber)
        {

            string Fecha = DateTime.Now.ToString("M/yyyy");
            pageNumber = pageNumber ?? 1;
            KinderModelo inv = new KinderModelo();
            inv.Datos = db.Kinder.OrderBy(t => new { t.Nombre_Estudiante, t.NumeroSemana }).Where(x => x.AnoMes.Contains(Fecha)).ToList().ToPagedList((int)pageNumber, 200);

            return View(inv);
        }


        public ActionResult Imprimir(string PDF)
        {

            var q = new ActionAsPdf("ReporteKinder", new { PDF });
            return q;
        }

        public ActionResult ReporteKinder(string PDF)
        {
            KinderModelo inv = new KinderModelo();
            inv.Kinder_List = db.Kinder.OrderBy(t => new { t.Nombre_Estudiante, t.NumeroSemana }).Where(x => x.AnoMes.Equals(PDF)).ToList();
            return View(inv);
        }

        [HttpPost]
        public ActionResult ConsultarDatos(KinderModelo obj, string Fecha, int? pageNumber)
        {
            pageNumber = pageNumber ?? 1;
            KinderModelo inv = new KinderModelo();

            if (!string.IsNullOrEmpty(obj.AnoMes))
            {
                inv.Datos = db.Kinder.OrderBy(t => new { t.Nombre_Estudiante, t.NumeroSemana }).Where(x => x.AnoMes.Contains(obj.AnoMes)).ToList().ToPagedList((int)pageNumber, 200);
            }
            else
            {
                inv.Datos = db.Kinder.ToList().ToPagedList((int)pageNumber, 200);
            }

            return View("Index", inv);
        }



        // GET: Kinders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kinder kinder = db.Kinder.Find(id);
            if (kinder == null)
            {
                return HttpNotFound();
            }
            return View(kinder);
        }

        // GET: Kinders/Create
        public ActionResult Create()
        {
            ViewBag.Jueves = new SelectList(db.Estado_Asistencia, "ID", "Estado");
            ViewBag.Lunes = new SelectList(db.Estado_Asistencia, "ID", "Estado");
            ViewBag.Martes = new SelectList(db.Estado_Asistencia, "ID", "Estado");
            ViewBag.Miercoles = new SelectList(db.Estado_Asistencia, "ID", "Estado");
            ViewBag.Viernes = new SelectList(db.Estado_Asistencia, "ID", "Estado");
            ViewBag.Nivel = new SelectList(db.Nivel_Estudiante, "ID", "Nivel");
            return View();
        }

        // POST: Kinders/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,AnoMes,Nombre_Estudiante,Nivel,NumeroSemana,Lunes,Martes,Miercoles,Jueves,Viernes")] Kinder kinder)
        {
            if (ModelState.IsValid)
            {
                db.Kinder.Add(kinder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Jueves = new SelectList(db.Estado_Asistencia, "ID", "Estado", kinder.Jueves);
            ViewBag.Lunes = new SelectList(db.Estado_Asistencia, "ID", "Estado", kinder.Lunes);
            ViewBag.Martes = new SelectList(db.Estado_Asistencia, "ID", "Estado", kinder.Martes);
            ViewBag.Miercoles = new SelectList(db.Estado_Asistencia, "ID", "Estado", kinder.Miercoles);
            ViewBag.Viernes = new SelectList(db.Estado_Asistencia, "ID", "Estado", kinder.Viernes);
            ViewBag.Nivel = new SelectList(db.Nivel_Estudiante, "ID", "Nivel", kinder.Nivel);
            return View(kinder);
        }

        // GET: Kinders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kinder kinder = db.Kinder.Find(id);
            if (kinder == null)
            {
                return HttpNotFound();
            }
            ViewBag.Jueves = new SelectList(db.Estado_Asistencia, "ID", "Estado", kinder.Jueves);
            ViewBag.Lunes = new SelectList(db.Estado_Asistencia, "ID", "Estado", kinder.Lunes);
            ViewBag.Martes = new SelectList(db.Estado_Asistencia, "ID", "Estado", kinder.Martes);
            ViewBag.Miercoles = new SelectList(db.Estado_Asistencia, "ID", "Estado", kinder.Miercoles);
            ViewBag.Viernes = new SelectList(db.Estado_Asistencia, "ID", "Estado", kinder.Viernes);
            ViewBag.Nivel = new SelectList(db.Nivel_Estudiante, "ID", "Nivel", kinder.Nivel);
            return View(kinder);
        }

        // POST: Kinders/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,AnoMes,Nombre_Estudiante,Nivel,NumeroSemana,Lunes,Martes,Miercoles,Jueves,Viernes")] Kinder kinder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kinder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Jueves = new SelectList(db.Estado_Asistencia, "ID", "Estado", kinder.Jueves);
            ViewBag.Lunes = new SelectList(db.Estado_Asistencia, "ID", "Estado", kinder.Lunes);
            ViewBag.Martes = new SelectList(db.Estado_Asistencia, "ID", "Estado", kinder.Martes);
            ViewBag.Miercoles = new SelectList(db.Estado_Asistencia, "ID", "Estado", kinder.Miercoles);
            ViewBag.Viernes = new SelectList(db.Estado_Asistencia, "ID", "Estado", kinder.Viernes);
            ViewBag.Nivel = new SelectList(db.Nivel_Estudiante, "ID", "Nivel", kinder.Nivel);
            return View(kinder);
        }

        // GET: Kinders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kinder kinder = db.Kinder.Find(id);
            if (kinder == null)
            {
                return HttpNotFound();
            }
            return View(kinder);
        }

        // POST: Kinders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kinder kinder = db.Kinder.Find(id);
            db.Kinder.Remove(kinder);
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
