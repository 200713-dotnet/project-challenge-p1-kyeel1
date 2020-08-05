using System.Collections.Generic;
using PizzaStore.Domain.Models;

namespace PizzaStore.Storing
{
    public class CrustRepository : ARepository<CrustModel>
    {
        public void Add(CrustModel t)
        {
            throw new System.NotImplementedException();
        }

        public void Add(int id, string name)
        {
            throw new System.NotImplementedException();
        }

        public CrustModel Find(string name)
        {
            throw new System.NotImplementedException();
        }

        public CrustModel Find(int id)
        {
            throw new System.NotImplementedException();
        }

        public CrustModel Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public CrustModel Get(string name)
        {
            throw new System.NotImplementedException();
        }

        public List<CrustModel> GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}