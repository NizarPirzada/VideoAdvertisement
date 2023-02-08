using System;
using System.Collections.Generic;

#nullable disable

namespace VimeoVSV.Web.DBModels
{
    public partial class Gwywwishitem
    {
        public int WishItemId { get; set; }
        public int WishListId { get; set; }
        public string ItemType { get; set; }
        public int ShopId { get; set; }
        public string ShopName { get; set; }
    }
}
