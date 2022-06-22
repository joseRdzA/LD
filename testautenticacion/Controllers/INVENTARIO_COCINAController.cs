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
    public class INVENTARIO_COCINAController : Controller
    {
        private AADFLDEntities3 db = new AADFLDEntities3();

        // GET: INVENTARIO_COCINA
        public ActionResult Index()
        {
            return View(db.INVENTARIO_COCINA.ToList());
        }

        // GET: INVENTARIO_COCINA/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INVENTARIO_COCINA iNVENTARIO_COCINA = db.INVENTARIO_COCINA.Find(id);
            if (iNVENTARIO_COCINA == null)
            {
                return HttpNotFound();
            }
            return View(iNVENTARIO_COCINA);
        }

        // GET: INVENTARIO_COCINA/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: INVENTARIO_COCINA/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CODIGO_COCINA,PRODUCTO,MEDIDA,EXISTENCIA_INICIAL,ENTRADAS,SALIDAS,EXISTENCIAS")] INVENTARIO_COCINA iNVENTARIO_COCINA)
        {
            if (ModelState.IsValid)
            {
                db.INVENTARIO_COCINA.Add(iNVENTARIO_COCINA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(iNVENTARIO_COCINA);
        }

        // GET: INVENTARIO_COCINA/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INVENTARIO_COCINA iNVENTARIO_COCINA = db.INVENTARIO_COCINA.Find(id);
            if (iNVENTARIO_COCINA == null)
            {
                return HttpNotFound();
            }
            return View(iNVENTARIO_COCINA);
        }

        // POST: INVENTARIO_COCINA/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CODIGO_COCINA,PRODUCTO,MEDIDA,EXISTENCIA_INICIAL,ENTRADAS,SALIDAS,EXISTENCIAS")] INVENTARIO_COCINA iNVENTARIO_COCINA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iNVENTARIO_COCINA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(iNVENTARIO_COCINA);
        }

        // GET: INVENTARIO_COCINA/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INVENTARIO_COCINA iNVENTARIO_COCINA = db.INVENTARIO_COCINA.Find(id);
            if (iNVENTARIO_COCINA == null)
            {
                return HttpNotFound();
            }
            return View(iNVENTARIO_COCINA);
        }

        // POST: INVENTARIO_COCINA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            INVENTARIO_COCINA iNVENTARIO_COCINA = db.INVENTARIO_COCINA.Find(id);
            db.INVENTARIO_COCINA.Remove(iNVENTARIO_COCINA);
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
