using System;
using System.Collections.Generic;

#nullable disable

namespace VimeoVSV.Web.DBModels
{
    public partial class Csinventory
    {
        public int InventoryId { get; set; }
        public int MarketId { get; set; }
        public int MasterCatId { get; set; }
        public string Brand { get; set; }
        public string ProductName { get; set; }
        public int InventoryCount { get; set; }
        public int ProductId { get; set; }
    }
}
