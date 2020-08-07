using PizzaStore.Domain.Factory;
using PizzaStore.Domain.Models;
using PizzaStore.Storing;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PizzaStore.Client.Models
{
    public class UserViewModel
    {
        public UserModel User{get;set;}
        private PizzaStoreDBContext _db;
        public UserViewModel(PizzaStoreDBContext dbo)
        {
            var UF = new UserFactory();
            User = UF.Create();
            _db =dbo;
        }
        public UserViewModel()
        {

        }
        public UserModel GetCurrentUser(PizzaStoreDBContext _db)
        {
            var UR = new UserRepository(_db);
            return UR.GetCurrentUser();
        }
        public void SetCurrentUser(PizzaStoreDBContext _db)
        {
            var UR = new UserRepository(_db);
            User.CurrentUser=true;
            UR.Add(User);

        }
        public bool CheckCurrentUser(PizzaStoreDBContext _db)
        {
            var UR = new UserRepository(_db);
            return UR.CheckCurrentUser();
        }
    }
}