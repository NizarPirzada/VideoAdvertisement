using System;
using System.Collections.Generic;

#nullable disable

namespace VimeoVSV.Web.DBModels
{
    public partial class Vcjuice
    {
        public int ProductId { get; set; }
        public int? SubId { get; set; }
        public int Size { get; set; }
        public int Nic { get; set; }
        public int StockCount { get; set; }
        public decimal? Price { get; set; }
    }
}
