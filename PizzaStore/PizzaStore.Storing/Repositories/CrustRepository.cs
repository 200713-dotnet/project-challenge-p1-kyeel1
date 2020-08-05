using System.Collections.Generic;
using System.Linq;
using PizzaStore.Domain.Factory;
using PizzaStore.Domain.Models;

namespace PizzaStore.Storing
{
    public class CrustRepository : ARepository<CrustModel>
    {
        PizzaStoreDBContext _db;
        public CrustRepository(PizzaStoreDBContext dbContext)
        {
            _db = dbContext;
        }
        public void Add(CrustModel t)
        {
            _db.Crusts.Add(t);
            _db.SaveChanges();
        }

        public CrustModel Get(string name)
        {
            var CrustList = _db.Crusts;
            var query = CrustList.Single(Crust => Crust.Name ==name);
            return query;
        }

        public CrustModel Get(int id)
        {
            return _db.Crusts.Find(id);
        }

        public List<CrustModel> GetAll()
        {
            return _db.Crusts.ToList();
        }
    }
}