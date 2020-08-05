using System.Collections.Generic;
using System.Linq;
using PizzaStore.Domain.Factory;
using PizzaStore.Domain.Models;

namespace PizzaStore.Storing
{
    public class SizeRepository : ARepository<SizeModel>
    {
        PizzaStoreDBContext _db;
        public SizeRepository(PizzaStoreDBContext dbContext)
        {
            _db = dbContext;
        }
        public void Add(SizeModel t)
        {
            _db.Sizes.Add(t);
            _db.SaveChanges();
        }

        public SizeModel Get(string name)
        {
            var SizeList = _db.Sizes;
            var query = SizeList.Single(Size => Size.Name ==name);
            return query;
        }

        public SizeModel Get(int id)
        {
            return _db.Sizes.Find(id);
        }

        public List<SizeModel> GetAll()
        {
            return _db.Sizes.ToList();
        }
    }
}