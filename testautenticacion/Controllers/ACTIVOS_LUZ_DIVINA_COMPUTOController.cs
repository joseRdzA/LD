using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using testautenticacion.Models;
using System.Web.Security;

namespace testautenticacion.Controllers
{
    [Authorize]
    public class ACTIVOS_LUZ_DIVINA_COMPUTOController : Controller
    {
        private AADFLDEntities3 db = new AADFLDEntities3();

        // GET: ACTIVOS_LUZ_DIVINA_COMPUTO
        public ActionResult Index()
        {
            return View(db.ACTIVOS_LUZ_DIVINA_COMPUTO.ToList());
        }

        // GET: ACTIVOS_LUZ_DIVINA_COMPUTO/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ACTIVOS_LUZ_DIVINA_COMPUTO aCTIVOS_LUZ_DIVINA_COMPUTO = db.ACTIVOS_LUZ_DIVINA_COMPUTO.Find(id);
            if (aCTIVOS_LUZ_DIVINA_COMPUTO == null)
            {
                return HttpNotFound();
            }
            return View(aCTIVOS_LUZ_DIVINA_COMPUTO);
        }

        // GET: ACTIVOS_LUZ_DIVINA_COMPUTO/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ACTIVOS_LUZ_DIVINA_COMPUTO/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CODIGO_ACTIVO_COMPUTO,DESCRIPCION,MARCA,SERIE,FECHA_COMPRA,FECHA_SALIDA,VIDA_UTIL_MESES,COSTO_ADQUISITIVO,DEPREC_MES,DEPREC_ACUM,VALOR_LIBROS")] ACTIVOS_LUZ_DIVINA_COMPUTO aCTIVOS_LUZ_DIVINA_COMPUTO)
        {
            if (ModelState.IsValid)
            {
                db.ACTIVOS_LUZ_DIVINA_COMPUTO.Add(aCTIVOS_LUZ_DIVINA_COMPUTO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aCTIVOS_LUZ_DIVINA_COMPUTO);
        }

        // GET: ACTIVOS_LUZ_DIVINA_COMPUTO/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ACTIVOS_LUZ_DIVINA_COMPUTO aCTIVOS_LUZ_DIVINA_COMPUTO = db.ACTIVOS_LUZ_DIVINA_COMPUTO.Find(id);
            if (aCTIVOS_LUZ_DIVINA_COMPUTO == null)
            {
                return HttpNotFound();
            }
            return View(aCTIVOS_LUZ_DIVINA_COMPUTO);
        }

        // POST: ACTIVOS_LUZ_DIVINA_COMPUTO/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CODIGO_ACTIVO_COMPUTO,DESCRIPCION,MARCA,SERIE,FECHA_COMPRA,FECHA_SALIDA,VIDA_UTIL_MESES,COSTO_ADQUISITIVO,DEPREC_MES,DEPREC_ACUM,VALOR_LIBROS")] ACTIVOS_LUZ_DIVINA_COMPUTO aCTIVOS_LUZ_DIVINA_COMPUTO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aCTIVOS_LUZ_DIVINA_COMPUTO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aCTIVOS_LUZ_DIVINA_COMPUTO);
        }

        // GET: ACTIVOS_LUZ_DIVINA_COMPUTO/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ACTIVOS_LUZ_DIVINA_COMPUTO aCTIVOS_LUZ_DIVINA_COMPUTO = db.ACTIVOS_LUZ_DIVINA_COMPUTO.Find(id);
            if (aCTIVOS_LUZ_DIVINA_COMPUTO == null)
            {
                return HttpNotFound();
            }
            return View(aCTIVOS_LUZ_DIVINA_COMPUTO);
        }

        // POST: ACTIVOS_LUZ_DIVINA_COMPUTO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ACTIVOS_LUZ_DIVINA_COMPUTO aCTIVOS_LUZ_DIVINA_COMPUTO = db.ACTIVOS_LUZ_DIVINA_COMPUTO.Find(id);
            db.ACTIVOS_LUZ_DIVINA_COMPUTO.Remove(aCTIVOS_LUZ_DIVINA_COMPUTO);
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
