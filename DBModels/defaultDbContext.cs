using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace demoApp.DBModels
{
    public partial class defaultDbContext : DbContext
    {
        public defaultDbContext()
        {
        }

        public defaultDbContext(DbContextOptions<defaultDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Demo3> Demo3s { get; set; }
        public virtual DbSet<DemoCustomer> DemoCustomers { get; set; }
        public virtual DbSet<DemoTbl> DemoTbls { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\FAZALSQL;Database=defaultDb;Trusted_Connection=True;MultipleActiveResultSets=true");
               // optionsBuilder.UseSqlServer("Server=204.27.61.178;Database=Pubs;User ID=sa;Password=915rzg6805;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Customer");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(10)
                    .HasColumnName("name")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Demo3>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("demo_3");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Name)
                    .HasMaxLength(10)
                    .HasColumnName("name")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<DemoCustomer>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("demo_customer");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(10)
                    .HasColumnName("name")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<DemoTbl>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("demo_tbl");

                entity.HasIndex(e => e.Id, "idx_lastname");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Name)
                    .HasMaxLength(10)
                    .HasColumnName("name")
                    .IsFixedLength(true);

                entity.Property(e => e.Password)
                    .HasMaxLength(10)
                    .HasColumnName("password")
                    .IsFixedLength(true);

                entity.Property(e => e.Salary)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("salary");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
