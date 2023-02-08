using System;
using System.Collections.Generic;

#nullable disable

namespace VimeoVSV.Web.DBModels
{
    public partial class Rtoken
    {
        public int Id { get; set; }
        public string RefreshToken { get; set; }
        public int IsStop { get; set; }
        public DateTime CreatedTimestamp { get; set; }
    }
}
