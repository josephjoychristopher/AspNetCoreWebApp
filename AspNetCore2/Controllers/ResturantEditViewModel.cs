using AspNetCore2.Entities;
using System.ComponentModel.DataAnnotations;

namespace AspNetCore2.Controllers
{
    public class ResturantEditViewModel
    {
        [Required,MaxLength(80)]
        public string Name { get; set; }

        public CuisineType Cuisine { get; set; }
    }
}