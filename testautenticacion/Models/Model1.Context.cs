﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AADFLDEntities3 : DbContext
    {
        public AADFLDEntities3()
            : base("name=AADFLDEntities3")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ACTIVOS_LUZ_DIVINA_COMPUTO> ACTIVOS_LUZ_DIVINA_COMPUTO { get; set; }
        public virtual DbSet<ACTIVOS_LUZ_DIVINA_ELECTRICOS> ACTIVOS_LUZ_DIVINA_ELECTRICOS { get; set; }
        public virtual DbSet<ACTIVOS_LUZ_DIVINA_RECREATIVOS> ACTIVOS_LUZ_DIVINA_RECREATIVOS { get; set; }
        public virtual DbSet<Cargos> Cargos { get; set; }
        public virtual DbSet<Estudiantes> Estudiantes { get; set; }
        public virtual DbSet<Funcionario> Funcionario { get; set; }
        public virtual DbSet<INVENTARIO_COCINA> INVENTARIO_COCINA { get; set; }
        public virtual DbSet<Niveles> Niveles { get; set; }
        public virtual DbSet<Reserva_Matriculas> Reserva_Matriculas { get; set; }
        public virtual DbSet<ROL> ROL { get; set; }
        public virtual DbSet<Servicio_Comunales> Servicio_Comunales { get; set; }
        public virtual DbSet<USUARIOS> USUARIOS { get; set; }
    }
}
