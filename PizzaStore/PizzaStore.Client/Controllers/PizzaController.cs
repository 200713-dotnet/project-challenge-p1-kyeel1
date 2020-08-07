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
    public class PizzaController : Controller
    {
        private readonly PizzaStoreDBContext _db; 
        public PizzaController(PizzaStoreDBContext dbContext)
        {
            _db = dbContext;
        }

        [HttpGet()]
        public IActionResult Home()
        {
            var repo = new PizzaRepository(_db);
            /*
            PizzaFactory pf = new PizzaFactory();
            var tempPizza = pf.Create();
            tempPizza.Name = "cheese";
            tempPizza.Description ="the cheesiest of pizzas";
            tempPizza.Crust= new CrustModel{Name ="thin",Description = "a thin crusted pizza"};
            tempPizza.Size = new SizeModel{Name = "small",Diameter =10};
            tempPizza.Toppings= new List<ToppingsModel>{new ToppingsModel(){Name = "cheese",Description ="the cheeseiest of toppings"}};
            repo.Add(tempPizza);*/
            ViewBag.PizzaList = repo.GetAll();
            return View("Home");
        }
        [HttpGet("{id}")]
        public PizzaModel Get(int id)
        {
            return _db.Pizzas.SingleOrDefault(p => p.Id == id);
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
