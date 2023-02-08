using System;
using System.Collections.Generic;

#nullable disable

namespace VimeoVSV.Web.DBModels
{
    public partial class Vsvuser
    {
        public int VsvaccountId { get; set; }
        public int VsvlocationId { get; set; }
        public int VsvuserId { get; set; }
        public string ListName { get; set; }
        public string Password { get; set; }
    }
}
