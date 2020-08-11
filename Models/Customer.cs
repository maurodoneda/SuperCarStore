using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperCarStore.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime DoB { get; set; }
        public string Adress { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }
        public bool IsSubscribed { get; set; }
        public ICollection<Store> Store { get; set; }
        public ICollection<MembershipType> MembershipType { get; set; }


    }
}