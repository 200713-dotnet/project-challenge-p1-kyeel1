using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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
            var OrderList = _db.Orders.Include(pizzas => _db.Pizzas.Include(size => _db.Sizes.ToList()).Include(crust => _db.Crusts.ToList()).Include(toppings => _db.Toppings.ToList()).ToList());
            var query = OrderList.Include(pizzas => _db.Pizzas.Include(size => _db.Sizes.ToList()).Include(crust => _db.Crusts.ToList()).Include(toppings => _db.Toppings.ToList()).ToList()).First(Order => Order.Name ==name);
            return query;
        }

        public OrderModel Get(int id)
        {
            return _db.Orders.Find(id);
        }
        public OrderModel GetCurrentOrder()
        {
            var OrderList = _db.Orders.Include(pizzas => _db.Pizzas.ToList()).Include(size => _db.Sizes.ToList()).Include(crust => _db.Crusts.ToList()).Include(toppings => _db.Toppings.ToList()).ToList();
            var query = OrderList.FirstOrDefault(Order => Order.CurrentOrder ==true );
         
            return query;
        }
        
        public List<OrderModel> GetAll()
        {
            return _db.Orders.ToList();
        }
        public void UpdateCurrentOrder(OrderModel om)
        {
            var tempOrder =GetCurrentOrder();
            if(tempOrder != null){
            tempOrder.CurrentOrder =false;
            }
            _db.Orders.Add(om);
            _db.SaveChanges();
        }
        public void UpdateCurrentOrder()
        {
            var tempOrder =GetCurrentOrder();
            tempOrder.CurrentOrder =false;
            _db.SaveChanges();
        }
        public void AddPizza(int om,PizzaModel pm){
            var OrderList = _db.Orders.Include(pizzas => _db.Pizzas.ToList()).Include(size => _db.Sizes.ToList()).Include(crust => _db.Crusts.ToList()).Include(toppings => _db.Toppings.ToList()).ToList();
            var query = OrderList.FirstOrDefault(Order => Order.Id ==om );
            query.Pizzas.Add(pm);
            _db.SaveChanges();
        
        }
    }
}