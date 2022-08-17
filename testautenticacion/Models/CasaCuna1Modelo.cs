using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;

namespace testautenticacion.Models
{
    public class CasaCuna1Modelo
    {

        public string AnoMes { get; set; }

        public IPagedList<CasaCuna1> Datos { get; set; }


        public List<CasaCuna1> CasaCuna1_List { get; set; }
    }
}