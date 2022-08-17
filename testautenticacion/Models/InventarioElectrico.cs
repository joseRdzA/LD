using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace testautenticacion.Models
{
    public class InventarioElectrico
    {

        public string Descripcion { get; set; }
        public IPagedList<Activos_Electricos> DatosElec { get; set; }

        public List<Activos_Electricos> DatosList { get; set; }  //ojo
    }
}