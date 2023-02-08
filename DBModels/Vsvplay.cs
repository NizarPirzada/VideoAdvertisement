using System;
using System.Collections.Generic;

#nullable disable

namespace VimeoVSV.Web.DBModels
{
    public partial class Vsvplay
    {
        public int VsvplayId { get; set; }
        public int VsvaccountId { get; set; }
        public int VsvlocationId { get; set; }
        public int VidId { get; set; }
        public DateTime PlayTimeStamp { get; set; }
    }
}
