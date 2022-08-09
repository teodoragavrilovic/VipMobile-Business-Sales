using Microsoft.EntityFrameworkCore;
using Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class VipContext: DbContext
    {
        public DbSet<TariffPackage> TariffPackages { get; set; }
        public DbSet<PackageType> PackageTypes { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<THServiceRequest> THServiceRequests { get; set; }
        public DbSet<THOffer> THOffers { get; set; }
        public DbSet<OfferItem> OfferItems { get; set; }
        public DbSet<THService> THServices { get; set; }
        public DbSet<ServiceType> ServiceTypes { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=VipBusinessSales;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            //complex primary key
           modelBuilder.Entity<OfferItem>().HasKey(e => new { e.OfferItemId, e.THOfferId });

            //weak object
            // modelBuilder.Entity<THOffer>().OwnsMany(e => e.OfferItems).WithOwner(i => i.THOffer);

            /*    modelBuilder.Entity<THOffer>().OwnsMany(
                e => e.OfferItems, a =>
             {
                  a.WithOwner().HasForeignKey("THServiceId");
                  a.Property<int>("OfferItemId");
                  a.HasKey("OfferItemId");
             });
            */

            //foreign key
            modelBuilder.Entity<THServiceRequest>().HasOne(e => e.Client).WithMany().HasForeignKey(e => e.ClientId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<THServiceRequest>().HasOne(e => e.Employee).WithMany().HasForeignKey(e => e.EmployeeId).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<THOffer>().HasOne(e => e.THServiceRequest).WithMany().HasForeignKey(e => e.THServiceRequestId).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<THService>().HasOne(e => e.ServiceType).WithMany().HasForeignKey(e => e.ServiceTypeId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<OfferItem>().HasOne(e => e.THService).WithMany().HasForeignKey(e => e.THServiceId).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<TariffPackage>().HasOne(e => e.PackageType).WithMany().HasForeignKey(e => e.PackageTypeId).OnDelete(DeleteBehavior.NoAction);



        }

    }
}
