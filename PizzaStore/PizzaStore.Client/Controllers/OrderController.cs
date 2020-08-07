using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PizzaStore.Client.Models;
using PizzaStore.Domain.Models;
using PizzaStore.Storing;

namespace PizzaStore.Client.Controllers
{
    [Route("/[controller]/[action]")]
    public class OrderController : Controller
    {
        private readonly PizzaStoreDBContext _db; 
        public OrderController(PizzaStoreDBContext dbContext)
        {
            _db = dbContext;
        }

        [HttpGet()]
        public IEnumerable<OrderModel> Get()
        {
            return _db.Orders.ToList();
        }
        [HttpGet("{id}")]
        public OrderModel Get(int id)
        {
            return _db.Orders.SingleOrDefault(p => p.Id == id);
        }
        public IActionResult Store()
        {
            return View("Store",new PizzaViewModel(_db));
        }
        public IActionResult Cart(){
            return View("Cart");
         }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PlaceOrderRegular(PizzaViewModel pizzaViewModel)
        {
            if(ModelState.IsValid)
            {
                pizzaViewModel.ConvertRegular(pizzaViewModel,_db);
                return View("Store");
            }
            return View("Store",pizzaViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PlaceOrderSpecial(PizzaViewModel pizzaViewModel)
        {
            if(ModelState.IsValid)
            {
                pizzaViewModel.ConvertSpecial(pizzaViewModel,_db);
                return View("Store");
            }
            return View("Store",pizzaViewModel);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
