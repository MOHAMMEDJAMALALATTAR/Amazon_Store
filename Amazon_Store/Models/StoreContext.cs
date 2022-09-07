using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Amazon_Store.Models
{
    public partial class StoreContext : DbContext
    {
        public StoreContext()
        {
        }

        public StoreContext(DbContextOptions<StoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Subcategory> Subcategories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                 optionsBuilder.UseSqlServer("Server=LAPTOP-CFF4TN8K\\SQLEXPRESS;Database=Store;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.ToTable("Item");

                entity.Property(e => e.NameItem)
                    .HasMaxLength(10)
                    .HasColumnName("Name_Item")
                    .IsFixedLength(true);

                entity.Property(e => e.SubcategoryId).HasColumnName("Subcategory_Id");

                entity.HasOne(d => d.Subcategory)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.SubcategoryId)
                    .HasConstraintName("FK_Item_Subcategory");
            });

            modelBuilder.Entity<Subcategory>(entity =>
            {
                entity.ToTable("Subcategory");

                entity.Property(e => e.CategoryId).HasColumnName("Category_Id");

                entity.Property(e => e.NameSubcategory)
                    .HasMaxLength(10)
                    .HasColumnName("Name_Subcategory")
                    .IsFixedLength(true);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Subcategories)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Subcategory_Category");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
