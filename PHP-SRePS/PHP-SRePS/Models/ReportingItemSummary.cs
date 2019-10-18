using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PHP_SRePS.Models
{
    public class ReportingItemSummary
    {
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public float TotalPrice { get; set; }
    }
}