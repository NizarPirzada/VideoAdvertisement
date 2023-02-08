using System;
using System.Collections.Generic;

#nullable disable

namespace VimeoVSV.Web.DBModels
{
    public partial class Gwywshop
    {
        public int ShopId { get; set; }
        public string ShopName { get; set; }
        public string BmorOnline { get; set; }
        public string ShopType { get; set; }
        public string ShopGender { get; set; }
        public string GiftCard { get; set; }
        public string GiftCardImageName { get; set; }
    }
}
