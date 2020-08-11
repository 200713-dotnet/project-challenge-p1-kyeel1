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
        
        [HttpGet]
        public IActionResult Get()
        {
            var UM =new UserViewModel(_db);
            if(UM.GetCurrentUser(_db) != null){
                UM.User = UM.GetCurrentUser(_db);
                return View("UserInfo",UM);
            }
            else{
                return View("UserLogIn",new UserViewModel(_db));
            }
        }
        [HttpPost]
        public IActionResult LogIn(UserViewModel uvm)
        {
            uvm.SetCurrentUser(_db);
            return View("UserInfo",uvm);

        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
