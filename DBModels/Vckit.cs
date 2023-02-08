using System;
using System.Collections.Generic;

#nullable disable

namespace VimeoVSV.Web.DBModels
{
    public partial class Vckit
    {
        public int ProductId { get; set; }
        public int? SubId { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }
        public int StockCount { get; set; }
    }
}
