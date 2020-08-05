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
    public class UserController : Controller
    {
        private readonly PizzaStoreDBContext _db; 
        public UserController(PizzaStoreDBContext dbContext)
        {
            _db = dbContext;
        }

        [HttpGet()]
        public IEnumerable<UserModel> Get()
        {
            return _db.Users.ToList();
        }
        [HttpGet("{id}")]
        public UserModel Get(int id)
        {
            return _db.Users.SingleOrDefault(p => p.Id == id);
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}