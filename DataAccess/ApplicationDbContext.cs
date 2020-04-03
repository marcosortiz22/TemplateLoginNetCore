using Entities;
using IDataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<RolApp> RolApps { get; set; }
        public DbSet<RolAppUser> RolAppsUser { get; set; }

        protected void OnConfiguring(string ConnectionString, DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString, providerOptions => providerOptions.CommandTimeout(60))
                          .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).UseIdentityColumn(1, 1).IsRequired();
                entity.Property(e => e.CodeUser).IsRequired();

            });

            modelBuilder.Entity<RolApp>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).UseIdentityColumn(1, 1).IsRequired();

            });

            modelBuilder.Entity<RolAppUser>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).UseIdentityColumn(1, 1).IsRequired();
                entity.HasOne(e => e.User).WithMany(e => e.RolAppUser).HasForeignKey(e => e.IdUser);
                entity.HasOne(e => e.RolApp).WithMany(e => e.RolAppUser).HasForeignKey(e => e.IdRolApp);

            });

        }

    }
}
