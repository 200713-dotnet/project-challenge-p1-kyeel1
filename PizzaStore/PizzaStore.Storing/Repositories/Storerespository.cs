using PizzaStore.Domain.Models;

namespace PizzaStore.Storing
{
    public class StoreRepository : ARepository<StoreModel>
    {
        public void Add(StoreModel t)
        {
            throw new System.NotImplementedException();
        }

        public void Add(int id, string name)
        {
            throw new System.NotImplementedException();
        }

        public StoreModel Find(string name)
        {
            throw new System.NotImplementedException();
        }

        public StoreModel Find(int id)
        {
            throw new System.NotImplementedException();
        }

        public StoreModel Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public StoreModel Get(string name)
        {
            throw new System.NotImplementedException();
        }

        public System.Collections.Generic.List<StoreModel> GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}