using System;
using System.Collections.Generic;

#nullable disable

namespace VimeoVSV.Web.DBModels
{
    public partial class Vcproduct
    {
        public int ProductId { get; set; }
        public string ProductType { get; set; }
        public string ProductName { get; set; }
        public int? StockCount { get; set; }
        public string ProductDescrip { get; set; }
        public decimal? Price { get; set; }
    }
}
