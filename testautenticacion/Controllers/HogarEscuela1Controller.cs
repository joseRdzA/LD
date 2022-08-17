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
    public class HogarEscuela1Controller : Controller
    {
        private AADFLDEntities db = new AADFLDEntities();

        // GET: HogarEscuela1
        public ActionResult Index(int? pageNumber)
        {

            string Fecha = DateTime.Now.ToString("M/yyyy");
            pageNumber = pageNumber ?? 1;
            HogarEscuela1Modelo inv = new HogarEscuela1Modelo();
            inv.Datos = db.HogarEscuela1.OrderBy(t => new { t.Nombre_Estudiante, t.NumeroSemana }).Where(x => x.AnoMes.Contains(Fecha)).ToList().ToPagedList((int)pageNumber, 200);





            return View(inv);
        }


        public ActionResult Imprimir(string PDF)
        {

            var q = new ActionAsPdf("ReporteHogarEscuela1", new { PDF });
            return q;
        }

        public ActionResult ReporteHogarEscuela1(string PDF)
        {
            HogarEscuela1Modelo inv = new HogarEscuela1Modelo();
            inv.HogarEscuela1_List = db.HogarEscuela1.OrderBy(t => new { t.Nombre_Estudiante, t.NumeroSemana }).Where(x => x.AnoMes.Equals(PDF)).ToList();
            return View(inv);
        }

        [HttpPost]
        public ActionResult ConsultarDatos(HogarEscuela1Modelo obj, string Fecha, int? pageNumber)
        {
            pageNumber = pageNumber ?? 1;
            HogarEscuela1Modelo inv = new HogarEscuela1Modelo();

            if (!string.IsNullOrEmpty(obj.AnoMes))
            {
                inv.Datos = db.HogarEscuela1.OrderBy(t => new { t.Nombre_Estudiante, t.NumeroSemana }).Where(x => x.AnoMes.Contains(obj.AnoMes)).ToList().ToPagedList((int)pageNumber, 200);
            }
            else
            {
                inv.Datos = db.HogarEscuela1.ToList().ToPagedList((int)pageNumber, 200);
            }

            return View("Index", inv);
        }

        // GET: HogarEscuela1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HogarEscuela1 hogarEscuela1 = db.HogarEscuela1.Find(id);
            if (hogarEscuela1 == null)
            {
                return HttpNotFound();
            }
            return View(hogarEscuela1);
        }

        // GET: HogarEscuela1/Create
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

        // POST: HogarEscuela1/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,AnoMes,Nombre_Estudiante,Nivel,NumeroSemana,Lunes,Martes,Miercoles,Jueves,Viernes")] HogarEscuela1 hogarEscuela1)
        {
            if (ModelState.IsValid)
            {
                db.HogarEscuela1.Add(hogarEscuela1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Jueves = new SelectList(db.Estado_Asistencia, "ID", "Estado", hogarEscuela1.Jueves);
            ViewBag.Lunes = new SelectList(db.Estado_Asistencia, "ID", "Estado", hogarEscuela1.Lunes);
            ViewBag.Martes = new SelectList(db.Estado_Asistencia, "ID", "Estado", hogarEscuela1.Martes);
            ViewBag.Miercoles = new SelectList(db.Estado_Asistencia, "ID", "Estado", hogarEscuela1.Miercoles);
            ViewBag.Viernes = new SelectList(db.Estado_Asistencia, "ID", "Estado", hogarEscuela1.Viernes);
            ViewBag.Nivel = new SelectList(db.Nivel_Estudiante, "ID", "Nivel", hogarEscuela1.Nivel);
            return View(hogarEscuela1);
        }

        // GET: HogarEscuela1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HogarEscuela1 hogarEscuela1 = db.HogarEscuela1.Find(id);
            if (hogarEscuela1 == null)
            {
                return HttpNotFound();
            }
            ViewBag.Jueves = new SelectList(db.Estado_Asistencia, "ID", "Estado", hogarEscuela1.Jueves);
            ViewBag.Lunes = new SelectList(db.Estado_Asistencia, "ID", "Estado", hogarEscuela1.Lunes);
            ViewBag.Martes = new SelectList(db.Estado_Asistencia, "ID", "Estado", hogarEscuela1.Martes);
            ViewBag.Miercoles = new SelectList(db.Estado_Asistencia, "ID", "Estado", hogarEscuela1.Miercoles);
            ViewBag.Viernes = new SelectList(db.Estado_Asistencia, "ID", "Estado", hogarEscuela1.Viernes);
            ViewBag.Nivel = new SelectList(db.Nivel_Estudiante, "ID", "Nivel", hogarEscuela1.Nivel);
            return View(hogarEscuela1);
        }

        // POST: HogarEscuela1/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,AnoMes,Nombre_Estudiante,Nivel,NumeroSemana,Lunes,Martes,Miercoles,Jueves,Viernes")] HogarEscuela1 hogarEscuela1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hogarEscuela1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Jueves = new SelectList(db.Estado_Asistencia, "ID", "Estado", hogarEscuela1.Jueves);
            ViewBag.Lunes = new SelectList(db.Estado_Asistencia, "ID", "Estado", hogarEscuela1.Lunes);
            ViewBag.Martes = new SelectList(db.Estado_Asistencia, "ID", "Estado", hogarEscuela1.Martes);
            ViewBag.Miercoles = new SelectList(db.Estado_Asistencia, "ID", "Estado", hogarEscuela1.Miercoles);
            ViewBag.Viernes = new SelectList(db.Estado_Asistencia, "ID", "Estado", hogarEscuela1.Viernes);
            ViewBag.Nivel = new SelectList(db.Nivel_Estudiante, "ID", "Nivel", hogarEscuela1.Nivel);
            return View(hogarEscuela1);
        }

        // GET: HogarEscuela1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HogarEscuela1 hogarEscuela1 = db.HogarEscuela1.Find(id);
            if (hogarEscuela1 == null)
            {
                return HttpNotFound();
            }
            return View(hogarEscuela1);
        }

        // POST: HogarEscuela1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HogarEscuela1 hogarEscuela1 = db.HogarEscuela1.Find(id);
            db.HogarEscuela1.Remove(hogarEscuela1);
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
