using System;
using System.Collections.Generic;

#nullable disable

namespace VimeoVSV.Web.DBModels
{
    public partial class Gwywwishlist
    {
        public int WishListId { get; set; }
        public int MemberId { get; set; }
        public string Wlname { get; set; }
    }
}
