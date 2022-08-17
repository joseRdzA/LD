using PagedList;
using Rotativa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using testautenticacion.Models;

namespace testautenticacion.Controllers
{
    public class EstudiantesController : Controller
    {

        private AADFLDEntities db = new AADFLDEntities();
        // GET: Estudiantes
        AADFLDEntities context;
        public ActionResult Index(int? pageNumber)
        {
            pageNumber = pageNumber ?? 1;
            EstudiantesModelo inv = new EstudiantesModelo();
            inv.Datos = db.Estudiantes_List.OrderBy(t => new { t.Nivel, t.Nombre_Estudiante }).ToList().ToPagedList((int)pageNumber, 6); //ojo con esto en las funciones

            return View(inv);
        }

        /*  public ActionResult GettAll2(string PDF)
          {
              var e_Lista_Estudiantes = db.Estudiantes_List.Where(x => x.Nivel_Estudiante.Nivel.Contains(PDF));

              return View(e_Lista_Estudiantes.ToList());
          }

          public ActionResult PrintAll(string PDF)
          {

              var q = new ActionAsPdf("GettAll2", new { PDF });
              return q;

          }
        */
        public ActionResult Imprimir(string PDF)
        {

            var q = new ActionAsPdf("ReporteEstudiante", new { PDF });
            return q;
        }

        public ActionResult ReporteEstudiante(string PDF)
        {
            EstudiantesModelo inv = new EstudiantesModelo();
            inv.Estudiantes_List1 = db.Estudiantes_List.OrderBy(t => new { t.Nivel, t.Nombre_Estudiante }).Where(x => x.Nivel_Estudiante.Nivel.Equals(PDF)).ToList();
            return View(inv);
        }




        [HttpPost]
        public ActionResult ConsultarDatos(EstudiantesModelo obj, int? pageNumber)
        {
            pageNumber = pageNumber ?? 1;
            EstudiantesModelo inv = new EstudiantesModelo();

            if (!string.IsNullOrEmpty(obj.Nivel2))
            {
                inv.Datos = db.Estudiantes_List.OrderBy(t => new { t.Nivel, t.Nombre_Estudiante }).Where(x => x.Nivel_Estudiante.Nivel.Contains(obj.Nivel2)).ToList().ToPagedList((int)pageNumber, 6);
            }
            else
            {
                inv.Datos = db.Estudiantes_List.ToList().ToPagedList((int)pageNumber, 6);
            }

            return View("Index", inv);
        }
        //consultar nombre 

        [HttpPost]
        public ActionResult ConsultarNombres(EstudiantesModelo obj, int? pageNumber)
        {
            pageNumber = pageNumber ?? 1;
            EstudiantesModelo inv = new EstudiantesModelo();

            if (!string.IsNullOrEmpty(obj.Nombre_Estudiante))
            {
                inv.Datos = db.Estudiantes_List.OrderBy(t => new { t.Nivel, t.Nombre_Estudiante }).Where(x => x.Nombre_Estudiante.Contains(obj.Nombre_Estudiante)).ToList().ToPagedList((int)pageNumber, 6);
            }
            else
            {
                inv.Datos = db.Estudiantes_List.ToList().ToPagedList((int)pageNumber, 6);
            }

            return View("Index", inv);
        }




        public ActionResult Create()
        {
            return View();
        }

        // POST: CasaCuna1/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nombre_Estudiante,Cedula,fechaNacimiento,Numero_Contacto,Nivel")] Estudiantes_List estudiantes_List)
        {
            if (ModelState.IsValid)
            {
                db.Estudiantes_List.Add(estudiantes_List);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(estudiantes_List);
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