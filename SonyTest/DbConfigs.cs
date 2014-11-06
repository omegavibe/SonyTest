using SonyTest.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace SonyTest
{
    public class DbOrderConfig : EntityTypeConfiguration<DbOrder>
    {
        public DbOrderConfig()
        {
            this.ToTable("Order");
            this.HasKey(x => x.OrderId);
            this.Property(x => x.CustomerId).IsRequired();
            this.Property(x => x.DistributorId).IsRequired();
            this.Property(x => x.CustomerPO).IsRequired();
            this.Property(x => x.POValue).IsRequired();
            this.Property(x => x.Priority).IsRequired();
            this.Property(x => x.DueDate);
            this.Property(x => x.Description);
        }
    }

    public class DbOrderLocaleConfig : EntityTypeConfiguration<DbOrderLocale>
    {
        public DbOrderLocaleConfig()
        {
            this.ToTable("OrderLocale");
            this.HasKey(x => x.OrderLocaleId);
            this.Property(x => x.OrderId).IsRequired();
            this.Property(x => x.LocaleValue).IsRequired();
            this.Property(x => x.Territory).IsRequired();
            this.Property(x => x.Language).IsRequired();
        }
            
    }

    public class DbCustomerConfig : EntityTypeConfiguration<DbCustomer>
    {
        public DbCustomerConfig()
        {
            this.ToTable("Customer");
            this.HasKey(x => x.CustomerId);
            this.Property(x => x.Name).IsRequired();
        }
    }

    public class DbDistributorConfig : EntityTypeConfiguration<DbDistributor>
    {
        public DbDistributorConfig()
        {
            this.ToTable("Distributor");
            this.HasKey(x => x.DistributorId);
            this.Property(x => x.Name).IsRequired();
        }
    }
}