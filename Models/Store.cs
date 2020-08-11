using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperCarStore.Models
{
    public class Store
    {
        public int StoreId { get; set; }
        public string Adress { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Manager { get; set; }
        public Car Car { get; set; }
        public int CarId { get; set; }
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }


    }
}