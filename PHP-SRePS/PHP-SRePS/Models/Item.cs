using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PHP_SRePS.Models
{
    public class Item
    {
        public int ItemId { get; set; }
        [Required]
        public int QuantityOnHand { get; set; }
        [Required]
        public float Price { get; set; }
        [Required]
        public string Name { get; set; }
        public string ItemNotes { get; set; }
    }
}