using System;
using System.Collections.Generic;

#nullable disable

namespace VimeoVSV.Web.DBModels
{
    public partial class Vcsale
    {
        public int InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public int CustomerId { get; set; }
        public int AssociateId { get; set; }
        public int? UplineAssociateId { get; set; }
        public decimal SubTotal { get; set; }
        public decimal SalesTax { get; set; }
        public decimal Shipping { get; set; }
        public decimal Total { get; set; }
        public string PaymentType { get; set; }
        public string AssocStock { get; set; }
        public DateTime ShipDate { get; set; }
        public decimal AssocCom { get; set; }
        public decimal? UplineAssocCom { get; set; }
        public decimal? CompanyCom { get; set; }
        public bool OrderComplete { get; set; }
        public string PaypalInvoiceId { get; set; }
    }
}
