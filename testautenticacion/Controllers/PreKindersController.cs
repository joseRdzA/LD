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
    public class PreKindersController : Controller
    {
        private AADFLDEntities db = new AADFLDEntities();

        // GET: PreKinders
        public ActionResult Index(int? pageNumber)
        {

            string Fecha = DateTime.Now.ToString("M/yyyy");
            pageNumber = pageNumber ?? 1;
            PreKinderModelo inv = new PreKinderModelo();
            inv.Datos = db.PreKinder.OrderBy(t => new { t.Nombre_Estudiante, t.NumeroSemana }).Where(x => x.AnoMes.Contains(Fecha)).ToList().ToPagedList((int)pageNumber, 200);

            return View(inv);
        }

        public ActionResult Imprimir(string PDF)
        {

            var q = new ActionAsPdf("ReportePreKinder", new { PDF });
            return q;
        }

        public ActionResult ReportePreKinder(string PDF)
        {
            PreKinderModelo inv = new PreKinderModelo();
            inv.PreKinder_List = db.PreKinder.OrderBy(t => new { t.Nombre_Estudiante, t.NumeroSemana }).Where(x => x.AnoMes.Equals(PDF)).ToList();
            return View(inv);
        }

        [HttpPost]
        public ActionResult ConsultarDatos(PreKinderModelo obj, string Fecha, int? pageNumber)
        {
            pageNumber = pageNumber ?? 1;
            PreKinderModelo inv = new PreKinderModelo();

            if (!string.IsNullOrEmpty(obj.AnoMes))
            {
                inv.Datos = db.PreKinder.OrderBy(t => new { t.Nombre_Estudiante, t.NumeroSemana }).Where(x => x.AnoMes.Contains(obj.AnoMes)).ToList().ToPagedList((int)pageNumber, 200);
            }
            else
            {
                inv.Datos = db.PreKinder.ToList().ToPagedList((int)pageNumber, 200);
            }

            return View("Index", inv);
        }





        // GET: PreKinders/Create
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

        // POST: PreKinders/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,AnoMes,Nombre_Estudiante,Nivel,NumeroSemana,Lunes,Martes,Miercoles,Jueves,Viernes")] PreKinder preKinder)
        {
            if (ModelState.IsValid)
            {
                db.PreKinder.Add(preKinder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Jueves = new SelectList(db.Estado_Asistencia, "ID", "Estado", preKinder.Jueves);
            ViewBag.Lunes = new SelectList(db.Estado_Asistencia, "ID", "Estado", preKinder.Lunes);
            ViewBag.Martes = new SelectList(db.Estado_Asistencia, "ID", "Estado", preKinder.Martes);
            ViewBag.Miercoles = new SelectList(db.Estado_Asistencia, "ID", "Estado", preKinder.Miercoles);
            ViewBag.Viernes = new SelectList(db.Estado_Asistencia, "ID", "Estado", preKinder.Viernes);
            ViewBag.Nivel = new SelectList(db.Nivel_Estudiante, "ID", "Nivel", preKinder.Nivel);
            return View(preKinder);
        }

        // GET: PreKinders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PreKinder preKinder = db.PreKinder.Find(id);
            if (preKinder == null)
            {
                return HttpNotFound();
            }
            ViewBag.Jueves = new SelectList(db.Estado_Asistencia, "ID", "Estado", preKinder.Jueves);
            ViewBag.Lunes = new SelectList(db.Estado_Asistencia, "ID", "Estado", preKinder.Lunes);
            ViewBag.Martes = new SelectList(db.Estado_Asistencia, "ID", "Estado", preKinder.Martes);
            ViewBag.Miercoles = new SelectList(db.Estado_Asistencia, "ID", "Estado", preKinder.Miercoles);
            ViewBag.Viernes = new SelectList(db.Estado_Asistencia, "ID", "Estado", preKinder.Viernes);
            ViewBag.Nivel = new SelectList(db.Nivel_Estudiante, "ID", "Nivel", preKinder.Nivel);
            return View(preKinder);
        }

        // POST: PreKinders/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,AnoMes,Nombre_Estudiante,Nivel,NumeroSemana,Lunes,Martes,Miercoles,Jueves,Viernes")] PreKinder preKinder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(preKinder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Jueves = new SelectList(db.Estado_Asistencia, "ID", "Estado", preKinder.Jueves);
            ViewBag.Lunes = new SelectList(db.Estado_Asistencia, "ID", "Estado", preKinder.Lunes);
            ViewBag.Martes = new SelectList(db.Estado_Asistencia, "ID", "Estado", preKinder.Martes);
            ViewBag.Miercoles = new SelectList(db.Estado_Asistencia, "ID", "Estado", preKinder.Miercoles);
            ViewBag.Viernes = new SelectList(db.Estado_Asistencia, "ID", "Estado", preKinder.Viernes);
            ViewBag.Nivel = new SelectList(db.Nivel_Estudiante, "ID", "Nivel", preKinder.Nivel);
            return View(preKinder);
        }

        // GET: PreKinders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PreKinder preKinder = db.PreKinder.Find(id);
            if (preKinder == null)
            {
                return HttpNotFound();
            }
            return View(preKinder);
        }

        // POST: PreKinders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PreKinder preKinder = db.PreKinder.Find(id);
            db.PreKinder.Remove(preKinder);
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
