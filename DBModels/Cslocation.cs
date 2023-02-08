using System;
using System.Collections.Generic;

#nullable disable

namespace VimeoVSV.Web.DBModels
{
    public partial class Cslocation
    {
        public int LocationsId { get; set; }
        public string LocationsName { get; set; }
        public int RecPeriod { get; set; }
        public int MarketId { get; set; }
        public string SpecialPricing { get; set; }
        public string Address { get; set; }
        public string CityStateZip { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string QbcustomerName { get; set; }
        public string SavedReconcile { get; set; }
        public int? RollUpPeriod { get; set; }
        public decimal? Rme60 { get; set; }
        public decimal? Distro60 { get; set; }
        public decimal? Distro100 { get; set; }
        public decimal? Distro120 { get; set; }
        public decimal? Rmesalts { get; set; }
        public decimal? Distrosalts { get; set; }
        public decimal? Cbd { get; set; }
        public decimal? Kratom { get; set; }
        public decimal? Accessories { get; set; }
        public decimal? Hardware { get; set; }
        public decimal? PrefilledPods { get; set; }
        public decimal? Fourtwenty { get; set; }
    }
}
