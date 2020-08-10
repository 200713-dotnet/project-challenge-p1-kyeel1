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
            tempPizza.Crust = new CrustModel{Name = "thick",Description = "the thickest of crusts",Price = 2};
            tempPizza.Size = new SizeModel{Name = "Medium",Description = " a normal sized pizza",Diameter = 12,Price = 10};
            tempPizza.Toppings = new List<ToppingsModel>{new ToppingsModel{Name ="sausage",Description="spicy italian sausage", Price = 1},new ToppingsModel{Name ="cheese",Description="the cheesiest of toppings", Price = 1}};
            tempPizza.Name = "custom";
            tempPizza.Description = "custom";
            PizzaModel tempPizza2 = PF.Create();
            tempPizza2.SpecialPizza = true;
            tempPizza2.Crust = new CrustModel{Name = "thick",Description = "the thickest of crusts",Price = 2};
            tempPizza2.Size = new SizeModel{Name = "Medium",Description = " a normal sized pizza",Diameter = 12,Price = 10};
            tempPizza2.Toppings = new List<ToppingsModel>{new ToppingsModel{Name ="Pepperoni",Description="the best pizza topping", Price = 1},new ToppingsModel{Name ="cheese",Description="the cheesiest of toppings", Price = 1}};
            tempPizza2.Name = "Pepperoni";
            tempPizza2.Description = "mama mia its a pepperoni pizza";
            tempOrder.Pizzas.Add(tempPizza);
            tempOrder.Pizzas.Add(tempPizza2);
            //PR.Add(tempPizza);
            //PR.Add(tempPizza2);
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
            //UR.Add(tempUser);

            return View("Store",new PizzaViewModel(_db));
        }
        [HttpGet]
        public IActionResult Cart(){
            var PVM = new PizzaViewModel(_db);
            PVM.GetCart(_db);
            return View("Cart",PVM);
         }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PlaceOrderRegular(PizzaViewModel pizzaViewModel)
        {
            if(ModelState.IsValid)
            {
                pizzaViewModel.ConvertRegular(pizzaViewModel,_db);
                return Redirect("cart");
            }
            return Redirect("cart");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PlaceOrderSpecial(PizzaViewModel pizzaViewModel)
        {
            if(ModelState.IsValid)
            {
                pizzaViewModel.ConvertSpecial(pizzaViewModel,_db);
                return Redirect("cart");
            }
            return Redirect("cart");
        }
        [HttpPost]
        public IActionResult FinishOrder()
        {
            
            PizzaViewModel PVM = new PizzaViewModel(_db);
            PVM.GetCart(_db);
            PVM.FinishOrder(_db);
            return View("Store",new PizzaViewModel(_db));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
