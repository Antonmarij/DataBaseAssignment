using assignment_db.Models;
using Microsoft.EntityFrameworkCore;

namespace assignment_db.Contexts;

public class DataContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\DB_Assignment\assignment_db\assignment_db\Contexts\database_G.mdf;Integrated Security=True;Connect Timeout=30");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OrderRowEntity>()
            .HasKey(orderRow => new { orderRow.OrderId, orderRow.ProductId });

        modelBuilder.Entity<OrderRowEntity>()
            .HasOne(orderRow => orderRow.Order)
            .WithMany(order => order.OrderRows)
            .HasForeignKey(orderRow => orderRow.OrderId);

    }

    public DbSet<AddressEntity> Addresses { get; set; }
    public DbSet<CustomerEntity> Customers { get; set; }
    public DbSet<OrderEntity> Orders { get; set; }
    public DbSet<OrderRowEntity> OrderRows { get; set; }
    public DbSet<ProductEntity> Products { get; set; }

}
