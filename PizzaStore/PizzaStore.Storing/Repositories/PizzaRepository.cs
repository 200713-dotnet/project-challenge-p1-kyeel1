using System.Collections.Generic;
using PizzaStore.Domain.Models;

namespace PizzaStore.Storing
{
    public class PizzaRepository : ARepository<PizzaModel>
    {
        public void Add(PizzaModel t)
        {
            throw new System.NotImplementedException();
        }

        public void Add(int id, string name)
        {
            throw new System.NotImplementedException();
        }

        public PizzaModel Find(string name)
        {
            throw new System.NotImplementedException();
        }

        public PizzaModel Find(int id)
        {
            throw new System.NotImplementedException();
        }

        public PizzaModel Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public PizzaModel Get(string name)
        {
            throw new System.NotImplementedException();
        }

        public List<PizzaModel> GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}