using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;

namespace testautenticacion.Models
{
    public class CasaCuna2Modelo
    {

        public string AnoMes { get; set; }

        public IPagedList<CasaCuna2> Datos { get; set; }


        public List<CasaCuna2> CasaCuna2_List { get; set; }
    }
}