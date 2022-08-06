using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Recipes.Models
{
    public partial class RecipesContext : DbContext
    {
        public RecipesContext()
        {
        }

        public RecipesContext(DbContextOptions<RecipesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Ingredient> Ingredients { get; set; }
        public virtual DbSet<MjerneJedinice> MjerneJedinices { get; set; }
        public virtual DbSet<Namirnice> Namirnices { get; set; }
        public virtual DbSet<Recipe> Recipes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-QKLMKI4;Initial Catalog=Recipes;Trusted_Connection=True;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(400)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Ingredient>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FkNaziv).HasColumnName("fk_naziv");

                entity.Property(e => e.Kolicina)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("kolicina");

                entity.HasOne(d => d.FkNazivNavigation)
                    .WithMany(p => p.Ingredients)
                    .HasForeignKey(d => d.FkNaziv)
                    .HasConstraintName("FK__Ingredien__fk_na__36B12243");

                entity.HasOne(d => d.Recipes)
                    .WithMany(p => p.Ingredients)
                    .HasForeignKey(d => d.RecipesId)
                    .HasConstraintName("FK__Ingredien__Recip__30F848ED");
            });

            modelBuilder.Entity<MjerneJedinice>(entity =>
            {
                entity.ToTable("MjerneJedinice");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Jedinica)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("JEDINICA");

                entity.Property(e => e.JedinicaLong)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("JEDINICA_LONG");
            });

            modelBuilder.Entity<Namirnice>(entity =>
            {
                entity.ToTable("Namirnice");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.MjernaJedinica).HasColumnName("mjernaJedinica");

                entity.Property(e => e.Naziv)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NAZIV");

                entity.HasOne(d => d.MjernaJedinicaNavigation)
                    .WithMany(p => p.Namirnices)
                    .HasForeignKey(d => d.MjernaJedinica)
                    .HasConstraintName("FK__Namirnice__mjern__35BCFE0A");
            });

            modelBuilder.Entity<Recipe>(entity =>
            {
                entity.HasKey(e => e.RecipesId)
                    .HasName("PK__Recipes__085F53BB08D1C2E0");

                entity.Property(e => e.RecipesId).HasColumnName("RecipesID");

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(400)
                    .IsUnicode(false)
                    .HasColumnName("imageUrl");

                entity.Property(e => e.KategorijaId).HasColumnName("kategorijaID");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("price");

                entity.Property(e => e.Title)
                    .HasMaxLength(400)
                    .IsUnicode(false)
                    .HasColumnName("title");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
