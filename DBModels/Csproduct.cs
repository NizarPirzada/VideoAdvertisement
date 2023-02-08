using System;
using System.Collections.Generic;

#nullable disable

namespace VimeoVSV.Web.DBModels
{
    public partial class Csproduct
    {
        public int ProductId { get; set; }
        public int MasterCatId { get; set; }
        public int SubCatId { get; set; }
        public string Brand { get; set; }
        public string ProductName { get; set; }
        public decimal Cost { get; set; }
        public decimal Consignment { get; set; }
    }
}
