using System;
using System.Collections.Generic;

#nullable disable

namespace VimeoVSV.Web.DBModels
{
    public partial class Vsvbrand
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public int? ManId { get; set; }
    }
}
