using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;



namespace testautenticacion.Models
{
    public class Usuarios1
    {
        public string Nombres { get; set; }
        public string Correo { get; set; }

        [MaxLength(8)]
        [MinLength(8)]
        public string Clave { get; set; }

        public Rol1 IdRol { get; set; }



    }
}