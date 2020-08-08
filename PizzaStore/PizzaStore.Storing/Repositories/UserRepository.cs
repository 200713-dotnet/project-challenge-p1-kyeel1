using System.Collections.Generic;
using System.Linq;
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
        public bool CheckCurrentUser()
        {
            var UserList = _db.Users;
            if(UserList.FirstOrDefault(user => user.CurrentUser ==true) != null){
            return true;
            }
            else
            {
                return false;
            }
        }
        public UserModel GetCurrentUser()
        {
            var UserList = _db.Users;
            var query = UserList.First(user => user.CurrentUser ==true);

            return query;
        }
    }
}