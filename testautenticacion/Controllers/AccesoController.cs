using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


using testautenticacion.Models;
using testautenticacion.Logica;
using System.Web.Security;
using System.Configuration;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;

namespace testautenticacion.Controllers
{
   
    public class AccesoController : Controller
    {

      
        // GET: Acceso
        public ActionResult Index()
        {
            if (Session["Mensaje"] != null) {
                Response.Write("<script>alert('" + Session["Mensaje"] + "');</script>");
            }

          

            return View();
        }
 


        [HttpPost]
        public ActionResult Index(string correo, string clave)
        {
            Usuarios1 objeto = new LO_Usuario().EncontrarUsuario(correo, clave);

            if (objeto.Nombres != null) {


                FormsAuthentication.SetAuthCookie(objeto.Correo, false);

                Session["Usuario"] = objeto;
                Session["acceso_fallido"] = 0;

                return RedirectToAction("Index", "Home");
            }
            else
            {

                LO_Usuario lu = new LO_Usuario();
                string estado = lu.validarUsuario(correo, clave);

                if (estado == "I") {
                    Session["Mensaje"] = "Su usuario esta bloqueado!!";
                    Response.Write("<script>alert('Su usuario esta bloqueado!!');</script>");

                }
                else{

                if (Session["acceso_fallido"] == null)
                {
                    Session["acceso_fallido"] = 1;
                }
                else {

                    int acceso_fallido = Int32.Parse(Session["acceso_fallido"].ToString());
                    Session["acceso_fallido"] = acceso_fallido + 1;
                }


                int contador = Int32.Parse(Session["acceso_fallido"].ToString());

                 
                if(contador >= 3)
                {


                    Usuarios1 obj = new LO_Usuario().InactivarUsuario(correo);// inactiva la cuenta

                    Session["acceso_fallido"] = 0;
                    Session["Mensaje"] = "Su usuario esta bloqueado!!";

                    Response.Redirect("Recuperar_Password");
                  

                    }

                }
            }





            return View();
        }
        public bool IsReCaptchValid()
        {
            var result = false;
            var captchaResponse = Request.Form["g-recaptcha-response"];
            var secretKey = ConfigurationManager.AppSettings["SecretKey"];
            var apiUrl = "https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}";
            var requestUri = string.Format(apiUrl, secretKey, captchaResponse);
            var request = (HttpWebRequest)WebRequest.Create(requestUri);

            using (WebResponse response = request.GetResponse())
            {
                using (StreamReader stream = new StreamReader(response.GetResponseStream()))
                {
                    JObject jResponse = JObject.Parse(stream.ReadToEnd());
                    var isSuccess = jResponse.Value<bool>("success");
                    result = (isSuccess) ? true : false;
                }
            }
            return result;
        }
        /*  if (IsReCaptchValid())
              {
                  return View();
      }
             else
             {
                  ScriptManager.RegisterClientScriptBlock(this, typeof(string),
                      "MsgAlert", "alert('Validación Captcha incorrecta');window.location ='Default.aspx';", true); */
    }

}