using System;
using System.Collections.Generic;

#nullable disable

namespace VimeoVSV.Web.DBModels
{
    public partial class Vsvproduct
    {
        public int VidId { get; set; }
        public string ProdType { get; set; }
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public string ProductName { get; set; }
        public string Private { get; set; }
        public int? PrivateVsvaccountId { get; set; }
        public string HardwareSubType { get; set; }
        public string Url { get; set; }
        public DateTime? ELiquidIntroDate { get; set; }
        public int? ManId { get; set; }
    }
}
