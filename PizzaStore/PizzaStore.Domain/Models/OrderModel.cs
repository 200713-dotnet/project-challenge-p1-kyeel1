using System.Collections.Generic;
namespace PizzaStore.Domain.Models
{
    public class OrderModel : AModel
    {
        public string Name{get;set;}
        public List<PizzaModel> Pizzas {get;set;}
        public override string ToString()
        {
            return $"Order: {Name}";
        }
    }
}