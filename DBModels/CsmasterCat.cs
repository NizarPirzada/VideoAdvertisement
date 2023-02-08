using System;
using System.Collections.Generic;

#nullable disable

namespace VimeoVSV.Web.DBModels
{
    public partial class CsmasterCat
    {
        public int MasterCatId { get; set; }
        public string MasterCatName { get; set; }
        public string SubCat { get; set; }
    }
}
