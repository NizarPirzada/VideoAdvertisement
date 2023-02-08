using System;
using System.Collections.Generic;

#nullable disable

namespace VimeoVSV.Web.DBModels
{
    public partial class Csuser
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int? Phone { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public DateTime? Dob { get; set; }
        public string StreetAddress1 { get; set; }
        public string StreetAddress2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public string Role { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? MarketId { get; set; }
    }
}
