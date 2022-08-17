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
                //String LD = "testluzdivina@gmail.com";
                correo.From = new MailAddress("testluzdivina@gmail.com");
               // correo.From = new MailAddress(Email);
               // correo.To.Add(LD);
                correo.To.Add("testluzdivina@gmail.com");
                correo.Subject = "Solicitud de contacto: " + Nombre;
                //   correo.Body = NumTel;
                correo.Body = "<body>" + "<h1>Buenas! Saludos Arbolito de Felicidad Luz Divina</h1>" + "<h3>Mi nombre es:</h3>" + Nombre
     + "<h4>Me pueden contactar por favor</h4>" +
      "<h3>Mis datos son</h3>" +
     "<h3>Numero télefonico:</h3>" + NumTel +
     "<h3>Correo Electrónico:</h3>" + Email +
     "<h3>Detalle</h3>" + Msj +

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

            return View();
        }



        public ActionResult TCU()
        {

            return View();

        }

        [HttpPost]
        public ActionResult TCU(String Nombre, String Num, String Correo, String Grado, String Msj)
        {

            String body = "<body>" + "<h1>Buenas saludos Arbolito de Felicidad Luz Divina</h1>" + "<h3>Mi nombre es:</h3>" + Nombre
                + "<h4> les mando mi solicitud porque quiero realizar mi trabajo comunal o práctica profesional, para ello les comparto mis datos:</h4>" +
                "<h3>Número telefonico:</h3>" + Num +
                "<h3>Correo electrónico:</h3>" + Correo + "<h3>Grado académico es:</h3>" + Grado +
 "<body>";

            try
            {
                MailMessage correo = new MailMessage();
                correo.From = new MailAddress("testluzdivina@gmail.com");
                correo.To.Add(new MailAddress("testluzdivina@gmail.com"));
                correo.Subject ="Solicitud de TCU: "+ Nombre;
                //   correo.Body = NumTel;
                correo.Body = body;
                //correo.Body = Msj + Num + Grado;
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
                ViewBag.Msj = "Gracias por su interés, pronto estaremos en contacto.";
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }

            return View();


        }

        public ActionResult Matricula()
        {

            return View();

        }

        [HttpPost]
        public ActionResult Matricula(String Nombre, String Ced, String F_Nacimiento, String Edad,
           String Genero, String Provincia, String Descripcion, String NombreEncargado,
           String Ced_Encargado, String Nacimient_Encargado, String Hora_Cita)
        {

            String body = "<body>" + "<h1>Cita para la matricula</h1>" + "<h2>Datos del encargado</h2>" + "<h3>Nombre</h3>" + NombreEncargado
             + "<h3>Cédula</h3>" + Ced_Encargado +
             "<h3>Fecha de nacimiento</h3>" + Nacimient_Encargado +
             "<h3>Hora de la cita</h3>" + Hora_Cita +
             " <h2> Datos del Estudiante</h2> " +
             "<h3>Nombre</h3>" + Nombre +
             "<h3>Cédula</h3>" + Ced +
             "<h3>Fecha de nacimiento</h3>" + F_Nacimiento +
             "<h3>Edad</h3>" + Edad +
             "<h3>Género</h3>" + Genero +
             "<h3>Provincia</h3>" + Provincia +
             "<h3>Detalle</h3>" + Descripcion +
             "<body>";

            try
            {

                MailMessage correo = new MailMessage();
                correo.From = new MailAddress("testluzdivina@gmail.com");
                correo.To.Add(new MailAddress("testluzdivina@gmail.com"));
                correo.Subject ="Solicitud de Matrícula de: "+ Nombre;
                //  correo.Subject = Convert.ToString(F_Nacimiento);
                // correo.Subject = Convert.ToString(Nacimient_Encargado);
                // correo.Subject = Convert.ToString(Hora_Cita);
                //correo.Body = Ced + F_Nacimiento +Edad + Genero + Provincia + Descripcion + NombreEncargado + Ced_Encargado + Nacimient_Encargado + Hora_Cita ;
                correo.Body = body;
                correo.IsBodyHtml = true;
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

        public ActionResult Donaciones()
        {

            return View();

        }
    }
}