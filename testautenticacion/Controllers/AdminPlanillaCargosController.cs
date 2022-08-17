using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace testautenticacion.Controllers
{
    [Authorize]
    public class AdminPlanillaCargosController : Controller
    {
        // GET: AdminPlanillaCargos
        public ActionResult Index()
        {
            return View();
        }
    }
}