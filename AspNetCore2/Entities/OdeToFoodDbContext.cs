using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq;

namespace AspNetCore2.Entities
{
    public class OdeToFoodDbContext:IdentityDbContext<User>
    {
        public OdeToFoodDbContext(DbContextOptions<OdeToFoodDbContext> options):base(options)
        {
                
        }
        public DbSet<Resturant> Resturants { get; set; }
        
        
    }
}
