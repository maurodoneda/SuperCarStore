using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SuperCarStore.Models
{
    public class Car
    {
        public int Id { get; set; }
        [Required]
        public string Make { get; set; }
        [Required]
        public string Model { get; set; }
        public DateTime Year { get; set; }
        public double HP { get; set; }
        public string EngineSpec { get; set; }
        public string FuelType { get; set; }
        public double TopSpeed { get; set; }
        public double ZeroTo60 { get; set; }
        public double SalePrice { get; set; }
        public double RentalPrice { get; set; }
        public string ImgUrl { get; set; }
        public virtual Store Store { get; set; }
        public int StoreId { get; set; }


    }
}