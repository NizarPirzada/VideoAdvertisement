using System;
using System.Collections.Generic;

#nullable disable

namespace VimeoVSV.Web.DBModels
{
    public partial class VctempOrder
    {
        public int Entryid { get; set; }
        public int? CustomerId { get; set; }
        public DateTime? Orderdate { get; set; }
        public decimal? Subtotal { get; set; }
        public decimal? Shiptotal { get; set; }
        public decimal? Taxtotal { get; set; }
        public decimal? Invtotal { get; set; }
        public decimal? Discounttotal { get; set; }
        public DateTime? Ordercompleteddate { get; set; }
        public string Remarks { get; set; }
        public int? Status { get; set; }
    }
}
