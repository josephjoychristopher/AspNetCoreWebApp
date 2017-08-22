using AspNetCore2.Entities;
using AspNetCore2.Services;
using AspNetCore2.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore2.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private IRestaurantData _restaurantData;
        private IGreeter _greeter;

        public HomeController(IRestaurantData restaurantData, IGreeter greeter)
        {
            _restaurantData = restaurantData;
            _greeter = greeter;
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index()
        {
            var model = new HomePageViewModel();
            model.Restaurants = _restaurantData.GetAll();
            model.CurrentMessage = _greeter.GetGreeting();
            return View(model);
        }
    
        public IActionResult Details(int id)
        {
            var model = _restaurantData.Get(id);
            if (model == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _restaurantData.Get(id);
            if (model == null)
            {
                return RedirectToAction("Index");

            }
            else
            {
                return View(model);

            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id,ResturantEditViewModel model)
        {
            var restaurant = _restaurantData.Get(id);
            if (ModelState.IsValid)
            {
                restaurant.Cuisine = model.Cuisine;
                restaurant.Name = model.Name;
                _restaurantData.Commit();            
                return RedirectToAction("Details", new { id = restaurant.Id });
            }
            return View(restaurant);
        }

            public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ResturantEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newRestaurant = new Resturant();
                newRestaurant.Cuisine = model.Cuisine;
                newRestaurant.Name = model.Name;

                _restaurantData.Add(newRestaurant);
                _restaurantData.Commit();
                return RedirectToAction("Details", new { id = newRestaurant.Id });
            }
            return View();
        }
    }
}
