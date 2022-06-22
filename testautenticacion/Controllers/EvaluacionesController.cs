using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace testautenticacion.Controllers
{
    [Authorize]
    public class EvaluacionesController : Controller
    {
        // GET: Evaluaciones
        public ActionResult EvaluacionPsicologia()
        {
            return View();
        }

        public ActionResult EvaluacionDocente()
        {
            return View();
        }

        public ActionResult EvaluacionAsistente()
        {
            return View();
        }

        public ActionResult EvaluacionChofer()
      {
           return View();
       }

        public ActionResult EvaluacionMiselanea()
        {
            return View();
        }

        public ActionResult EvaluacionCocina()
        {
            return View();
        }
    }

  
}
