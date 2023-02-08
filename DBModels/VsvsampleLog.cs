using System;
using System.Collections.Generic;

#nullable disable

namespace VimeoVSV.Web.DBModels
{
    public partial class VsvsampleLog
    {
        public int LogId { get; set; }
        public int ManId { get; set; }
        public int BrandId { get; set; }
        public int VidId { get; set; }
        public DateTime DateStamp { get; set; }
        public int VsvaccountId { get; set; }
    }
}
