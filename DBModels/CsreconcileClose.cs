using System;
using System.Collections.Generic;

#nullable disable

namespace VimeoVSV.Web.DBModels
{
    public partial class CsreconcileClose
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? LocationsId { get; set; }
        public string LocationsName { get; set; }
        public int? RecPeriod { get; set; }
        public string SavedReconcile { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
