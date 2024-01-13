using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using System.Text.RegularExpressions;

namespace WebApplicationCSharp.Models 
{
    public class ProductContext: DbContext
    {
        public DbSet<ProguctStorage>? Proguct_Storages { get; set; }
        public DbSet<Product>? Products { get; set; }
        public DbSet<ProductGroup>? ProductGroups { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=helloappdb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Products");

                entity.HasKey(x => x.ID).HasName("ProductID");
                entity.HasIndex(x => x.Name).IsUnique();

                entity.Property(e => e.Name)
                .HasColumnName("ProductName")
                .HasMaxLength(255)
                .IsRequired();

                entity.Property(e => e.Description)
                .HasColumnName("Description")
                .HasMaxLength(255)
                .IsRequired();

                entity.Property(e => e.Price)
                .HasColumnName("Price")
                .IsRequired();

                entity.HasOne(x => x.Group)
                .WithMany(c => c.Products).HasForeignKey(x => x.ID)
                .HasConstraintName("GroupToProduct");
            });

            modelBuilder.Entity<ProductGroup>(entity =>
            {
                entity.ToTable("ProductGroups");

                entity.HasKey(x => x.ID).HasName("GroupID");
                entity.HasIndex(x => x.Name).IsUnique();

                entity.Property(e => e.Name)
                .HasColumnName("ProductName")
                .HasMaxLength(255)
                .IsRequired();
            });
            modelBuilder.Entity<Storage>(entity =>
            {

                entity.ToTable("Storage");

                entity.HasKey(x => x.ID).HasName("StoreID");


                entity.Property(e => e.Name)
                .HasColumnName("StorageName");

                entity.Property(e => e.Count)
                .HasColumnName("ProductCount");

                //entity.HasMany(x => x.Products)
                //.WithMany(m => m.Storage)
                //.UsingEntity(j => j.ToTable("StorageProduct"));
            });
        }
    }
}
