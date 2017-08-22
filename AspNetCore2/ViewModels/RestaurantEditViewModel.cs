using AspNetCore2.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore2.ViewModels
{
    public class RestaurantEditViewModel
    {
        [Required, MaxLength(80)]
        public string Name { get; set; }

        public CuisineType Cuisine { get; set; }
    }
}
