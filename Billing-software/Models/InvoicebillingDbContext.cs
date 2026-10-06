using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Billing_software.Models;

public partial class InvoicebillingDbContext : DbContext
{
    public InvoicebillingDbContext()
    {
    }

    public InvoicebillingDbContext(DbContextOptions<InvoicebillingDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Tblcustomer> Tblcustomers { get; set; }

    public virtual DbSet<Tblinvoicedetail> Tblinvoicedetails { get; set; }

    public virtual DbSet<Tblinvoicepayment> Tblinvoicepayments { get; set; }

    public virtual DbSet<Tblinvoiceproduct> Tblinvoiceproducts { get; set; }

    public virtual DbSet<Tblproduct> Tblproducts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-3NG6J4A\\SQLEXPRESS;Database=invoicebilling_db;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tblcustomer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__tblcusto__CD65CB85C9755139");

            entity.ToTable("tblcustomer");

            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.City)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("city");
            entity.Property(e => e.CustomerName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("customer_name");
            entity.Property(e => e.MobileNo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("mobile_no");
        });

        modelBuilder.Entity<Tblinvoicedetail>(entity =>
        {
            entity.HasKey(e => e.InvoiceId).HasName("PK__tblinvoi__F58DFD493851C9BE");

            entity.ToTable("tblinvoicedetail");

            entity.Property(e => e.InvoiceId).HasColumnName("invoice_id");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.InvoiceDate).HasColumnName("invoice_date");
            entity.Property(e => e.TotalAmt).HasColumnName("total_amt");

            entity.HasOne(d => d.Customer).WithMany(p => p.Tblinvoicedetails)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fkcid");
        });

        modelBuilder.Entity<Tblinvoicepayment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__tblinvoi__ED1FC9EAC7D2A2FE");

            entity.ToTable("tblinvoicepayment");

            entity.Property(e => e.PaymentId).HasColumnName("payment_id");
            entity.Property(e => e.InvoiceId).HasColumnName("invoice_id");
            entity.Property(e => e.PaymentAmt).HasColumnName("payment_amt");
            entity.Property(e => e.PaymentDate).HasColumnName("payment_date");
            entity.Property(e => e.PaymentDescription)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("payment_description");
            entity.Property(e => e.PaymentMode)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("payment_mode");

            entity.HasOne(d => d.Invoice).WithMany(p => p.Tblinvoicepayments)
                .HasForeignKey(d => d.InvoiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fkiid");
        });

        modelBuilder.Entity<Tblinvoiceproduct>(entity =>
        {
            entity.HasKey(e => e.InvoiceProductid).HasName("PK__tblinvoi__FA9CC5DF97B20768");

            entity.ToTable("tblinvoiceproduct");

            entity.Property(e => e.InvoiceProductid).HasColumnName("invoice_productid");
            entity.Property(e => e.InvoiceId).HasColumnName("invoice_id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.Invoice).WithMany(p => p.Tblinvoiceproducts)
                .HasForeignKey(d => d.InvoiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fkid");

            entity.HasOne(d => d.Product).WithMany(p => p.Tblinvoiceproducts)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fkpid");
        });

        modelBuilder.Entity<Tblproduct>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__tblprodu__47027DF5594FE603");

            entity.ToTable("tblproduct");

            entity.HasIndex(e => e.ProductName, "UQ__tblprodu__2B5A6A5F78B0876F").IsUnique();

            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Gst).HasColumnName("gst");
            entity.Property(e => e.ProductName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("product_name");
            entity.Property(e => e.Rate).HasColumnName("rate");
            entity.Property(e => e.StockQuantity).HasColumnName("stock_quantity");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
