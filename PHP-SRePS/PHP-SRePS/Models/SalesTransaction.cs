using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PHP_SRePS.Models
{
    public class SalesTransaction
    {
        public int Id { get; set; }

        // foreign key
        public string ItemId { get; set; }
        public Item Item { get; set; }

        public int Quantitiy { get; set; }
        public float TotalPrice { get; set; }
        public DateTime Date { get; set; }
        public string Notes { get; set; }
    }
}