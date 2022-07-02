using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using System.Net;

namespace testautenticacion.Controllers
{
    public class VistaController : Controller
    {
        // GET: Vista

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(String Nombre, String NumTel, String Email, String Msj)
        {

            try
            {
                MailMessage correo = new MailMessage();
                correo.From = new MailAddress("testluzdivina@gmail.com");
                correo.To.Add(Email);
                correo.Subject = Nombre;
             //   correo.Body = NumTel;
                correo.Body = Msj + NumTel;
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