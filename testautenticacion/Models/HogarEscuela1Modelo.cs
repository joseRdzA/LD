using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;

namespace testautenticacion.Models
{
    public class HogarEscuela1Modelo
    {

        public string AnoMes { get; set; }

        public IPagedList<HogarEscuela1> Datos { get; set; }


        public List<HogarEscuela1> HogarEscuela1_List { get; set; }
    }
}