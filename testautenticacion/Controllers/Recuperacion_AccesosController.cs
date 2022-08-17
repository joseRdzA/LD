using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using testautenticacion.Logica;

namespace testautenticacion.Controllers
{
    public class Recuperacion_AccesosController : Controller
    {
        // GET: Recupeacion_Accesos
        public ActionResult Index()
        {
            LO_Usuario lu = new LO_Usuario();

            int token = 0;
             
            try
            {

                if (Request.QueryString["tk"] == null) {

                    if (Session["Accion"] != null)
                    {
                        if (Session["Accion"].ToString() == "1")
                        {
                            Response.Write("<script>alert('" + Session["Mensaje"] + "');</script>");
                            Session["Accion"] = 0;
                        }

                    }


                    token = Int32.Parse(Session["token"].ToString());
                }
                else
                {
                    if(Session["Accion"] != null){
                        if (Session["Accion"].ToString() == "1")
                        {
                            Response.Write("<script>alert('" + Session["Mensaje"] + "');</script>");
                            Session["Accion"] = 0;
                        }

                    }
                    

                   // Response.Write("<script>alert('" + Session["Mensaje"] + "');</script>");

                    string tk = Request.QueryString["tk"].ToString();
                    token = Int32.Parse(tk);
                    Session["Accion"] = 0;
                }
                 

            }
            catch
            {
                token = Int32.Parse(Session["token"].ToString());
            }


            
            
            Session["token"] = token;

            string correo = lu.ValidarToken(token.ToString());

            if (correo == "")
            {
                Session["Mensaje"] = "Token Invalido!";
                Response.Write("<script>alert('" + Session["Mensaje"] + "');</script>");
                return RedirectToAction("Index", "Home");

            }
            else {
                return View();
            }


           
        }

        public ActionResult Reactivar_Cuenta(string clave1,string clave2 )
        {

            if (clave1 == clave2)
            {
                string token = Session["token"].ToString();

                LO_Usuario lu = new LO_Usuario();

                string correo = lu.ValidarToken(token);

                if (correo == "")
                {
                    Session["Mensaje"] = "Token Invalido!";
                    Response.Write("<script>alert('" + Session["Mensaje"] + "');</script>");
                    return View();

                }
                else
                {
                    lu.activarCuenta(token, correo, clave1);
                    Session["Mensaje"] = "Cambio de contraseña aplicado";

                    Response.Write("<script>alert('" + Session["Mensaje"] + "');</script>");

                    return RedirectToAction("Index", "Home");

                }

            }
            else {
                Session["Mensaje"] = "Las contraseñas son diferentes, corrija antes de continuar";
                Session["Accion"] = "1";
               return RedirectToAction("Index", "Recuperacion_Accesos");
                

            }


            
            //return View();

        }

        // GET: Recupeacion_Accesos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Recupeacion_Accesos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Recupeacion_Accesos/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Recupeacion_Accesos/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Recupeacion_Accesos/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Recupeacion_Accesos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Recupeacion_Accesos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
