using System;
using System.Collections.Generic;

#nullable disable

namespace VimeoVSV.Web.DBModels
{
    public partial class Vsvaccount
    {
        public int VsvaccountId { get; set; }
        public string AcctName { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string SamplesAddress1 { get; set; }
        public string SamplesAddress2 { get; set; }
        public string SamplesCity { get; set; }
        public string SamplesState { get; set; }
        public string SamplesZip { get; set; }
        public string Dmphone { get; set; }
        public string Dmname { get; set; }
        public string Dmemail { get; set; }
        public short? SamplesNiclevel { get; set; }
    }
}
