using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PizzaStore.Client.Models;
using PizzaStore.Domain.Factory;
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
        [HttpGet]
        public IActionResult Store()
        {
            OrderFactory OF = new OrderFactory();
            OrderModel tempOrder =new OrderModel();
            tempOrder.Pizzas = new List<PizzaModel>();
            tempOrder.CurrentOrder = true;
            ToppingRepository TR = new ToppingRepository(_db);
            PizzaRepository PR = new PizzaRepository(_db);
            OrderRepository OR = new OrderRepository(_db);
            StoreRepository SR = new StoreRepository(_db);
            UserRepository UR = new UserRepository(_db);
            PizzaFactory PF = new PizzaFactory();
            PizzaModel tempPizza = PF.Create();
            tempPizza.Crust = new CrustModel{Name = "thick",Description = "the thickest of crusts"};
            tempPizza.Size = new SizeModel{Name = "Medium",Description = " a normal sized pizza",Diameter = 12};
            tempPizza.Toppings = new List<ToppingsModel>{new ToppingsModel{Name ="sausage",Description="spicy italian sausage"},new ToppingsModel{Name ="cheese",Description="the cheesiest of toppings"}};
            tempPizza.Name = "custom";
            tempPizza.Description = "custom";
            tempOrder.Pizzas.Add(tempPizza);
            //PR.Add(tempPizza);
            //OR.Add(tempOrder);
            var tempStore = new StoreModel();
            tempStore.CurrentStore = true;
            tempStore.Name = "dominos";
            tempStore.Orders = new List<OrderModel>();
            tempStore.Orders.Add(tempOrder);
            var tempUser = new UserModel();
            tempUser.Name = "Henry";
            tempUser.Orders = new List<OrderModel>();
            tempUser.Orders.Add(tempOrder);
            tempUser.CurrentUser = true;
            //SR.Add(tempStore);
           // UR.Add(tempUser);

            return View("Store",new PizzaViewModel(_db));
        }
        public IActionResult Cart(){
            var PVM = new PizzaViewModel(_db);
            PVM.GetCart(_db);
            return View("Cart",PVM);
         }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PlaceOrderRegular(PizzaViewModel pizzaViewModel)
        {
            var PVM = new PizzaViewModel(_db);
            PVM.GetCart(_db);
            if(ModelState.IsValid)
            {
                pizzaViewModel.ConvertRegular(pizzaViewModel,_db);
                return View("Cart",PVM);
            }
            return View("Cart",PVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PlaceOrderSpecial(PizzaViewModel pizzaViewModel)
        {
            if(ModelState.IsValid)
            {
                pizzaViewModel.ConvertSpecial(pizzaViewModel,_db);
                return View("Store",new PizzaViewModel(_db));
            }
            return View("Store",pizzaViewModel);
        }
        [HttpPost]
        public IActionResult FinishOrder()
        {
            
            
            return View("Store",new PizzaViewModel(_db));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
