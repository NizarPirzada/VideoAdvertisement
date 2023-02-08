using System;
using System.Collections.Generic;

#nullable disable

namespace VimeoVSV.Web.DBModels
{
    public partial class Csrollup
    {
        public int RollUpId { get; set; }
        public int MarketId { get; set; }
        public int LocationsId { get; set; }
        public int ProductId { get; set; }
        public string Dmya { get; set; }
        public DateTime? Rudate { get; set; }
        public int? Rumonth { get; set; }
        public string Ruyear { get; set; }
        public int? MasterCatId { get; set; }
        public int SubCatId { get; set; }
        public decimal? StockValue { get; set; }
        public decimal? Gross { get; set; }
        public decimal? Net { get; set; }
        public int? NumAdd { get; set; }
        public int? NumSold { get; set; }
    }
}
