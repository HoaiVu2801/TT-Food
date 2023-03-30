using Microsoft.EntityFrameworkCore;
using System.Data;

namespace OrderFood.Data
{
    public class API_OrderFood_Entities : DbContext
    {
        public API_OrderFood_Entities(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<FoodByRestaurant>? FoodByRestaurants { get; set; }
        public DbSet<FoodForUser>? FoodForUsers { get; set; }
        public DbSet<Log>? Logs { get; set; }
        public DbSet<Order>? Orders { get; set; }
        public DbSet<OrderDetail>? OrderDetails { get; set; }
        public DbSet<Unit>? Units { get; set; }
        public DbSet<Role>? Roles { get; set; }

        public DbSet<RefreshToken>? RefreshTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>(e =>
            {
                e.ToTable("Users");
                e.HasIndex(x => x.UserName).IsUnique();
                e.HasIndex(x => x.Email).IsUnique();
                e.HasIndex(x => x.PhoneNumber).IsUnique();
                e.HasMany(e => e.Orders)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.UserID)
                .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Order>(e =>
            {
                e.ToTable("Order");
                e.HasMany(e => e.OrderDetails)
                .WithOne(e => e.Order)
                .HasForeignKey(e => e.OrderID);
            });

            modelBuilder.Entity<OrderDetail>(e =>
            {
                e.ToTable("OrderDetail");
            });

            modelBuilder.Entity<FoodForUser>(e =>
            {
                e.ToTable("FoodForUser");
                e.HasMany(e => e.OrderDetails)
                .WithOne(e => e.FoodForUser)
                .HasForeignKey(e => e.FoodID);
            });

            modelBuilder.Entity<FoodByRestaurant>(e =>
            {
                e.ToTable("FoodByRestaurant");
            });

            modelBuilder.Entity<Role>(e =>
            {
                e.ToTable("Role");
                e.HasMany(e => e.Users)
                .WithOne(e => e.Role)
                .HasForeignKey(e => e.RoleID);
            });

            modelBuilder.Entity<RefreshToken>(e =>
            {
                e.ToTable("RefreshToken");
            });

            modelBuilder.Entity<Log>(e =>
            {
                e.ToTable("Log");
            });

            modelBuilder.Entity<Unit>(e =>
            {
                e.ToTable("Unit");
                e.HasMany(e => e.FoodByRestaurants)
                .WithOne(e => e.Unit)
                .HasForeignKey(e => e.UnitID);

                e.HasMany(e => e.FoodForUsers)
                .WithOne(e => e.Unit)
                .HasForeignKey(e => e.UnitID);

                e.HasMany(e => e.FoodForUsers)
                .WithOne(e => e.Unit)
                .HasForeignKey(e => e.RestaurantID);

                e.HasMany(e => e.Orders)
                .WithOne(e => e.Unit)
                .HasForeignKey(e => e.UnitID)
                .OnDelete(DeleteBehavior.NoAction);

                e.HasMany(e => e.Users)
                .WithOne(e => e.Unit)
                .HasForeignKey(e => e.UnitID);
            });
        }
    }
}
