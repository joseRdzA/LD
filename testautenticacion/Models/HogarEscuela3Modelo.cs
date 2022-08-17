using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;

namespace testautenticacion.Models
{
    public class HogarEscuela3Modelo
    {

        public string AnoMes { get; set; }

        public IPagedList<HogarEscuela3> Datos { get; set; }


        public List<HogarEscuela3> HogarEscuela3_List { get; set; }
    }
}