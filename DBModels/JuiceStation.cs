using System;
using System.Collections.Generic;

#nullable disable

namespace VimeoVSV.Web.DBModels
{
    public partial class JuiceStation
    {
        public int Recordid { get; set; }
        public string JuiceName { get; set; }
        public string JuiceDescription { get; set; }
        public string Vendor { get; set; }
        public string Lenexa { get; set; }
    }
}
