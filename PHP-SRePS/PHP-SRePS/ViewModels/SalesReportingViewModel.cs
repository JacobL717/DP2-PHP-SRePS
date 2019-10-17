using PHP_SRePS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PHP_SRePS.ViewModels
{
    public class SalesReportingViewModel<T>
    {
        public IEnumerable<T> GroupedSalesHistory { get; set; }
        public IEnumerable<Item> Items { get; set; }
    }
}