using System.Collections.Generic;

namespace PizzaStore.Domain.Models
{
    public class PizzaModel : AModel
    {
        public string Name{get;set;}
        public string Description{get;set;}
        public SizeModel Size {get;set;}
        public CrustModel Crust {get;set;}
        public bool SpecialPizza{get;set;}
        public List<ToppingsModel> Toppings {get;set;}

        public override string ToString(){
            string result = $"{Name}: {Description}, {Size.Name}, {Crust.Name}, Toppings:";
            foreach(ToppingsModel t in Toppings){
                result += $" {t.Name},";
            }
            result+=$" Total Price: {CalculatePricing()}";//check to see if you can do this later with fred
            return result;
        } 
        public int CalculatePricing()
        {
            int result = 0;
            result += Size.Price +Crust.Price;
            foreach(ToppingsModel t in Toppings){
                result+= t.Price;
            } 
            return result;

        }
    }
}