using System;
using System.Collections.Generic;

#nullable disable

namespace VimeoVSV.Web.DBModels
{
    public partial class Csreconcile
    {
        public int ReconcileId { get; set; }
        public int LocationsId { get; set; }
        public int RecPeriod { get; set; }
        public DateTime RecDate { get; set; }
        public string AddDeductOnly { get; set; }
        public int ProductId { get; set; }
        public int WalkInCount { get; set; }
        public int NumSold { get; set; }
        public int NumAdd { get; set; }
        public int NumDeduct { get; set; }
        public int WalkOutCount { get; set; }
    }
}
