using PizzaStore.Domain.Models;

namespace PizzaStore.Storing
{
    public class ToppingsRepository : ARepository<ToppingsModel>
    {
        public void Add(ToppingsModel t)
        {
            throw new System.NotImplementedException();
        }

        public void Add(int id, string name)
        {
            throw new System.NotImplementedException();
        }

        public ToppingsModel Find(string name)
        {
            throw new System.NotImplementedException();
        }

        public ToppingsModel Find(int id)
        {
            throw new System.NotImplementedException();
        }

        public ToppingsModel Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public ToppingsModel Get(string name)
        {
            throw new System.NotImplementedException();
        }

        public System.Collections.Generic.List<ToppingsModel> GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}