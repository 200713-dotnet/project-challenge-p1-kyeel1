using System.Collections.Generic;
namespace PizzaStore.Domain.Models
{
    public class StoreModel : AModel
    {
        public string Name{get;set;}
        public string Description{get;set;}
        public List<OrderModel> Orders {get;set;}
        public bool CurrentStore {get;set;}
        
        public override string ToString()
        {
            //return $"{Name}: {Description}";
            return $"{Name}";
        }
        public int CalculateSales()
        {
            int result = 0;
            foreach(OrderModel o in Orders){
                result+= o.CalculatePrice();
            }
            return result;
        }
        
    }
}