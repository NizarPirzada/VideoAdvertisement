using System;
using System.Collections.Generic;

#nullable disable

namespace VimeoVSV.Web.DBModels
{
    public partial class VsvpromoRequestSummary
    {
        public int PromoRequestSummaryId { get; set; }
        public int ManId { get; set; }
        public int BrandId { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int PromoRequestCount { get; set; }
        public DateTime? DateSummary { get; set; }
    }
}
