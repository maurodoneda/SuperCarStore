using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SuperCarStore.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public DateTime DoB { get; set; }
        public string Address { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }
        public bool IsSubscribed { get; set; }
        public MembershipType MembershipType { get; set; }
        public int MembershipTypeId { get; set; }

    }
}