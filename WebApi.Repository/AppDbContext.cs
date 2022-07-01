using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;
using WebApi.Core.Entities;

namespace WebApi.Repository
{
    public class AppDbContext:DbContext
    {

        public DbSet<UserAuthentication> UserAuthentications { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<PictureGroup> PictureGroups { get; set; }
        public DbSet<MaintenanceHistory> MaintenanceHistories { get; set; }
        public DbSet<Maintenance> Maintenances { get; set; }
        public DbSet<ActionType> ActionTypes { get; set; }
        

        public AppDbContext(DbContextOptions<AppDbContext> options):base(options){}

        public AppDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


            modelBuilder.Entity<UserAuthentication>().HasData(
                new UserAuthentication()
                {
                    ID = 1,
                    UserName = "admin",
                    Password = "123456",
                    UserID = 1,
                    UserRole = "admin"
                }
                );
            modelBuilder.Entity<User>().HasData(
                new User()
                {
                    ID = 1,
                    FirstName = "admin",
                    LastName = "admin",
                    CreatedBy = 1,
                    CreateDate = DateTime.Now,
                    ModifiedBy = 1,
                    ModifyDate = DateTime.Now,
                    PhoneNumber = "0",

                });

            




            base.OnModelCreating(modelBuilder);
        }
    }
}
