using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using testautenticacion.Models;

namespace testautenticacion.Permisos
{
    public class PermisosRolAttribute : ActionFilterAttribute
    {
        private Rol1 idrol;


        public PermisosRolAttribute(Rol1 _idrol) {

            idrol = _idrol;
        }



        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["Usuario"] != null) {

                Usuarios1 usuario = HttpContext.Current.Session["Usuario"] as Usuarios1;


                if (usuario.IdRol != this.idrol) {

                    filterContext.Result = new RedirectResult("~/Home/SinPermiso");
                
                }


            }



            base.OnActionExecuting(filterContext);
        }



    }
}