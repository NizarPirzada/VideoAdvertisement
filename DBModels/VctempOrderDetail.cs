using System;
using System.Collections.Generic;

#nullable disable

namespace VimeoVSV.Web.DBModels
{
    public partial class VctempOrderDetail
    {
        public int Entryid { get; set; }
        public int? TempOid { get; set; }
        public int? ProductId { get; set; }
        public string ProductType { get; set; }
        public int? ProductSubId { get; set; }
        public int? Quantity { get; set; }
        public decimal? Discount { get; set; }
        public decimal? ProductPrice { get; set; }
        public DateTime? Dateadded { get; set; }
        public decimal? Tax { get; set; }
    }
}
