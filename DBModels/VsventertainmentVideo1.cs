using System;
using System.Collections.Generic;

#nullable disable

namespace VimeoVSV.Web.DBModels
{
    public partial class VsventertainmentVideo1
    {
        public int Evid { get; set; }
        public int Mgid { get; set; }
        public int MusicId { get; set; }
        public int ArtistId { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public int? UserId { get; set; }
    }
}
