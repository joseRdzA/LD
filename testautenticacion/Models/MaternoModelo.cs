using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;

namespace testautenticacion.Models
{
    public class MaternoModelo
    {

        public string AnoMes { get; set; }

        public IPagedList<Materno> Datos { get; set; }


        public List<Materno> Materno_List { get; set; }
    }
}