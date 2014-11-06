using SonyTest.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SonyTest
{
    public class DbRepository : DbContext
    {
        public DbRepository(string connectionString) : base(connectionString) { }

        static DbRepository() { }

        public Guid SaveOrder(OrderRequest request)
        {
            var newOrder = this.Orders.Add(new DbOrder
                {
                    OrderId = Guid.NewGuid(),
                    CustomerId = request.CustomerId,
                    DistributorId = request.DistributorId,
                    CustomerPO = request.CustomerPO,
                    POValue = request.POValue,
                    DueDate = request.DueDate,
                    Description = request.Description
                });

            foreach(var locale in request.Locales)
            {
                this.OrderLocales.Add(new DbOrderLocale
                {
                    OrderLocaleId = Guid.NewGuid(),
                    OrderId = newOrder.OrderId,
                    LocaleValue = locale.LocaleValue,
                    Territory = locale.Territory,
                    Language = locale.Language,
                    IsPrimary = locale.IsPrimary,
                });
            }

            this.SaveChanges();

            return newOrder.OrderId;
        }

        public DbSet<DbOrder> Orders { get; set; }
        public DbSet<DbOrderLocale> OrderLocales { get; set; }
        public DbSet<DbCustomer> Customers { get; set; }
        public DbSet<DbDistributor> Distributors { get; set; } 

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new DbOrderConfig());
            modelBuilder.Configurations.Add(new DbOrderLocaleConfig());
            modelBuilder.Configurations.Add(new DbCustomerConfig());
            modelBuilder.Configurations.Add(new DbDistributorConfig());
        }
    }
}