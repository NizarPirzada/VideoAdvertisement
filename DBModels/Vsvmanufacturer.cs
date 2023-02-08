using System;
using System.Collections.Generic;

#nullable disable

namespace VimeoVSV.Web.DBModels
{
    public partial class Vsvmanufacturer
    {
        public int ManId { get; set; }
        public string ManName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string SampleEmail { get; set; }
        public string PromoEmail { get; set; }
    }
}
