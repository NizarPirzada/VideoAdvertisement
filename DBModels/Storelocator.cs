using System;
using System.Collections.Generic;

#nullable disable

namespace VimeoVSV.Web.DBModels
{
    public partial class Storelocator
    {
        public short? WebSiteId { get; set; }
        public string StoreName { get; set; }
        public string StoreAddress { get; set; }
        public string StoreCity { get; set; }
        public string StoreState { get; set; }
        public string StoreZip { get; set; }
        public string StorePhone { get; set; }
    }
}
