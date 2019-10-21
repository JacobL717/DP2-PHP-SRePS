using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PHP_SRePS.Models
{
    public class PredictionItemSummary
    {
        public int ItemId { get; set; }
        public double Average { get; set; }
        public float ExpectedSales { get; set; }
    }
}