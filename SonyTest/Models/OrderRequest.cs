using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SonyTest.Models
{
    public class OrderRequest
    {
        public int CustomerId { get; set; }
        public int DistributorId { get; set; }
        public string CustomerPO { get; set; }
        public decimal POValue { get; set; }
        public byte Priority { get; set; }
        public List<OrderLocale> Locales { get; set; }
        public DateTime? DueDate { get; set; }
        public string Description { get; set; }
    }

    public class OrderLocale
    {
        public string LocaleValue { get; set; }
        public string Territory { get; set; }
        public string Language { get; set; }
        public bool IsPrimary { get; set; }
    }
}