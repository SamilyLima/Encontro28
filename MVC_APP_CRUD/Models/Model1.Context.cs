//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVC_APP_CRUD.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class fluxo_caixaEntities : DbContext
    {
        public fluxo_caixaEntities()
            : base("name=fluxo_caixaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<cliente> clientes { get; set; }
        public virtual DbSet<despesa> despesas { get; set; }
        public virtual DbSet<fluxodecaixa> fluxodecaixas { get; set; }
        public virtual DbSet<fornecedor> fornecedors { get; set; }
        public virtual DbSet<produto> produtoes { get; set; }
        public virtual DbSet<tipodelancamento> tipodelancamentoes { get; set; }
    }
}
