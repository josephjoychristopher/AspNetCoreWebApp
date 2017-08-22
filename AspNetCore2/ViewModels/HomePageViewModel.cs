using AspNetCore2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore2.ViewModels
{
    public class HomePageViewModel
    {
        public string CurrentMessage { get; set; }

        public IEnumerable<Resturant> Restaurants { get; set; }
    }
}
