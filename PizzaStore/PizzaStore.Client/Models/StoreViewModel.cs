using PizzaStore.Domain.Factory;
using PizzaStore.Domain.Models;
using PizzaStore.Storing;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PizzaStore.Client.Models
{
    public class StoreViewModel
    {
        public StoreModel Store{get;set;}
        private PizzaStoreDBContext _db;
        public StoreViewModel(PizzaStoreDBContext dbo)
        {
            var SF = new StoreFactory();
            Store = SF.Create();
            _db =dbo;
        }
        public StoreModel GetCurrentStore()
        {
            var SR = new StoreRepository(_db);
            return SR.GetCurrentStore();
        }
        public void SetCurrentStore()
        {
            var SR = new StoreRepository(_db);
            Store.CurrentStore=true;
            SR.Add(Store);

        }
    }
}