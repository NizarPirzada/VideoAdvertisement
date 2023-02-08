using System;
using System.Collections.Generic;

#nullable disable

namespace VimeoVSV.Web.DBModels
{
    public partial class Vsvlocation
    {
        public int VsvaccountId { get; set; }
        public int VsvlocationId { get; set; }
        public string LocationName { get; set; }
        public string YouTubeChannel { get; set; }
        public int? ShuffleRatio { get; set; }
        public int? ShuffleRatioProduct { get; set; }
    }
}
