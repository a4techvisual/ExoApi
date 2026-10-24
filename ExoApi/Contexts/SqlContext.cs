using ExoApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ExoApi.Contexts
{
    // Contexto do Entity Framework: faz a ponte entre as classes e o SQL Server
    public class SqlContext : DbContext
    {
        public SqlContext(DbContextOptions<SqlContext> options) : base(options) { }

        public DbSet<Projeto> Projetos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Projeto>(entity =>
            {
                entity.ToTable("Projetos");
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Titulo).IsRequired().HasMaxLength(250).IsUnicode(false);
                entity.Property(p => p.StatusProjeto).HasMaxLength(100).IsUnicode(false);
                entity.Property(p => p.DataInicio).HasColumnType("date");
                entity.Property(p => p.Tecnologias).HasMaxLength(250).IsUnicode(false);
                entity.Property(p => p.Requisitos).HasMaxLength(250).IsUnicode(false);
                entity.Property(p => p.Area).HasMaxLength(150).IsUnicode(false);
            });
        }
    }
}
