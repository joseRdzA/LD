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
    public class Inventario_CocinaController : Controller
    {
        private AADFLDEntities db = new AADFLDEntities();

        // GET: Inventario_Cocina
        public ActionResult Index(int? pageNumber)
        {
            pageNumber = pageNumber ?? 1;
            Inventario inv = new Inventario();
           inv.Datos = db.Inventario_Cocina.ToList().ToPagedList((int)pageNumber,5); //ojo con esto en las funciones

            return View(inv);
        }
        
        [HttpPost]
        public ActionResult ConsultarDatos(Inventario obj, int? pageNumber)
        {
            pageNumber = pageNumber ?? 1;
            Inventario inv = new Inventario();

            if (!string.IsNullOrEmpty(obj.Nombre))
            {
                inv.Datos = db.Inventario_Cocina.Where(x => x.Producto.Contains(obj.Nombre)).ToList().ToPagedList((int)pageNumber, 5);
            }
            else
            {
                inv.Datos = db.Inventario_Cocina.ToList().ToPagedList((int)pageNumber, 5);
            }

            return View("Index", inv);
        }


      [HttpPost]
       public ActionResult OrdenarProductos(int? pageNumber)
        {
            pageNumber = pageNumber ?? 1;
            Inventario inv = new Inventario();
            inv.Datos = db.Inventario_Cocina.OrderBy(Producto => Producto.Producto).ToList().ToPagedList((int)pageNumber, 5);

            return View("Index",inv); //ojo con esto, la vista y el metodo... OJO CON EL INDEX 
        }

        //PDF 

        public ActionResult Imprimir()
        {
            return new ActionAsPdf("ReporteCocina") { FileName = "ReporteCocina.pdf" };
        }

        public ActionResult ReporteCocina()
        {
            Inventario inv = new Inventario();
            inv.DatosList = db.Inventario_Cocina.ToList(); 
            return View(inv);
        }
       

        // GET: Inventario_Cocina/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventario_Cocina inventario_Cocina = db.Inventario_Cocina.Find(id);
            if (inventario_Cocina == null)
            {
                return HttpNotFound();
            }
            return View(inventario_Cocina);
        }

        // GET: Inventario_Cocina/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Inventario_Cocina/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Cocina,Codigo_Producto,Producto,Medida,Existencia_Inicial,Entradas,Salidas,Existencias")] Inventario_Cocina inventario_Cocina)
        {
            if (ModelState.IsValid)
            {
                db.Inventario_Cocina.Add(inventario_Cocina);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(inventario_Cocina);
        }

        // GET: Inventario_Cocina/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventario_Cocina inventario_Cocina = db.Inventario_Cocina.Find(id);
            if (inventario_Cocina == null)
            {
                return HttpNotFound();
            }
            return View(inventario_Cocina);
        }

        // POST: Inventario_Cocina/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Cocina,Codigo_Producto,Producto,Medida,Existencia_Inicial,Entradas,Salidas,Existencias")] Inventario_Cocina inventario_Cocina)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inventario_Cocina).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(inventario_Cocina);
        }

        // GET: Inventario_Cocina/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventario_Cocina inventario_Cocina = db.Inventario_Cocina.Find(id);
            if (inventario_Cocina == null)
            {
                return HttpNotFound();
            }
            return View(inventario_Cocina);
        }

        // POST: Inventario_Cocina/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Inventario_Cocina inventario_Cocina = db.Inventario_Cocina.Find(id);
            db.Inventario_Cocina.Remove(inventario_Cocina);
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
