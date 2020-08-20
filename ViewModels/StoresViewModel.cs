using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SuperCarStore.Models;

namespace SuperCarStore.ViewModels
{
    public class StoresViewModel
    {

        public int SelectedStoreId { get; set; }

        public IEnumerable<Store> Stores { get; set; }

        public IEnumerable<Car> Cars { get; set; }


    }
}