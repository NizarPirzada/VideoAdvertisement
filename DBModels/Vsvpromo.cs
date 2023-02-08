using System;
using System.Collections.Generic;

#nullable disable

namespace VimeoVSV.Web.DBModels
{
    public partial class Vsvpromo
    {
        public int PromosId { get; set; }
        public int ManId { get; set; }
        public DateTime PromoStart { get; set; }
        public int BrandId { get; set; }
        public string BottleSize { get; set; }
        public string TheOffer { get; set; }
        public DateTime PromoEnd { get; set; }
        public string TargetNew { get; set; }
        public string TargetExisting { get; set; }
        public int? VidId { get; set; }
    }
}
