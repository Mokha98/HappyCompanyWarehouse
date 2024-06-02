using DAL.Entity;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data
{
    public class DataContext :DbContext
    {

        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<WarehouseItem> WarehouseItems { get; set; }
        public DbSet<RoleType> RoleType { get; set; }

        public DbSet<AppUser> AppUsers { get; set; }
      
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Warehouse>()
                .HasIndex(w => w.WarehouseName)
                .IsUnique();

            modelBuilder.Entity<WarehouseItem>()
                .HasIndex(wi => wi.ItemName)
                .IsUnique();

            modelBuilder.Entity<AppUser>()
              .HasIndex(wi => wi.Email)
              .IsUnique();

            modelBuilder.Entity<RoleType>().HasData(
                 Helper.DataHelper.GetRoleTypes()
                );

            modelBuilder.Entity<Country>().HasData(
               Helper.DataHelper.GetCountries()
              );

            modelBuilder.Entity<AppUser>().HasData(
                  Helper.DataHelper.GetDefaultUser()
                 
               );
        }

    }
}
