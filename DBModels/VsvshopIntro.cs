using System;
using System.Collections.Generic;

#nullable disable

namespace VimeoVSV.Web.DBModels
{
    public partial class VsvshopIntro
    {
        public int ShopIntroId { get; set; }
        public int VsvaccountId { get; set; }
        public string IntroUrl { get; set; }
        public int? VsvlocationId { get; set; }
    }
}
