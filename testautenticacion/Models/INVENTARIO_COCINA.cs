//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------
namespace testautenticacion.Models
{
    using System;
    using System.Collections.Generic;
    public partial class Inventario_Cocina
    {
        public int Id_Cocina { get; set; }
        public string Codigo_Producto { get; set; }
        public string Producto { get; set; }
        public string Medida { get; set; }
        public int Existencia_Inicial { get; set; }
        public int Entradas { get; set; }
        public int Salidas { get; set; }
        // public int Existencias { get; set; }
        public int Existencias
        {
            get
            {
                //  DateTime now = DateTime.Today;
                int Existencias = Existencia_Inicial + Entradas - Salidas;
                return Existencias;
            }
        }
    }
}
