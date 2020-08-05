using System.Collections.Generic;
using PizzaStore.Domain.Models;
namespace PizzaStore.Domain.Factory
{
    public class StoreFactory : IFactory<StoreModel>
    {
        
        public StoreModel Create()
        {
            var p = new StoreModel();
            p.Name = "";
            p.Description = "";
            p.Orders = new List<OrderModel>();
            return new StoreModel();
        }
    }
}