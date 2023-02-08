using System;
using System.Collections.Generic;

#nullable disable

namespace VimeoVSV.Web.DBModels
{
    public partial class Invoice
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? LocationsId { get; set; }
        public string AddDeductOnly { get; set; }
        public string InvoiceNumber { get; set; }
        public string InvoiceFilePath { get; set; }
        public string ReportFilePath { get; set; }
        public string BillToName { get; set; }
        public string BillToAddress { get; set; }
        public string ShipToName { get; set; }
        public string ShipToAddress { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
