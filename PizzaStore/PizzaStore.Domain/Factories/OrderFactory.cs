using System.Collections.Generic;
using PizzaStore.Domain.Models;
namespace PizzaStore.Domain.Factory
{
    public class OrderFactory : IFactory<OrderModel>
    {
        
        public OrderModel Create()
        {
            var p = new OrderModel();
            p.Name = "";
            p.Pizzas = new List<PizzaModel>();
            return new OrderModel();
        }
    }
}