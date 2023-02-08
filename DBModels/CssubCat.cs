using System;
using System.Collections.Generic;

#nullable disable

namespace VimeoVSV.Web.DBModels
{
    public partial class CssubCat
    {
        public int SubCatId { get; set; }
        public int MasterCatId { get; set; }
        public string SubCatName { get; set; }
    }
}
