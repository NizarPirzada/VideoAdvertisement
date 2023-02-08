using System;
using System.Collections.Generic;

#nullable disable

namespace VimeoVSV.Web.DBModels
{
    public partial class Vsvaccountprodvideo
    {
        public int VsvaccountId { get; set; }
        public int AccountVidId { get; set; }
        public int VidId { get; set; }
        public string Url { get; set; }
        public string Shown { get; set; }
        public int? VsvlocationId { get; set; }
    }
}
