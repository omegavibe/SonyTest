using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SonyTest.Models
{
    public class DbOrder
    {
        public Guid OrderId { get; set; }
        public int CustomerId { get; set; }
        public int DistributorId { get; set; }
        public string CustomerPO { get; set; }
        public decimal POValue { get; set; }
        public byte Priority { get; set; }
        public DateTime? DueDate { get; set; }
        public string Description { get; set; }
    }

    public class DbOrderLocale
    {
        public Guid OrderLocaleId { get; set; }
        public Guid OrderId { get; set; }
        public string LocaleValue { get; set; }
        public string Territory { get; set; }
        public string Language { get; set; }
        public bool IsPrimary { get; set; }
    }

    public class DbCustomer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
    }

    public class DbDistributor
    {
        public int DistributorId { get; set; }
        public string Name { get; set; }
    }
}