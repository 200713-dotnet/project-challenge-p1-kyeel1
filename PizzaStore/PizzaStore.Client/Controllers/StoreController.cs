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
    public class StoreController : Controller
    {
        private readonly PizzaStoreDBContext _db; 
        public StoreController(PizzaStoreDBContext dbContext)
        {
            _db = dbContext;
        }
        [HttpGet()]
        public IEnumerable<StoreModel> Get()
        {
            return _db.Stores.ToList();
        }
        [HttpGet("{id}")]
        public StoreModel Get(int id)
        {
            return _db.Stores.SingleOrDefault(p => p.Id == id);
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
