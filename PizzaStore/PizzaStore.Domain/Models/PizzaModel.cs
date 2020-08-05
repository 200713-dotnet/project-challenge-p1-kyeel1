using System.Collections.Generic;

namespace PizzaStore.Domain.Models
{
    public class PizzaModel : AModel
    {
        public string Name{get;set;}
        public string Description{get;set;}
        public SizeModel Size {get;set;}
        public CrustModel Crust {get;set;}
        public List<ToppingsModel> Toppings {get;set;}
        public override string ToString(){
            string result = $"{Name} {Description} {Size.Name} {Crust.Name} Toppings:";
            foreach(ToppingsModel t in Toppings){
                result += $"{t.Name},";
            }
            return result;
        } 
    }
}