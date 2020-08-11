using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaStore.Domain.Factory;
using PizzaStore.Domain.Models;

namespace PizzaStore.Storing
{
    public class UserRepository : ARepository<UserModel>
    {
        PizzaStoreDBContext _db;
        public UserRepository(PizzaStoreDBContext dbContext)
        {
            _db = dbContext;
        }
        public void Add(UserModel t)
        {
            _db.Users.Add(t);
            _db.SaveChanges();
        }

        public UserModel Get(string name)
        {
            var UserList = _db.Users;
            var query = UserList.First(User => User.Name ==name);
            return query;
        }

        public UserModel Get(int id)
        {
            return _db.Users.Find(id);
        }

        public List<UserModel> GetAll()
        {
            return _db.Users.ToList();
        }
        public UserModel GetCurrentUser()
        {
            var UserList = _db.Users.Include(orders => _db.Orders.ToList()).Include(pizzas => _db.Pizzas.ToList()).Include(size => _db.Sizes.ToList()).Include(crust => _db.Crusts.ToList()).Include(toppings => _db.Toppings.ToList()).ToList();
            var query = UserList.FirstOrDefault(user => user.CurrentUser ==true);

            return query;
        }
        public void AddOrder(int um,OrderModel om){
            var UserList = _db.Users.Include(orders => _db.Orders.ToList()).Include(pizzas => _db.Pizzas.ToList()).Include(size => _db.Sizes.ToList()).Include(crust => _db.Crusts.ToList()).Include(toppings => _db.Toppings.ToList()).ToList();
            var query = UserList.First(user => user.Id == um);
            query.Orders.Add(om);
            _db.SaveChanges();
        
        }
    }
}