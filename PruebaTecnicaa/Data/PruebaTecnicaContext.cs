using Microsoft.EntityFrameworkCore;
using PruebaTecnicaa.Models.PruebaTecnica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PruebaTecnicaa.Data
{
    public partial class PruebaTecnicaContext : DbContext
    {
        public PruebaTecnicaContext()
        {
        }

        public PruebaTecnicaContext(DbContextOptions<PruebaTecnicaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Perfil> Perfil { get; set; }
        public virtual DbSet<Pagina> Pagina { get; set; }
        public virtual DbSet<RadicadoExterno> RadicadoExterno { get; set; }
        public virtual DbSet<RadicadoExternoDet> RadicadoExternoDet { get; set; }
        public virtual DbSet<RadicadoInterno> RadicadoInterno { get; set; }
        public virtual DbSet<RadicadoInternoDet> RadicadoInternoDet { get; set; }
        public virtual DbSet<Estado> Estado { get; set; }
        public virtual DbSet<Auditoria> Auditoria { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //{
            //    #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            //    optionsBuilder.UseSqlServer("Data Source=10.231.50.69; Initial Catalog=BancaEmpresaAdmin; Integrated Security=False; User Id=Kmendoza;Password=kmendoza2018; MultipleActiveResultSets=True;");
            //}
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("Usuario", "dbo");
            });

            modelBuilder.Entity<Perfil>(entity =>
            {
                entity.ToTable("Perfil", "dbo");
            });
            
            modelBuilder.Entity<Pagina>(entity =>
            {
                entity.ToTable("Pagina", "dbo");
            });

            modelBuilder.Entity<RadicadoExterno>(entity =>
            {
                entity.ToTable("RadicadoExterno", "dbo");
            });

            modelBuilder.Entity<RadicadoInterno>(entity =>
            {
                entity.ToTable("RadicadoInterno", "dbo");
            });

            modelBuilder.Entity<RadicadoExternoDet>(entity =>
            {
                entity.ToTable("RadicadoExternoDet", "dbo");
            });

            modelBuilder.Entity<RadicadoInternoDet>(entity =>
            {
                entity.ToTable("RadicadoInternoDet", "dbo");
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.ToTable("Estado", "dbo");
            });
            
            modelBuilder.Entity<Auditoria>(entity =>
            {
                entity.ToTable("Auditoria", "dbo");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
