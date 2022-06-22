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
    public class ACTIVOS_LUZ_DIVINA_ELECTRICOSController : Controller
    {
        private AADFLDEntities3 db = new AADFLDEntities3();

        // GET: ACTIVOS_LUZ_DIVINA_ELECTRICOS
        public ActionResult Index()
        {
            return View(db.ACTIVOS_LUZ_DIVINA_ELECTRICOS.ToList());
        }

        // GET: ACTIVOS_LUZ_DIVINA_ELECTRICOS/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ACTIVOS_LUZ_DIVINA_ELECTRICOS aCTIVOS_LUZ_DIVINA_ELECTRICOS = db.ACTIVOS_LUZ_DIVINA_ELECTRICOS.Find(id);
            if (aCTIVOS_LUZ_DIVINA_ELECTRICOS == null)
            {
                return HttpNotFound();
            }
            return View(aCTIVOS_LUZ_DIVINA_ELECTRICOS);
        }

        // GET: ACTIVOS_LUZ_DIVINA_ELECTRICOS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ACTIVOS_LUZ_DIVINA_ELECTRICOS/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CODIGO_ACTIVO_ELECTRICO,DESCRIPCION,MARCA,SERIE,FECHA_COMPRA,FECHA_SALIDA,VIDA_UTIL_MESES,COSTO_ADQUISITIVO,DEPREC_MES,DEPREC_ACUM,VALOR_LIBROS")] ACTIVOS_LUZ_DIVINA_ELECTRICOS aCTIVOS_LUZ_DIVINA_ELECTRICOS)
        {
            if (ModelState.IsValid)
            {
                db.ACTIVOS_LUZ_DIVINA_ELECTRICOS.Add(aCTIVOS_LUZ_DIVINA_ELECTRICOS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aCTIVOS_LUZ_DIVINA_ELECTRICOS);
        }

        // GET: ACTIVOS_LUZ_DIVINA_ELECTRICOS/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ACTIVOS_LUZ_DIVINA_ELECTRICOS aCTIVOS_LUZ_DIVINA_ELECTRICOS = db.ACTIVOS_LUZ_DIVINA_ELECTRICOS.Find(id);
            if (aCTIVOS_LUZ_DIVINA_ELECTRICOS == null)
            {
                return HttpNotFound();
            }
            return View(aCTIVOS_LUZ_DIVINA_ELECTRICOS);
        }

        // POST: ACTIVOS_LUZ_DIVINA_ELECTRICOS/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CODIGO_ACTIVO_ELECTRICO,DESCRIPCION,MARCA,SERIE,FECHA_COMPRA,FECHA_SALIDA,VIDA_UTIL_MESES,COSTO_ADQUISITIVO,DEPREC_MES,DEPREC_ACUM,VALOR_LIBROS")] ACTIVOS_LUZ_DIVINA_ELECTRICOS aCTIVOS_LUZ_DIVINA_ELECTRICOS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aCTIVOS_LUZ_DIVINA_ELECTRICOS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aCTIVOS_LUZ_DIVINA_ELECTRICOS);
        }

        // GET: ACTIVOS_LUZ_DIVINA_ELECTRICOS/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ACTIVOS_LUZ_DIVINA_ELECTRICOS aCTIVOS_LUZ_DIVINA_ELECTRICOS = db.ACTIVOS_LUZ_DIVINA_ELECTRICOS.Find(id);
            if (aCTIVOS_LUZ_DIVINA_ELECTRICOS == null)
            {
                return HttpNotFound();
            }
            return View(aCTIVOS_LUZ_DIVINA_ELECTRICOS);
        }

        // POST: ACTIVOS_LUZ_DIVINA_ELECTRICOS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ACTIVOS_LUZ_DIVINA_ELECTRICOS aCTIVOS_LUZ_DIVINA_ELECTRICOS = db.ACTIVOS_LUZ_DIVINA_ELECTRICOS.Find(id);
            db.ACTIVOS_LUZ_DIVINA_ELECTRICOS.Remove(aCTIVOS_LUZ_DIVINA_ELECTRICOS);
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
