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
    public class ACTIVOS_LUZ_DIVINA_RECREATIVOSController : Controller
    {
        private AADFLDEntities3 db = new AADFLDEntities3();

        // GET: ACTIVOS_LUZ_DIVINA_RECREATIVOS
        public ActionResult Index()
        {
            return View(db.ACTIVOS_LUZ_DIVINA_RECREATIVOS.ToList());
        }

        // GET: ACTIVOS_LUZ_DIVINA_RECREATIVOS/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ACTIVOS_LUZ_DIVINA_RECREATIVOS aCTIVOS_LUZ_DIVINA_RECREATIVOS = db.ACTIVOS_LUZ_DIVINA_RECREATIVOS.Find(id);
            if (aCTIVOS_LUZ_DIVINA_RECREATIVOS == null)
            {
                return HttpNotFound();
            }
            return View(aCTIVOS_LUZ_DIVINA_RECREATIVOS);
        }

        // GET: ACTIVOS_LUZ_DIVINA_RECREATIVOS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ACTIVOS_LUZ_DIVINA_RECREATIVOS/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CODIGO_ACTIVO_RECREATIVO,DESCRIPCION,MARCA,SERIE,FECHA_COMPRA,FECHA_SALIDA,VIDA_UTIL_MESES,COSTO_ADQUISITIVO,DEPREC_MES,DEPREC_ACUM,VALOR_LIBROS")] ACTIVOS_LUZ_DIVINA_RECREATIVOS aCTIVOS_LUZ_DIVINA_RECREATIVOS)
        {
            if (ModelState.IsValid)
            {
                db.ACTIVOS_LUZ_DIVINA_RECREATIVOS.Add(aCTIVOS_LUZ_DIVINA_RECREATIVOS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aCTIVOS_LUZ_DIVINA_RECREATIVOS);
        }

        // GET: ACTIVOS_LUZ_DIVINA_RECREATIVOS/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ACTIVOS_LUZ_DIVINA_RECREATIVOS aCTIVOS_LUZ_DIVINA_RECREATIVOS = db.ACTIVOS_LUZ_DIVINA_RECREATIVOS.Find(id);
            if (aCTIVOS_LUZ_DIVINA_RECREATIVOS == null)
            {
                return HttpNotFound();
            }
            return View(aCTIVOS_LUZ_DIVINA_RECREATIVOS);
        }

        // POST: ACTIVOS_LUZ_DIVINA_RECREATIVOS/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CODIGO_ACTIVO_RECREATIVO,DESCRIPCION,MARCA,SERIE,FECHA_COMPRA,FECHA_SALIDA,VIDA_UTIL_MESES,COSTO_ADQUISITIVO,DEPREC_MES,DEPREC_ACUM,VALOR_LIBROS")] ACTIVOS_LUZ_DIVINA_RECREATIVOS aCTIVOS_LUZ_DIVINA_RECREATIVOS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aCTIVOS_LUZ_DIVINA_RECREATIVOS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aCTIVOS_LUZ_DIVINA_RECREATIVOS);
        }

        // GET: ACTIVOS_LUZ_DIVINA_RECREATIVOS/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ACTIVOS_LUZ_DIVINA_RECREATIVOS aCTIVOS_LUZ_DIVINA_RECREATIVOS = db.ACTIVOS_LUZ_DIVINA_RECREATIVOS.Find(id);
            if (aCTIVOS_LUZ_DIVINA_RECREATIVOS == null)
            {
                return HttpNotFound();
            }
            return View(aCTIVOS_LUZ_DIVINA_RECREATIVOS);
        }

        // POST: ACTIVOS_LUZ_DIVINA_RECREATIVOS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ACTIVOS_LUZ_DIVINA_RECREATIVOS aCTIVOS_LUZ_DIVINA_RECREATIVOS = db.ACTIVOS_LUZ_DIVINA_RECREATIVOS.Find(id);
            db.ACTIVOS_LUZ_DIVINA_RECREATIVOS.Remove(aCTIVOS_LUZ_DIVINA_RECREATIVOS);
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
