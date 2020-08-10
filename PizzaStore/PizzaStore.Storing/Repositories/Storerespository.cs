using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaStore.Domain.Factory;
using PizzaStore.Domain.Models;

namespace PizzaStore.Storing
{
    public class StoreRepository : ARepository<StoreModel>
    {
        PizzaStoreDBContext _db;
        public StoreRepository(PizzaStoreDBContext dbContext)
        {
            _db = dbContext;
        }
        public void Add(StoreModel t)
        {
            _db.Stores.Add(t);
            _db.SaveChanges();
        }

        public StoreModel Get(string name)
        {
            var StoreList = _db.Stores;
            var query = StoreList.First(Store => Store.Name ==name);
            return query;
        }

        public StoreModel Get(int id)
        {
            return _db.Stores.Find(id);
        }

        public List<StoreModel> GetAll()
        {
            return _db.Stores.ToList();
        }
        public StoreModel GetCurrentStore()
        {
            var StoreList = _db.Stores.Include(orders => _db.Orders.ToList()).Include(pizzas => _db.Pizzas.ToList()).Include(size => _db.Sizes.ToList()).Include(crust => _db.Crusts.ToList()).Include(toppings => _db.Toppings.ToList()).ToList();
            var query = StoreList.First(store => store.CurrentStore ==true);
         
            return query;
        }
        public void AddOrder(int sm,OrderModel om){
            var StoreList = _db.Stores.Include(orders => _db.Orders.ToList()).Include(pizzas => _db.Pizzas.ToList()).Include(size => _db.Sizes.ToList()).Include(crust => _db.Crusts.ToList()).Include(toppings => _db.Toppings.ToList()).ToList();
            var query = StoreList.First(store => store.Id==sm);
            query.Orders.Add(om);
            _db.SaveChanges();
        
        }
    }
}