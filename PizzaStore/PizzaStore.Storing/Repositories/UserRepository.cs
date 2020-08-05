using System.Collections.Generic;
using PizzaStore.Domain.Models;

namespace PizzaStore.Storing
{
    public class UserReposistory : ARepository<UserModel>
    {
        public void Add(UserModel t)
        {
            throw new System.NotImplementedException();
        }

        public void Add(int id, string name)
        {
            throw new System.NotImplementedException();
        }

        public UserModel Find(string name)
        {
            throw new System.NotImplementedException();
        }

        public UserModel Find(int id)
        {
            throw new System.NotImplementedException();
        }

        public UserModel Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public UserModel Get(string name)
        {
            throw new System.NotImplementedException();
        }

        public List<UserModel> GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}