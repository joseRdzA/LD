using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;

namespace testautenticacion.Models
{
    public class KinderModelo
    {

        public string AnoMes { get; set; }

        public IPagedList<Kinder> Datos { get; set; }


        public List<Kinder> Kinder_List { get; set; }
    }
}
