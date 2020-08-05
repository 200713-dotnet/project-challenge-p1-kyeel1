using System.Collections.Generic;
using PizzaStore.Domain.Models;

namespace PizzaStore.Storing
{
    public class OrderRepository : ARepository<OrderModel>
    {
        public void Add(OrderModel t)
        {
            throw new System.NotImplementedException();
        }

        public void Add(int id, string name)
        {
            throw new System.NotImplementedException();
        }

        public OrderModel Find(string name)
        {
            throw new System.NotImplementedException();
        }

        public OrderModel Find(int id)
        {
            throw new System.NotImplementedException();
        }

        public OrderModel Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public OrderModel Get(string name)
        {
            throw new System.NotImplementedException();
        }

        public List<OrderModel> GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}