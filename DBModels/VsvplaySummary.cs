using System;
using System.Collections.Generic;

#nullable disable

namespace VimeoVSV.Web.DBModels
{
    public partial class VsvplaySummary
    {
        public int PlaySummaryId { get; set; }
        public int ManId { get; set; }
        public int VidId { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int PlayCount { get; set; }
        public DateTime? DateSummary { get; set; }
    }
}
