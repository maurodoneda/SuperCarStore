using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperCarStore.Models
{
    public class MembershipType
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int Discount { get; set; }
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
    }
}