using System.Collections.Generic;
using PizzaStore.Domain.Models;
namespace PizzaStore.Domain.Factory
{
    public class SpecialtyPizzaFactory : IFactory<PizzaModel>
    {
        
        public PizzaModel Create()
        {
            var p = new PizzaModel();
            p.Crust = new CrustModel();
            p.Size = new SizeModel();
            p.Toppings = new List<ToppingsModel>();
            return new PizzaModel();
        }
    }
}