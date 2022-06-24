using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace testautenticacion.Models
{
    public class InventarioComputo
    {
        public string Descripcion { get; set; }
        public List<Activos_Computacion> DatosPC { get; set; }
    }
}