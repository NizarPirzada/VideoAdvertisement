using System;
using System.Collections.Generic;

#nullable disable

namespace VimeoVSV.Web.DBModels
{
    public partial class CsactiveProduct
    {
        public int ActiveProductsId { get; set; }
        public int LocationsId { get; set; }
        public int MasterCatId { get; set; }
        public int SubCatId { get; set; }
        public string Brand { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
    }
}
