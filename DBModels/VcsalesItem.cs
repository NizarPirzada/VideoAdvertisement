using System;
using System.Collections.Generic;

#nullable disable

namespace VimeoVSV.Web.DBModels
{
    public partial class VcsalesItem
    {
        public int SalesItemsId { get; set; }
        public int InvoiceNumber { get; set; }
        public int ProductId { get; set; }
        public string ProductType { get; set; }
        public int ProductSubId { get; set; }
        public int Quantity { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
