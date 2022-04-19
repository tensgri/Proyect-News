using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using newAdmin.Models;

#nullable disable

namespace newAdmin.Data
{
    public partial class noticiaContext : DbContext
    {
        public noticiaContext()
        {
        }

        public noticiaContext(DbContextOptions<noticiaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categorium> Categoria { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<Pai> Pais { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-GKPGELH; Database=noticia;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Categorium>(entity =>
            {
                entity.HasKey(e => e.Idcategoria)
                    .HasName("PK_IDCategoria");

                entity.Property(e => e.Idcategoria).HasColumnName("IDCategoria");

                entity.Property(e => e.NombreCategoria)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<News>(entity =>
            {
                entity.HasKey(e => e.IdNews)
                    .HasName("PK_IdNews");

                entity.ToTable("news");

                entity.Property(e => e.IdNews).HasColumnName("Id_news");

                entity.Property(e => e.Autor)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("autor");

                entity.Property(e => e.Categoria).HasColumnName("categoria");

                entity.Property(e => e.Codepais)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("codepais");

                entity.Property(e => e.Descripcion).IsUnicode(false);

                entity.Property(e => e.FechaCreacion).HasColumnType("date");

                entity.Property(e => e.FechaModificacion).HasColumnType("date");

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasColumnName("titulo");

                entity.Property(e => e.UrlImage).IsUnicode(false);

                entity.Property(e => e.UrlNews).IsUnicode(false);

                entity.Property(e => e.Visible)
                    .HasColumnName("visible")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.CategoriaNavigation)
                    .WithMany(p => p.News)
                    .HasForeignKey(d => d.Categoria)
                    .HasConstraintName("FK_categoria");

                entity.HasOne(d => d.CodepaisNavigation)
                    .WithMany(p => p.News)
                    .HasForeignKey(d => d.Codepais)
                    .HasConstraintName("FK_pais_codepais");
            });

            modelBuilder.Entity<Pai>(entity =>
            {
                entity.HasKey(e => e.CodePais)
                    .HasName("PK_IDPais");

                entity.Property(e => e.CodePais)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Idusuario);

                entity.ToTable("usuario");

                entity.Property(e => e.Nameusuario)
                    .IsUnicode(false)
                    .HasColumnName("nameusuario");

                entity.Property(e => e.PasswordUsuario)
                    .IsUnicode(false)
                    .HasColumnName("password_usuario");

                entity.Property(e => e.Rol)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("rol");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
