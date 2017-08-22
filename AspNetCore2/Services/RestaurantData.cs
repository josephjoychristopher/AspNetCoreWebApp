using AspNetCore2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore2.Services
{
    public interface IRestaurantData
    {
        IEnumerable<Resturant> GetAll();
        Resturant Get(int id);
        Resturant Add(Resturant newRestaurant);
        void Commit();
    }

    public class SqlRestaurantData : IRestaurantData
    {
        private OdeToFoodDbContext _context;

        public SqlRestaurantData(OdeToFoodDbContext context)
        {
            _context = context;
        }
        public Resturant Add(Resturant newRestaurant)
        {
            _context.Add(newRestaurant);      
            return newRestaurant;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public Resturant Get(int id)
        {
            return _context.Resturants.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Resturant> GetAll()
        {
            return _context.Resturants;
        }
    }
    public class InMemoryRestaurantData : IRestaurantData
    {
        static InMemoryRestaurantData()
        {
            _restaurants = new List<Resturant>()
            {
                new Resturant{ Id=1, Name="The House of Kobe"},
                new Resturant{ Id=2, Name="LJ's and the kat"},
                new Resturant{ Id=3, Name="King's Contrivance"}
            };

        }
        public IEnumerable<Resturant> GetAll()
        {
            return _restaurants;
        }

        public Resturant Get(int id)
        {
            return _restaurants.FirstOrDefault(r=>r.Id==id);
        }

        public Resturant Add(Resturant newRestaurant)
        {
            newRestaurant.Id = _restaurants.Max(r => r.Id) + 1;
            _restaurants.Add(newRestaurant);
            return newRestaurant;
        }

        public void Commit()
        {
            //  No Operation
        }

        static List<Resturant> _restaurants;
    }
}
