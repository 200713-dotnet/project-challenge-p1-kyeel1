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
    public class StoreController : Controller
    {
        private readonly PizzaStoreDBContext _db; 
        public StoreController(PizzaStoreDBContext dbContext)
        {
            _db = dbContext;
        }
        [HttpGet]
        public IActionResult StoreInfo()
        {
            var SM =new StoreViewModel(_db);
            
            if(SM.GetCurrentStore(_db) != null){
                SM.Store = SM.GetCurrentStore(_db);
                return View("StoreInfo",SM);
            }
            else{
                return View("StoreLogIn",new StoreViewModel(_db));
            }
        }
        [HttpGet]
        public IActionResult StoreLogIn()
        {
            return View("StoreLogIn",new StoreViewModel(_db));
        }
        [HttpPost]
        public IActionResult LogIn(StoreViewModel SVM)
        {
            SVM.SetCurrentStore(_db);
            return View("StoreInfo",SVM);

        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
