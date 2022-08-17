using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace testautenticacion.Models
{
    public class EstudiantesModelo
    {

        public string Nivel2 { get; set; }
        public string Nombre_Estudiante { get; set; }

        public IPagedList<Estudiantes_List> Datos { get; set; }


        public List<Estudiantes_List> Estudiantes_List1 { get; set; }
    }
}