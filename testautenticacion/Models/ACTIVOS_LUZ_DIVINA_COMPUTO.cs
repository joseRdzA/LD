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
    
    public partial class ACTIVOS_LUZ_DIVINA_COMPUTO
    {
        public string CODIGO_ACTIVO_COMPUTO { get; set; }
        public string DESCRIPCION { get; set; }
        public string MARCA { get; set; }
        public string SERIE { get; set; }
        public Nullable<System.DateTime> FECHA_COMPRA { get; set; }
        public Nullable<System.DateTime> FECHA_SALIDA { get; set; }
        public Nullable<int> VIDA_UTIL_MESES { get; set; }
        public Nullable<int> COSTO_ADQUISITIVO { get; set; }
        public Nullable<int> DEPREC_MES { get; set; }
        public Nullable<int> DEPREC_ACUM { get; set; }
        public Nullable<int> VALOR_LIBROS { get; set; }
    }
}