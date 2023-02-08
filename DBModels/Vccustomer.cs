using System;
using System.Collections.Generic;

#nullable disable

namespace VimeoVSV.Web.DBModels
{
    public partial class Vccustomer
    {
        public int CustomerId { get; set; }
        public int AssociateId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string SocialSecurityNumber { get; set; }
        public string FedTaxIdNumber { get; set; }
        public string Active { get; set; }
        public DateTime JoinDate { get; set; }
        public DateTime? VaporRoomJoinDate { get; set; }
        public string VaporGroup { get; set; }
        public DateTime LastActivity { get; set; }
        public string PaypalEmail { get; set; }
        public string RetailOrAssociate { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
