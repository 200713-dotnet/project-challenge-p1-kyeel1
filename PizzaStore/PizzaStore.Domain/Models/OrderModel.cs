using System.Collections.Generic;
namespace PizzaStore.Domain.Models
{
    public class OrderModel : AModel
    {
        public bool CurrentOrder{get;set;}
        public string Name{get;set;}
        public List<PizzaModel> Pizzas {get;set;}
        
        public override string ToString()
        {
            //return $"Order: {Name}, Total Price: {CalculatePrice()}";
            return $"{Name}";
        }
        public int CalculatePrice()
        {
            int result = 0;
            foreach(PizzaModel p in Pizzas)
            {
                result += p.CalculatePricing();
            }
            return result;
        }
    }
}