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
    public class CasaCuna2Controller : Controller
    {
        private AADFLDEntities db = new AADFLDEntities();

        // GET: CasaCuna2
        public ActionResult Index(int? pageNumber)
        {

            string Fecha = DateTime.Now.ToString("M/yyyy");
            pageNumber = pageNumber ?? 1;
            CasaCuna2Modelo inv = new CasaCuna2Modelo();
            inv.Datos = db.CasaCuna2.OrderBy(t => new { t.Nombre_Estudiante, t.NumeroSemana }).Where(x => x.AnoMes.Contains(Fecha)).ToList().ToPagedList((int)pageNumber, 200);

            return View(inv);
        }


        public ActionResult Imprimir(string PDF)
        {

            var q = new ActionAsPdf("ReporteCasaCuna2", new { PDF });
            return q;
        }

        public ActionResult ReporteCasaCuna2(string PDF)
        {
            CasaCuna2Modelo inv = new CasaCuna2Modelo();
            inv.CasaCuna2_List = db.CasaCuna2.OrderBy(t => new { t.Nombre_Estudiante, t.NumeroSemana }).Where(x => x.AnoMes.Equals(PDF)).ToList();
            return View(inv);
        }

        [HttpPost]
        public ActionResult ConsultarDatos(CasaCuna2Modelo obj, string Fecha, int? pageNumber)
        {
            pageNumber = pageNumber ?? 1;
            CasaCuna2Modelo inv = new CasaCuna2Modelo();

            if (!string.IsNullOrEmpty(obj.AnoMes))
            {
                inv.Datos = db.CasaCuna2.OrderBy(t => new { t.Nombre_Estudiante, t.NumeroSemana }).Where(x => x.AnoMes.Contains(obj.AnoMes)).ToList().ToPagedList((int)pageNumber, 200);
            }
            else
            {
                inv.Datos = db.CasaCuna2.ToList().ToPagedList((int)pageNumber, 200);
            }

            return View("Index", inv);
        }

        // GET: CasaCuna2/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CasaCuna2 casaCuna2 = db.CasaCuna2.Find(id);
            if (casaCuna2 == null)
            {
                return HttpNotFound();
            }
            return View(casaCuna2);
        }

        // GET: CasaCuna2/Create
        public ActionResult Create()
        {
            ViewBag.Jueves = new SelectList(db.Estado_Asistencia, "ID", "Estado");
            ViewBag.Lunes = new SelectList(db.Estado_Asistencia, "ID", "Estado");
            ViewBag.Martes = new SelectList(db.Estado_Asistencia, "ID", "Estado");
            ViewBag.Miercoles = new SelectList(db.Estado_Asistencia, "ID", "Estado");
            ViewBag.Nivel = new SelectList(db.Nivel_Estudiante, "ID", "Nivel");
            ViewBag.Viernes = new SelectList(db.Estado_Asistencia, "ID", "Estado");
            return View();
        }

        // POST: CasaCuna2/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,AnoMes,Nombre_Estudiante,Nivel,NumeroSemana,Lunes,Martes,Miercoles,Jueves,Viernes")] CasaCuna2 casaCuna2)
        {
            if (ModelState.IsValid)
            {
                db.CasaCuna2.Add(casaCuna2);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Jueves = new SelectList(db.Estado_Asistencia, "ID", "Estado", casaCuna2.Jueves);
            ViewBag.Lunes = new SelectList(db.Estado_Asistencia, "ID", "Estado", casaCuna2.Lunes);
            ViewBag.Martes = new SelectList(db.Estado_Asistencia, "ID", "Estado", casaCuna2.Martes);
            ViewBag.Miercoles = new SelectList(db.Estado_Asistencia, "ID", "Estado", casaCuna2.Miercoles);
            ViewBag.Nivel = new SelectList(db.Nivel_Estudiante, "ID", "Nivel", casaCuna2.Nivel);
            ViewBag.Viernes = new SelectList(db.Estado_Asistencia, "ID", "Estado", casaCuna2.Viernes);
            return View(casaCuna2);
        }

        // GET: CasaCuna2/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CasaCuna2 casaCuna2 = db.CasaCuna2.Find(id);
            if (casaCuna2 == null)
            {
                return HttpNotFound();
            }
            ViewBag.Jueves = new SelectList(db.Estado_Asistencia, "ID", "Estado", casaCuna2.Jueves);
            ViewBag.Lunes = new SelectList(db.Estado_Asistencia, "ID", "Estado", casaCuna2.Lunes);
            ViewBag.Martes = new SelectList(db.Estado_Asistencia, "ID", "Estado", casaCuna2.Martes);
            ViewBag.Miercoles = new SelectList(db.Estado_Asistencia, "ID", "Estado", casaCuna2.Miercoles);
            ViewBag.Nivel = new SelectList(db.Nivel_Estudiante, "ID", "Nivel", casaCuna2.Nivel);
            ViewBag.Viernes = new SelectList(db.Estado_Asistencia, "ID", "Estado", casaCuna2.Viernes);
            return View(casaCuna2);
        }

        // POST: CasaCuna2/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,AnoMes,Nombre_Estudiante,Nivel,NumeroSemana,Lunes,Martes,Miercoles,Jueves,Viernes")] CasaCuna2 casaCuna2)
        {
            if (ModelState.IsValid)
            {
                db.Entry(casaCuna2).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Jueves = new SelectList(db.Estado_Asistencia, "ID", "Estado", casaCuna2.Jueves);
            ViewBag.Lunes = new SelectList(db.Estado_Asistencia, "ID", "Estado", casaCuna2.Lunes);
            ViewBag.Martes = new SelectList(db.Estado_Asistencia, "ID", "Estado", casaCuna2.Martes);
            ViewBag.Miercoles = new SelectList(db.Estado_Asistencia, "ID", "Estado", casaCuna2.Miercoles);
            ViewBag.Nivel = new SelectList(db.Nivel_Estudiante, "ID", "Nivel", casaCuna2.Nivel);
            ViewBag.Viernes = new SelectList(db.Estado_Asistencia, "ID", "Estado", casaCuna2.Viernes);
            return View(casaCuna2);
        }

        // GET: CasaCuna2/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CasaCuna2 casaCuna2 = db.CasaCuna2.Find(id);
            if (casaCuna2 == null)
            {
                return HttpNotFound();
            }
            return View(casaCuna2);
        }

        // POST: CasaCuna2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CasaCuna2 casaCuna2 = db.CasaCuna2.Find(id);
            db.CasaCuna2.Remove(casaCuna2);
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
