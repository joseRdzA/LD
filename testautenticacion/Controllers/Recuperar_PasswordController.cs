using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using testautenticacion.Models;
using testautenticacion.Logica;
using System.Net.Mail;

namespace testautenticacion.Controllers
{
    public class Recuperar_PasswordController : Controller
    {


        public void prd_enviar_correo(string email, string nombre, string token)
        {

            try
            {
                MailMessage correo = new MailMessage();
                //String LD = "testluzdivina@gmail.com";
                correo.From = new MailAddress("testluzdivina@gmail.com");
                // correo.From = new MailAddress(Email);
                // correo.To.Add(LD);
               // correo.To.Add(email); //activa este cuando ya acabes las pruebas...
                correo.To.Add(email);// este lo quitas cuando ya acabes las pruebas...
                correo.Subject = nombre;
                //   correo.Body = NumTel;
                correo.Body = "<body>" + "<h1>Arbolito de Felicidad Luz Divina le informa que se ha solicitado acceso a recuperar su contraseña, Acceda a este enlace para recuperar su contraseña</h1>" +
                         "<h2><a href='https://localhost:44368/Recuperacion_Accesos/index?tk="+ token+"'>Recuperar Accesos</a></h2>" +
                       

                    "<body>";
                correo.IsBodyHtml = true;
                correo.Priority = MailPriority.Normal;

                //config SMTP
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 25;
                smtp.EnableSsl = true;
                //string sCuentaCorreo = "testluzdivina@gmail.com";
                string sCuentaEmail = "testluzdivina@gmail.com";
                string sPasswordEmail = "aucrgkgdqhukwthq";
                smtp.Credentials = new System.Net.NetworkCredential(sCuentaEmail, sPasswordEmail);
                smtp.Send(correo);
                ViewBag.Mensaje = "Gracias por su interés, pronto estaremos en contacto.";

            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }





        }


        // GET: Recuperar_Password
        public ActionResult Index()
        {
            if (Session["Mensaje"] != null)
            {
                Response.Write("<script>alert('Su usuario esta bloqueado, Contraseña erronea!!');</script>");
                
            }

           
            return View();
        }

        // GET: Recuperar_Password/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Recuperar_Password/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Recuperar_Password/Create
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

        // GET: Recuperar_Password/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }


        public ActionResult Recuperar(string correo)
        {

            //  Usuarios1 objeto = new LO_Usuario().EditarUsuario(cedula, correo, clave);

            //  Session["Mensaje"] = "Password Recuperado!!";
            Random r = new Random();
            string  tk =  r.Next(1000, 99999).ToString(); // se genera un numero aleatorio de 4 a 5 digitos
            LO_Usuario l = new LO_Usuario(); // se crea una instacia de LO_Usuario
            l.guardarToken( correo, tk); // guarda el token en DB

            prd_enviar_correo(correo,"Estimado Usuario",tk);


            return RedirectToAction("Index", "Home");
        }


        // POST: Recuperar_Password/Edit/5
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

        // GET: Recuperar_Password/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Recuperar_Password/Delete/5
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
