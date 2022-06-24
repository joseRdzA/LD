using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace testautenticacion.Models
{
    public class Inventario
    {
        public string Nombre { get; set; }
        public List<Inventario_Cocina> Datos { get; set; }
    }
}