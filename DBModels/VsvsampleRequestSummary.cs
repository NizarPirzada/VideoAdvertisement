using System;
using System.Collections.Generic;

#nullable disable

namespace VimeoVSV.Web.DBModels
{
    public partial class VsvsampleRequestSummary
    {
        public int SampleRequestSummaryId { get; set; }
        public int ManId { get; set; }
        public int VidId { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int SampleRequestCount { get; set; }
        public DateTime? DateSummary { get; set; }
    }
}
