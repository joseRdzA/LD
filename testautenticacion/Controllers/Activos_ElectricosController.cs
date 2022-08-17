using Rotativa;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using testautenticacion.Models;
using PagedList;
using PagedList.Mvc;

namespace testautenticacion.Controllers
{
    [Authorize]
    public class Activos_ElectricosController : Controller
    {
        private AADFLDEntities db = new AADFLDEntities();

        // GET: Activos_Electricos
        public ActionResult Index(int? pageNumber)
        {
            pageNumber = pageNumber ?? 1;
            InventarioElectrico inv = new InventarioElectrico();
            inv.DatosElec = db.Activos_Electricos.ToList().ToPagedList((int)pageNumber, 5); 

            return View(inv);
        }

        [HttpPost]
        public ActionResult ConsultarDatos(InventarioElectrico obj, int? pageNumber)
        {
            pageNumber = pageNumber ?? 1;
            InventarioElectrico inv = new InventarioElectrico();

            if (!string.IsNullOrEmpty(obj.Descripcion)) { 
                inv.DatosElec = db.Activos_Electricos.Where(x => x.Descripcion.Contains(obj.Descripcion)).ToList().ToPagedList((int)pageNumber, 5); 
            }
            else { 
                inv.DatosElec = db.Activos_Electricos.ToList().ToPagedList((int)pageNumber, 5);
            }

            return View("Index", inv);
        }
        [HttpPost]
        public ActionResult OrdenarProductos(int? pageNumber)
        {
            pageNumber = pageNumber ?? 1;
            InventarioElectrico inv = new InventarioElectrico();
            inv.DatosElec = db.Activos_Electricos.OrderBy(Descripcion => Descripcion.Descripcion).ToList().ToPagedList((int)pageNumber, 5); 

            return View("Index", inv); //ojo con esto, la vista y el metodo... OJO CON EL INDEX 
        }

        //PDF 
        public ActionResult Imprimir()
        {
            return new ActionAsPdf("ReporteElectricos") { FileName = "ReporteActivosElectricos.pdf" };
        }

        public ActionResult ReporteElectricos()
        {
            InventarioElectrico inv = new InventarioElectrico();
            inv.DatosList = db.Activos_Electricos.ToList();
            return View(inv);
        }


        // GET: Activos_Electricos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activos_Electricos activos_Electricos = db.Activos_Electricos.Find(id);
            if (activos_Electricos == null)
            {
                return HttpNotFound();
            }
            return View(activos_Electricos);
        }

        // GET: Activos_Electricos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Activos_Electricos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Electrico,Codigo_Activo_Electrico,Descripcion,Marca,Serie,Fecha_Compra,Fecha_Salida,Vida_Util_Meses,Costo_Adquisitivo,Deprec_Mes,Deprec_Acum,Valor_Libros")] Activos_Electricos activos_Electricos)
        {
            if (ModelState.IsValid)
            {
                db.Activos_Electricos.Add(activos_Electricos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(activos_Electricos);
        }

        // GET: Activos_Electricos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activos_Electricos activos_Electricos = db.Activos_Electricos.Find(id);
            if (activos_Electricos == null)
            {
                return HttpNotFound();
            }
            return View(activos_Electricos);
        }

        // POST: Activos_Electricos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Electrico,Codigo_Activo_Electrico,Descripcion,Marca,Serie,Fecha_Compra,Fecha_Salida,Vida_Util_Meses,Costo_Adquisitivo,Deprec_Mes,Deprec_Acum,Valor_Libros")] Activos_Electricos activos_Electricos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(activos_Electricos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(activos_Electricos);
        }

        // GET: Activos_Electricos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activos_Electricos activos_Electricos = db.Activos_Electricos.Find(id);
            if (activos_Electricos == null)
            {
                return HttpNotFound();
            }
            return View(activos_Electricos);
        }

        // POST: Activos_Electricos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Activos_Electricos activos_Electricos = db.Activos_Electricos.Find(id);
            db.Activos_Electricos.Remove(activos_Electricos);
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
