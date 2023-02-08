using System;
using System.Collections.Generic;

#nullable disable

namespace VimeoVSV.Web.DBModels
{
    public partial class CsspecialPricing
    {
        public int SpecialPricingId { get; set; }
        public int LocationsId { get; set; }
        public int ProductId { get; set; }
        public DateTime EffectiveDate { get; set; }
        public decimal Consignment { get; set; }
    }
}
