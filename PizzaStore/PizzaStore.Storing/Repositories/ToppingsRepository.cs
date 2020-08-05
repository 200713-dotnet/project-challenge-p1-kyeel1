using System.Collections.Generic;
using System.Linq;
using PizzaStore.Domain.Factory;
using PizzaStore.Domain.Models;

namespace PizzaStore.Storing
{
    public class ToppingRepository : ARepository<ToppingsModel>
    {
        PizzaStoreDBContext _db;
        public ToppingRepository(PizzaStoreDBContext dbContext)
        {
            _db = dbContext;
        }
        public void Add(ToppingsModel t)
        {
            _db.Toppings.Add(t);
            _db.SaveChanges();
        }

        public ToppingsModel Get(string name)
        {
            var ToppingList = _db.Toppings;
            var query = ToppingList.Single(Topping => Topping.Name ==name);
            return query;
        }

        public ToppingsModel Get(int id)
        {
            return _db.Toppings.Find(id);
        }

        public List<ToppingsModel> GetAll()
        {
            return _db.Toppings.ToList();
        }
    }
}