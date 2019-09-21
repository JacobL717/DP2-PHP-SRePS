using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PHP_SRePS.Models
{
    public class SalesTransaction
    {
        public int Id { get; set; }

        // foreign key
        public Item Item { get; set; }

        [Display(Name = "Item")]
        public string ItemId { get; set; }

        [Required]
        [Range(1,15)]
        public int Quantity { get; set; }

        [Required]
        [Display(Name = "Total Price")]
        public float TotalPrice { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public string Notes { get; set; }
    }
}