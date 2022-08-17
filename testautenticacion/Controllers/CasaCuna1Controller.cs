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
    public class CasaCuna1Controller : Controller
    {
        private AADFLDEntities db = new AADFLDEntities();

        // GET: CasaCuna1
        public ActionResult Index(int? pageNumber)
        {

            string Fecha = DateTime.Now.ToString("M/yyyy");
            pageNumber = pageNumber ?? 1;
            CasaCuna1Modelo inv = new CasaCuna1Modelo();
            inv.Datos = db.CasaCuna1.OrderBy(t => new { t.Nombre_Estudiante, t.NumeroSemana }).Where(x => x.AnoMes.Contains(Fecha)).ToList().ToPagedList((int)pageNumber, 200);

            return View(inv);
        }


        public ActionResult Imprimir(string PDF)
        {

            var q = new ActionAsPdf("ReporteCasaCuna1", new { PDF });
            return q;
        }

        public ActionResult ReporteCasaCuna1(string PDF)
        {
            CasaCuna1Modelo inv = new CasaCuna1Modelo();
            inv.CasaCuna1_List = db.CasaCuna1.OrderBy(t => new { t.Nombre_Estudiante, t.NumeroSemana }).Where(x => x.AnoMes.Equals(PDF)).ToList();
            return View(inv);
        }

        [HttpPost]
        public ActionResult ConsultarDatos(CasaCuna1Modelo obj, string Fecha, int? pageNumber)
        {
            pageNumber = pageNumber ?? 1;
            CasaCuna1Modelo inv = new CasaCuna1Modelo();

            if (!string.IsNullOrEmpty(obj.AnoMes))
            {
                inv.Datos = db.CasaCuna1.OrderBy(t => new { t.Nombre_Estudiante, t.NumeroSemana }).Where(x => x.AnoMes.Contains(obj.AnoMes)).ToList().ToPagedList((int)pageNumber, 200);
            }
            else
            {
                inv.Datos = db.CasaCuna1.ToList().ToPagedList((int)pageNumber, 200);
            }

            return View("Index", inv);
        }


        // GET: CasaCuna1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CasaCuna1 casaCuna1 = db.CasaCuna1.Find(id);
            if (casaCuna1 == null)
            {
                return HttpNotFound();
            }
            return View(casaCuna1);
        }

        // GET: CasaCuna1/Create
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

        // POST: CasaCuna1/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,AnoMes,Nombre_Estudiante,Nivel,NumeroSemana,Lunes,Martes,Miercoles,Jueves,Viernes")] CasaCuna1 casaCuna1)
        {
            if (ModelState.IsValid)
            {
                db.CasaCuna1.Add(casaCuna1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Jueves = new SelectList(db.Estado_Asistencia, "ID", "Estado", casaCuna1.Jueves);
            ViewBag.Lunes = new SelectList(db.Estado_Asistencia, "ID", "Estado", casaCuna1.Lunes);
            ViewBag.Martes = new SelectList(db.Estado_Asistencia, "ID", "Estado", casaCuna1.Martes);
            ViewBag.Miercoles = new SelectList(db.Estado_Asistencia, "ID", "Estado", casaCuna1.Miercoles);
            ViewBag.Nivel = new SelectList(db.Nivel_Estudiante, "ID", "Nivel", casaCuna1.Nivel);
            ViewBag.Viernes = new SelectList(db.Estado_Asistencia, "ID", "Estado", casaCuna1.Viernes);
            return View(casaCuna1);
        }

        // GET: CasaCuna1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CasaCuna1 casaCuna1 = db.CasaCuna1.Find(id);
            if (casaCuna1 == null)
            {
                return HttpNotFound();
            }
            ViewBag.Jueves = new SelectList(db.Estado_Asistencia, "ID", "Estado", casaCuna1.Jueves);
            ViewBag.Lunes = new SelectList(db.Estado_Asistencia, "ID", "Estado", casaCuna1.Lunes);
            ViewBag.Martes = new SelectList(db.Estado_Asistencia, "ID", "Estado", casaCuna1.Martes);
            ViewBag.Miercoles = new SelectList(db.Estado_Asistencia, "ID", "Estado", casaCuna1.Miercoles);
            ViewBag.Nivel = new SelectList(db.Nivel_Estudiante, "ID", "Nivel", casaCuna1.Nivel);
            ViewBag.Viernes = new SelectList(db.Estado_Asistencia, "ID", "Estado", casaCuna1.Viernes);
            return View(casaCuna1);
        }

        // POST: CasaCuna1/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,AnoMes,Nombre_Estudiante,Nivel,NumeroSemana,Lunes,Martes,Miercoles,Jueves,Viernes")] CasaCuna1 casaCuna1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(casaCuna1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Jueves = new SelectList(db.Estado_Asistencia, "ID", "Estado", casaCuna1.Jueves);
            ViewBag.Lunes = new SelectList(db.Estado_Asistencia, "ID", "Estado", casaCuna1.Lunes);
            ViewBag.Martes = new SelectList(db.Estado_Asistencia, "ID", "Estado", casaCuna1.Martes);
            ViewBag.Miercoles = new SelectList(db.Estado_Asistencia, "ID", "Estado", casaCuna1.Miercoles);
            ViewBag.Nivel = new SelectList(db.Nivel_Estudiante, "ID", "Nivel", casaCuna1.Nivel);
            ViewBag.Viernes = new SelectList(db.Estado_Asistencia, "ID", "Estado", casaCuna1.Viernes);
            return View(casaCuna1);
        }

        // GET: CasaCuna1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CasaCuna1 casaCuna1 = db.CasaCuna1.Find(id);
            if (casaCuna1 == null)
            {
                return HttpNotFound();
            }
            return View(casaCuna1);
        }

        // POST: CasaCuna1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CasaCuna1 casaCuna1 = db.CasaCuna1.Find(id);
            db.CasaCuna1.Remove(casaCuna1);
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
