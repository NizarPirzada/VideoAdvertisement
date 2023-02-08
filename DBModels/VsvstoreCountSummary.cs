using System;
using System.Collections.Generic;

#nullable disable

namespace VimeoVSV.Web.DBModels
{
    public partial class VsvstoreCountSummary
    {
        public int StoreCountSummaryId { get; set; }
        public int ManId { get; set; }
        public int VidId { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int StoreCount { get; set; }
        public DateTime? DateSummary { get; set; }
    }
}
