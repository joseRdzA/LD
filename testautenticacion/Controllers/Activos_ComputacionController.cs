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
using testautenticacion.Permisos;

namespace testautenticacion.Controllers
{
    [Authorize]
    [PermisosRol(Rol1.Administrador)]
    public class Activos_ComputacionController : Controller
    {
        private AADFLDEntities db = new AADFLDEntities();

        // GET: Activos_Computacion
        public ActionResult Index(int? pageNumber)
        {
            pageNumber = pageNumber ?? 1;
            InventarioComputo inv = new InventarioComputo();
            inv.DatosPC = db.Activos_Computacion.ToList().ToPagedList((int)pageNumber, 5); 

            return View(inv);
        }


        [HttpPost]
        public ActionResult ConsultarDatos(InventarioComputo obj, int? pageNumber)
        {
            pageNumber = pageNumber ?? 1;
            InventarioComputo inv = new InventarioComputo();

            if (!string.IsNullOrEmpty(obj.Descripcion))
            {
                inv.DatosPC = db.Activos_Computacion.Where(x => x.Descripcion.Contains(obj.Descripcion)).ToList().ToPagedList((int)pageNumber, 5);
            }
            else
            {
                inv.DatosPC = db.Activos_Computacion.ToList().ToPagedList((int)pageNumber, 5);
            }

            return View("Index", inv);
        }

        [HttpPost]
        public ActionResult OrdenarProductos(int? pageNumber)
        {
            pageNumber = pageNumber ?? 1;
            InventarioComputo inv = new InventarioComputo();
            inv.DatosPC = db.Activos_Computacion.OrderBy(Descripcion => Descripcion.Descripcion).ToList().ToPagedList((int)pageNumber, 5);

            return View("Index", inv); //ojo con esto, la vista y el metodo... OJO CON EL INDEX 
        }

        //PDF 

        public ActionResult Imprimir()
        {
            return new ActionAsPdf("ReporteComputacion") { FileName = "ReporteComputacion.pdf" };
        }

        public ActionResult ReporteComputacion()
        {
            InventarioComputo inv = new InventarioComputo();
            inv.DatosList = db.Activos_Computacion.ToList();
            return View(inv);
        }

        // GET: Activos_Computacion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activos_Computacion activos_Computacion = db.Activos_Computacion.Find(id);
            if (activos_Computacion == null)
            {
                return HttpNotFound();
            }
            return View(activos_Computacion);
        }

        // GET: Activos_Computacion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Activos_Computacion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Computacion,Codigo_Activo_Computo,Descripcion,Marca,Serie,Fecha_Copmra,Fecha_Salida,Vida_Util_Meses,Costo_Adquisitivo,Deprec_Mes,Deprec_Acum,Valor_Libros")] Activos_Computacion activos_Computacion)
        {
            if (ModelState.IsValid)
            {
                db.Activos_Computacion.Add(activos_Computacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(activos_Computacion);
        }

        // GET: Activos_Computacion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activos_Computacion activos_Computacion = db.Activos_Computacion.Find(id);
            if (activos_Computacion == null)
            {
                return HttpNotFound();
            }
            return View(activos_Computacion);
        }

        // POST: Activos_Computacion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Computacion,Codigo_Activo_Computo,Descripcion,Marca,Serie,Fecha_Copmra,Fecha_Salida,Vida_Util_Meses,Costo_Adquisitivo,Deprec_Mes,Deprec_Acum,Valor_Libros")] Activos_Computacion activos_Computacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(activos_Computacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(activos_Computacion);
        }

        // GET: Activos_Computacion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activos_Computacion activos_Computacion = db.Activos_Computacion.Find(id);
            if (activos_Computacion == null)
            {
                return HttpNotFound();
            }
            return View(activos_Computacion);
        }

        // POST: Activos_Computacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Activos_Computacion activos_Computacion = db.Activos_Computacion.Find(id);
            db.Activos_Computacion.Remove(activos_Computacion);
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
