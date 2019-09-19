using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PHP_SRePS.Models
{
    public class Item
    {
        public string ItemId { get; set; }
        public int QuantityOnHand { get; set; }
        public float Price { get; set; }
        public string Name { get; set; }
        public string ItemNotes { get; set; }
    }
}