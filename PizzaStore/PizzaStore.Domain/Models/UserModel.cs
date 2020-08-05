using System.Collections.Generic;
namespace PizzaStore.Domain.Models
{
    public class UserModel : AModel
    {
        public string Name{get;set;}
        public List<OrderModel> Orders {get;set;}
        public override string ToString() 
        {
            return  $"User: {Name}";
        }
    }
}