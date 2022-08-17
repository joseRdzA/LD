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
    public class HogarEscuela2Controller : Controller
    {
        private AADFLDEntities db = new AADFLDEntities();

        // GET: HogarEscuela2
        public ActionResult Index(int? pageNumber)
        {

            string Fecha = DateTime.Now.ToString("M/yyyy");
            pageNumber = pageNumber ?? 1;
            HogarEscuela2Modelo inv = new HogarEscuela2Modelo();
            inv.Datos = db.HogarEscuela2.OrderBy(t => new { t.Nombre_Estudiante, t.NumeroSemana }).Where(x => x.AnoMes.Contains(Fecha)).ToList().ToPagedList((int)pageNumber, 200);





            return View(inv);
        }


        public ActionResult Imprimir(string PDF)
        {

            var q = new ActionAsPdf("ReporteHogarEscuela2", new { PDF });
            return q;
        }

        public ActionResult ReporteHogarEscuela2(string PDF)
        {
            HogarEscuela2Modelo inv = new HogarEscuela2Modelo();
            inv.HogarEscuela2_List = db.HogarEscuela2.OrderBy(t => new { t.Nombre_Estudiante, t.NumeroSemana }).Where(x => x.AnoMes.Equals(PDF)).ToList();
            return View(inv);
        }

        [HttpPost]
        public ActionResult ConsultarDatos(HogarEscuela2Modelo obj, string Fecha, int? pageNumber)
        {
            pageNumber = pageNumber ?? 1;
            HogarEscuela2Modelo inv = new HogarEscuela2Modelo();

            if (!string.IsNullOrEmpty(obj.AnoMes))
            {
                inv.Datos = db.HogarEscuela2.OrderBy(t => new { t.Nombre_Estudiante, t.NumeroSemana }).Where(x => x.AnoMes.Contains(obj.AnoMes)).ToList().ToPagedList((int)pageNumber, 200);
            }
            else
            {
                inv.Datos = db.HogarEscuela2.ToList().ToPagedList((int)pageNumber, 200);
            }

            return View("Index", inv);
        }

        // GET: HogarEscuela2/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HogarEscuela2 hogarEscuela2 = db.HogarEscuela2.Find(id);
            if (hogarEscuela2 == null)
            {
                return HttpNotFound();
            }
            return View(hogarEscuela2);
        }

        // GET: HogarEscuela2/Create
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

        // POST: HogarEscuela2/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,AnoMes,Nombre_Estudiante,Nivel,NumeroSemana,Lunes,Martes,Miercoles,Jueves,Viernes")] HogarEscuela2 hogarEscuela2)
        {
            if (ModelState.IsValid)
            {
                db.HogarEscuela2.Add(hogarEscuela2);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Jueves = new SelectList(db.Estado_Asistencia, "ID", "Estado", hogarEscuela2.Jueves);
            ViewBag.Lunes = new SelectList(db.Estado_Asistencia, "ID", "Estado", hogarEscuela2.Lunes);
            ViewBag.Martes = new SelectList(db.Estado_Asistencia, "ID", "Estado", hogarEscuela2.Martes);
            ViewBag.Miercoles = new SelectList(db.Estado_Asistencia, "ID", "Estado", hogarEscuela2.Miercoles);
            ViewBag.Viernes = new SelectList(db.Estado_Asistencia, "ID", "Estado", hogarEscuela2.Viernes);
            ViewBag.Nivel = new SelectList(db.Nivel_Estudiante, "ID", "Nivel", hogarEscuela2.Nivel);
            return View(hogarEscuela2);
        }

        // GET: HogarEscuela2/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HogarEscuela2 hogarEscuela2 = db.HogarEscuela2.Find(id);
            if (hogarEscuela2 == null)
            {
                return HttpNotFound();
            }
            ViewBag.Jueves = new SelectList(db.Estado_Asistencia, "ID", "Estado", hogarEscuela2.Jueves);
            ViewBag.Lunes = new SelectList(db.Estado_Asistencia, "ID", "Estado", hogarEscuela2.Lunes);
            ViewBag.Martes = new SelectList(db.Estado_Asistencia, "ID", "Estado", hogarEscuela2.Martes);
            ViewBag.Miercoles = new SelectList(db.Estado_Asistencia, "ID", "Estado", hogarEscuela2.Miercoles);
            ViewBag.Viernes = new SelectList(db.Estado_Asistencia, "ID", "Estado", hogarEscuela2.Viernes);
            ViewBag.Nivel = new SelectList(db.Nivel_Estudiante, "ID", "Nivel", hogarEscuela2.Nivel);
            return View(hogarEscuela2);
        }

        // POST: HogarEscuela2/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,AnoMes,Nombre_Estudiante,Nivel,NumeroSemana,Lunes,Martes,Miercoles,Jueves,Viernes")] HogarEscuela2 hogarEscuela2)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hogarEscuela2).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Jueves = new SelectList(db.Estado_Asistencia, "ID", "Estado", hogarEscuela2.Jueves);
            ViewBag.Lunes = new SelectList(db.Estado_Asistencia, "ID", "Estado", hogarEscuela2.Lunes);
            ViewBag.Martes = new SelectList(db.Estado_Asistencia, "ID", "Estado", hogarEscuela2.Martes);
            ViewBag.Miercoles = new SelectList(db.Estado_Asistencia, "ID", "Estado", hogarEscuela2.Miercoles);
            ViewBag.Viernes = new SelectList(db.Estado_Asistencia, "ID", "Estado", hogarEscuela2.Viernes);
            ViewBag.Nivel = new SelectList(db.Nivel_Estudiante, "ID", "Nivel", hogarEscuela2.Nivel);
            return View(hogarEscuela2);
        }

        // GET: HogarEscuela2/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HogarEscuela2 hogarEscuela2 = db.HogarEscuela2.Find(id);
            if (hogarEscuela2 == null)
            {
                return HttpNotFound();
            }
            return View(hogarEscuela2);
        }

        // POST: HogarEscuela2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HogarEscuela2 hogarEscuela2 = db.HogarEscuela2.Find(id);
            db.HogarEscuela2.Remove(hogarEscuela2);
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
