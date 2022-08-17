using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace testautenticacion.Models
{
    public class Inventario
    {
        public string Nombre { get; set; }
        public IPagedList<Inventario_Cocina> Datos { get; set; } //ojo con el IPAGED LIST

        public List<Inventario_Cocina> DatosList { get; set; }  //ojo

       
    }
}