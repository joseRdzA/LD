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

namespace testautenticacion.Controllers
{
    public class Activos_RecreativosController : Controller
    {
        private AADFLDEntities db = new AADFLDEntities();

        // GET: Activos_Recreativos
        public ActionResult Index()
        {
            InventarioRecreativo inv = new InventarioRecreativo();
            inv.DatosRec = db.Activos_Recreativos.ToList();

            return View(inv);
        }

        //consultarDatos

        [HttpPost]
        public ActionResult ConsultarDatos(Activos_Recreativos obj)
        {
            InventarioRecreativo inv = new InventarioRecreativo();

            if (!string.IsNullOrEmpty(obj.Descripcion))
                inv.DatosRec = db.Activos_Recreativos.Where(x => x.Descripcion.Contains(obj.Descripcion)).ToList();
            else
                inv.DatosRec = db.Activos_Recreativos.ToList();

            return View("Index", inv);
        }


        [HttpPost]
        public ActionResult OrdenarProductos()
        {
            InventarioRecreativo inv = new InventarioRecreativo();
            inv.DatosRec = db.Activos_Recreativos.OrderBy(Descripcion => Descripcion.Descripcion).ToList();

            return View("Index", inv);
        }

        //PDF 

        public ActionResult Imprimir()
        {
            return new ActionAsPdf("ReporteRecreativos") { FileName = "ReporteRecreativos.pdf" };
        }

        public ActionResult ReporteRecreativos()
        {
            InventarioRecreativo inv = new InventarioRecreativo();
            inv.DatosRec = db.Activos_Recreativos.ToList();
            return View(inv);
        }
        // GET: Activos_Recreativos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activos_Recreativos activos_Recreativos = db.Activos_Recreativos.Find(id);
            if (activos_Recreativos == null)
            {
                return HttpNotFound();
            }
            return View(activos_Recreativos);
        }

        // GET: Activos_Recreativos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Activos_Recreativos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Activo_Recreativo,Codigo_Activo_Recreativo,Descripcion,Marca,Serie,Fecha_Compra,Fecha_Salida,Vida_Util_Meses,Costo_Adquisitivo,Deprec_Mes,Deprec_Acum,Valor_Libros")] Activos_Recreativos activos_Recreativos)
        {
            if (ModelState.IsValid)
            {
                db.Activos_Recreativos.Add(activos_Recreativos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(activos_Recreativos);
        }

        // GET: Activos_Recreativos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activos_Recreativos activos_Recreativos = db.Activos_Recreativos.Find(id);
            if (activos_Recreativos == null)
            {
                return HttpNotFound();
            }
            return View(activos_Recreativos);
        }

        // POST: Activos_Recreativos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Activo_Recreativo,Codigo_Activo_Recreativo,Descripcion,Marca,Serie,Fecha_Compra,Fecha_Salida,Vida_Util_Meses,Costo_Adquisitivo,Deprec_Mes,Deprec_Acum,Valor_Libros")] Activos_Recreativos activos_Recreativos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(activos_Recreativos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(activos_Recreativos);
        }

        // GET: Activos_Recreativos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activos_Recreativos activos_Recreativos = db.Activos_Recreativos.Find(id);
            if (activos_Recreativos == null)
            {
                return HttpNotFound();
            }
            return View(activos_Recreativos);
        }

        // POST: Activos_Recreativos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Activos_Recreativos activos_Recreativos = db.Activos_Recreativos.Find(id);
            db.Activos_Recreativos.Remove(activos_Recreativos);
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
