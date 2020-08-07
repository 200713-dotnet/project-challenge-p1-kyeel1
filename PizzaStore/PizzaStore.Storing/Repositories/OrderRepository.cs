using System.Collections.Generic;
using System.Linq;
using PizzaStore.Domain.Factory;
using PizzaStore.Domain.Models;

namespace PizzaStore.Storing
{
    public class OrderRepository : ARepository<OrderModel>
    {
        PizzaStoreDBContext _db;
        public OrderRepository(PizzaStoreDBContext dbContext)
        {
            _db = dbContext;
        }
        public void Add(OrderModel t)
        {
            _db.Orders.Add(t);
            _db.SaveChanges();
        }

        public OrderModel Get(string name)
        {
            var OrderList = _db.Orders;
            var query = OrderList.Single(Order => Order.Name ==name);
            return query;
        }

        public OrderModel Get(int id)
        {
            return _db.Orders.Find(id);
        }
        public OrderModel GetCurrentOrder()
        {
            var OrderList = _db.Orders;
            var query = OrderList.Single(Order => Order.CurrentOrder ==true);
         
            return query;
        }
        public List<OrderModel> GetAll()
        {
            return _db.Orders.ToList();
        }
    }
}