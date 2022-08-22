using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using testautenticacion.Models;
using testautenticacion.Permisos;

namespace testautenticacion.Controllers
{
    [Authorize]
    [PermisosRol(Rol1.Administrador)]
    public class AdminPlanillaCargosController : Controller
    {
        // GET: AdminPlanillaCargos
        public ActionResult Index()
        {
            return View();
        }
    }
}