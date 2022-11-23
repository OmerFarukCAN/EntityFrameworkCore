using System;
using System.Collections.Generic;
using DatabaseFirst.Entities;
using Microsoft.EntityFrameworkCore;

namespace DatabaseFirst.Contexts;

public partial class EcommerceDemoContext : DbContext
{
    public EcommerceDemoContext()
    {
    }

    public EcommerceDemoContext(DbContextOptions<EcommerceDemoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=ECommerceDemo;User Id=ofarukcan;Password=prostreet273;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
