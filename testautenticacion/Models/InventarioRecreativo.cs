using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace testautenticacion.Models
{
    public class InventarioRecreativo
    {
        public string Descripcion { get; set; }
        public List<Activos_Recreativos> DatosRec { get; set; }
    }
}