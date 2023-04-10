using Luxelane.Models;
using Luxelane.Models.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Luxelane.Db
{
    public class DataContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        static DataContext()
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        public override int SaveChanges()
        {
            var entities = ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Modified && e.Entity is BaseModel);

            foreach (var entity in entities)
            {
                entity.Property("updatedAt").CurrentValue = DateTime.UtcNow;
            }

            return base.SaveChanges();
        }
        private readonly IConfiguration _config;
        public DataContext(DbContextOptions options, IConfiguration config) : base(options) => _config = config;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connString = _config.GetConnectionString("DefaultConnection");
            optionsBuilder
                .UseNpgsql(connString)
                .AddInterceptors(new DataContextSaveChangesInterceptor())
                .UseSnakeCaseNamingConvention();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var OrderStatusConverter = new EnumToStringConverter<OrderStatus>();
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Email).IsUnique();
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
                entity.HasMany(u => u.Addresses).WithOne(a => a.User).HasForeignKey(a => a.UserId).OnDelete(DeleteBehavior.Cascade);
                entity.HasMany(u => u.Orders).WithOne(o => o.User).HasForeignKey(o => o.UserId).OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(o => o.OrderStatus).HasConversion(OrderStatusConverter);
                entity.HasMany(o => o.OrderProducts).WithOne(op => op.Order).HasForeignKey(op => op.OrderId).OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<OrderProduct>(entity =>
            {
                entity.HasKey(op => op.Id);
                entity.HasAlternateKey(op => new { op.OrderId, op.ProductId });
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasMany(p => p.OrderProducts).WithOne(op => op.Product).HasForeignKey(op => op.ProductId).OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Category>()
                .HasMany(c => c.Product)
                .WithOne(pc => pc.Category)
                .HasForeignKey(pc => pc.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>().Navigation(item => item.Orders).AutoInclude();
            modelBuilder.Entity<User>().Navigation(item => item.Addresses).AutoInclude();
            modelBuilder.Entity<Order>().Navigation(item => item.OrderProducts).AutoInclude();
            modelBuilder.Entity<Category>().Navigation(item => item.Product).AutoInclude();

            modelBuilder.AddIdentityConfig();
        }

        public DbSet<Address> Addresses { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<OrderProduct> OrderProducts { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;

    }
}