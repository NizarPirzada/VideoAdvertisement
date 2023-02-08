using System;
using System.Collections.Generic;

#nullable disable

namespace VimeoVSV.Web.DBModels
{
    public partial class VsvuserVid
    {
        public int UserVidId { get; set; }
        public int VsvuserId { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public string Shown { get; set; }
        public int? Evid { get; set; }
    }
}
