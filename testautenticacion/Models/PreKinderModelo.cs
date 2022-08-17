using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;

namespace testautenticacion.Models
{
    public class PreKinderModelo
    {

        public string AnoMes { get; set; }

        public IPagedList<PreKinder> Datos { get; set; }


        public List<PreKinder> PreKinder_List { get; set; }
    }
}