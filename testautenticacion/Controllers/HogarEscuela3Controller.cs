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
    public class HogarEscuela3Controller : Controller
    {
        private AADFLDEntities db = new AADFLDEntities();

        // GET: HogarEscuela3
        public ActionResult Index(int? pageNumber)
        {

            string Fecha = DateTime.Now.ToString("M/yyyy");
            pageNumber = pageNumber ?? 1;
            HogarEscuela3Modelo inv = new HogarEscuela3Modelo();
            inv.Datos = db.HogarEscuela3.OrderBy(t => new { t.Nombre_Estudiante, t.NumeroSemana }).Where(x => x.AnoMes.Contains(Fecha)).ToList().ToPagedList((int)pageNumber, 200);

            return View(inv);
        }


        public ActionResult Imprimir(string PDF)
        {

            var q = new ActionAsPdf("ReporteHogarEscuela3", new { PDF });
            return q;
        }

        public ActionResult ReporteHogarEscuela3(string PDF)
        {
            HogarEscuela3Modelo inv = new HogarEscuela3Modelo();
            inv.HogarEscuela3_List = db.HogarEscuela3.OrderBy(t => new { t.Nombre_Estudiante, t.NumeroSemana }).Where(x => x.AnoMes.Equals(PDF)).ToList();
            return View(inv);
        }

        [HttpPost]
        public ActionResult ConsultarDatos(HogarEscuela3Modelo obj, string Fecha, int? pageNumber)
        {
            pageNumber = pageNumber ?? 1;
            HogarEscuela3Modelo inv = new HogarEscuela3Modelo();

            if (!string.IsNullOrEmpty(obj.AnoMes))
            {
                inv.Datos = db.HogarEscuela3.OrderBy(t => new { t.Nombre_Estudiante, t.NumeroSemana }).Where(x => x.AnoMes.Contains(obj.AnoMes)).ToList().ToPagedList((int)pageNumber, 200);
            }
            else
            {
                inv.Datos = db.HogarEscuela3.ToList().ToPagedList((int)pageNumber, 200);
            }

            return View("Index", inv);
        }

        // GET: HogarEscuela3/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HogarEscuela3 hogarEscuela3 = db.HogarEscuela3.Find(id);
            if (hogarEscuela3 == null)
            {
                return HttpNotFound();
            }
            return View(hogarEscuela3);
        }

        // GET: HogarEscuela3/Create
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

        // POST: HogarEscuela3/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,AnoMes,Nombre_Estudiante,Nivel,NumeroSemana,Lunes,Martes,Miercoles,Jueves,Viernes")] HogarEscuela3 hogarEscuela3)
        {
            if (ModelState.IsValid)
            {
                db.HogarEscuela3.Add(hogarEscuela3);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Jueves = new SelectList(db.Estado_Asistencia, "ID", "Estado", hogarEscuela3.Jueves);
            ViewBag.Lunes = new SelectList(db.Estado_Asistencia, "ID", "Estado", hogarEscuela3.Lunes);
            ViewBag.Martes = new SelectList(db.Estado_Asistencia, "ID", "Estado", hogarEscuela3.Martes);
            ViewBag.Miercoles = new SelectList(db.Estado_Asistencia, "ID", "Estado", hogarEscuela3.Miercoles);
            ViewBag.Viernes = new SelectList(db.Estado_Asistencia, "ID", "Estado", hogarEscuela3.Viernes);
            ViewBag.Nivel = new SelectList(db.Nivel_Estudiante, "ID", "Nivel", hogarEscuela3.Nivel);
            return View(hogarEscuela3);
        }

        // GET: HogarEscuela3/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HogarEscuela3 hogarEscuela3 = db.HogarEscuela3.Find(id);
            if (hogarEscuela3 == null)
            {
                return HttpNotFound();
            }
            ViewBag.Jueves = new SelectList(db.Estado_Asistencia, "ID", "Estado", hogarEscuela3.Jueves);
            ViewBag.Lunes = new SelectList(db.Estado_Asistencia, "ID", "Estado", hogarEscuela3.Lunes);
            ViewBag.Martes = new SelectList(db.Estado_Asistencia, "ID", "Estado", hogarEscuela3.Martes);
            ViewBag.Miercoles = new SelectList(db.Estado_Asistencia, "ID", "Estado", hogarEscuela3.Miercoles);
            ViewBag.Viernes = new SelectList(db.Estado_Asistencia, "ID", "Estado", hogarEscuela3.Viernes);
            ViewBag.Nivel = new SelectList(db.Nivel_Estudiante, "ID", "Nivel", hogarEscuela3.Nivel);
            return View(hogarEscuela3);
        }

        // POST: HogarEscuela3/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,AnoMes,Nombre_Estudiante,Nivel,NumeroSemana,Lunes,Martes,Miercoles,Jueves,Viernes")] HogarEscuela3 hogarEscuela3)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hogarEscuela3).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Jueves = new SelectList(db.Estado_Asistencia, "ID", "Estado", hogarEscuela3.Jueves);
            ViewBag.Lunes = new SelectList(db.Estado_Asistencia, "ID", "Estado", hogarEscuela3.Lunes);
            ViewBag.Martes = new SelectList(db.Estado_Asistencia, "ID", "Estado", hogarEscuela3.Martes);
            ViewBag.Miercoles = new SelectList(db.Estado_Asistencia, "ID", "Estado", hogarEscuela3.Miercoles);
            ViewBag.Viernes = new SelectList(db.Estado_Asistencia, "ID", "Estado", hogarEscuela3.Viernes);
            ViewBag.Nivel = new SelectList(db.Nivel_Estudiante, "ID", "Nivel", hogarEscuela3.Nivel);
            return View(hogarEscuela3);
        }

        // GET: HogarEscuela3/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HogarEscuela3 hogarEscuela3 = db.HogarEscuela3.Find(id);
            if (hogarEscuela3 == null)
            {
                return HttpNotFound();
            }
            return View(hogarEscuela3);
        }

        // POST: HogarEscuela3/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HogarEscuela3 hogarEscuela3 = db.HogarEscuela3.Find(id);
            db.HogarEscuela3.Remove(hogarEscuela3);
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
