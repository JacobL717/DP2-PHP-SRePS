using PHP_SRePS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PHP_SRePS.ViewModels
{
    public class ReportingSummaryViewModel
    {
        public IEnumerable<ReportingItemSummary> ItemSummaries { get; set; }
        public IEnumerable<Item> Items { get; set; }
        public int Month { get; set; }
        public CustomReporting SearchCriteria { get; set; }
    }
}