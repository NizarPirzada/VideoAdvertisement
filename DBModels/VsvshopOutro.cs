using System;
using System.Collections.Generic;

#nullable disable

namespace VimeoVSV.Web.DBModels
{
    public partial class VsvshopOutro
    {
        public int ShopOutroId { get; set; }
        public int VsvaccountId { get; set; }
        public string OutroUrl { get; set; }
        public int? VsvlocationId { get; set; }
    }
}
