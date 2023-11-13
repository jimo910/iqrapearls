using Microsoft.EntityFrameworkCore;
using  IqraPearls.Model;
using IqraPearls.Dtos;

namespace IqraPearls.DataDbContext{ 

public class IqraDbContext : DbContext
{
    public DbSet<Customers> Customerss { get; set; }
    public DbSet<Sellers> Sellerss { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductImage> ProductImages { get; set; }
    public DbSet<Review> Reviews{get; set;}
    public DbSet<Preview> PReviews{get; set;}
    public DbSet<Comment> Comments{get; set;}
    public DbSet<Cart> Carts{get; set;}
    public DbSet<Wishlist> Wishlists{get; set;}
    public DbSet<Order> Orders{get; set;}


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Set up MySQL database connection here.
        string connectionString = "server=localhost;database=iqrapearls;user=root;password=root;";
        optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

    }

     protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
            modelBuilder.Entity<Product>()
                 .HasMany(p => p.ImageUrlList)
                 .WithOne(pi => pi.Product)
                 .HasForeignKey(pi => pi.ProductId);
                 
                 modelBuilder.Entity<CartDto>().HasNoKey();
                 modelBuilder.Entity<OrderDto>().HasNoKey();
                 modelBuilder.Entity<Sellers>().Ignore(e => e.ReturnRequest);
                 modelBuilder.Entity<Sellers>().Ignore(e => e.productCarted);
                 modelBuilder.Entity<Customers>().Ignore(e => e.ListofProductOrdered);
                 modelBuilder.Entity<Customers>().Ignore(e => e.ListofProductToReturned);
    }

   

    


}

}
