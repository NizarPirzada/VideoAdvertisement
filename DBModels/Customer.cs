using System;
using System.Collections.Generic;

#nullable disable

namespace demoApp.DBModels
{
    public partial class Customer
    {
        public string Name { get; set; }
        public Guid? Id { get; set; }
    }
}
