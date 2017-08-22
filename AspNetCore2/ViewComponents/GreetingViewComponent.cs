using AspNetCore2.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore2.ViewComponents
{
    public class GreetingViewComponent:ViewComponent
    {
        private IGreeter _greeter;

        public GreetingViewComponent(IGreeter greeter)
        {
            _greeter = greeter;
        }
        public IViewComponentResult Invoke()
        {
            var model = _greeter.GetGreeting();
            return View("Default",model);
        }
    }
}
