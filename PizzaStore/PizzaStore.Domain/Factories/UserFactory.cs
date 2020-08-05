using System.Collections.Generic;
using PizzaStore.Domain.Models;
namespace PizzaStore.Domain.Factory
{
    public class UserFactory : IFactory<UserModel>
    {
        
        public UserModel Create()
        {
            var p = new UserModel();
            p.Name = "";
            p.Orders = new List<OrderModel>();
            return new UserModel();
        }
    }
}