using System;
using System.Collections.Generic;

#nullable disable

namespace VimeoVSV.Web.DBModels
{
    public partial class VsvpromoLog
    {
        public int LogId { get; set; }
        public int ManId { get; set; }
        public int BrandId { get; set; }
        public DateTime DateStamp { get; set; }
        public int VsvaccountId { get; set; }
        public string TheOffer { get; set; }
    }
}
