using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;

namespace testautenticacion.Models
{
    public class HogarEscuela2Modelo
    {

        public string AnoMes { get; set; }

        public IPagedList<HogarEscuela2> Datos { get; set; }


        public List<HogarEscuela2> HogarEscuela2_List { get; set; }
    }
}