using System.Collections.Generic;
using System.Linq;
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
            var query = StoreList.Single(Store => Store.Name ==name);
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
            var StoreList = _db.Stores;
            var query = StoreList.Single(store => store.CurrentStore ==true);
         
            return query;
        }
        public bool CheckCurrentStore()
        {
            var StoreList = _db.Stores;
            if(StoreList.SingleOrDefault(user => user.CurrentStore ==true) != null){
            return true;
            }
            else
            {
                return false;
            }
        }
    }
}