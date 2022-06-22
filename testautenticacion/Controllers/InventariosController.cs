using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using testautenticacion.Permisos;
using testautenticacion.Models;

namespace testautenticacion.Controllers
{
    [Authorize]
    public class InventariosController : Controller
    {
        // GET: Inventarios
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Inventarios()
        {
            return View();
        }
    }
}