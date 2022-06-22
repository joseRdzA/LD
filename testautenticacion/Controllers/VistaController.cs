using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace testautenticacion.Controllers
{
    public class VistaController : Controller
    {
        // GET: Vista
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TCU() {

            return View();

        }

        public ActionResult Matricula()
        {

            return View();

        }

        public ActionResult Donaciones()
        {

            return View();

        }
    }
}