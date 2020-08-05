using PizzaStore.Domain.Factory;
using PizzaStore.Domain.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PizzaStore.Client.Models
{
    public class PizzaViewModel
    {
        public List<CrustModel> Crusts {get;set;}
        public List<SizeModel> Sizes {get;set;}
        public List<ToppingsModel> Toppings {get;set;} 
        public PizzaViewModel()
        {
            var crust = new CrustModel();
            crust.Name = "thin";
            crust.Description ="the worst crust ever";
            Crusts = new List<CrustModel>();
            Crusts.Add(crust);

            var size = new SizeModel();
            size.Name = "small";
            size.Diameter = 12;
            Sizes = new List<SizeModel>();
            Sizes.Add(size);

            var topping = new ToppingsModel();
            topping.Name = "cheese";
            topping.Description ="the cheesiest of toppings";
            Toppings= new List<ToppingsModel>();
            Toppings.Add(topping);

        }
        [Required]
        public string Crust {get;set;}
        [Required]
        public string Size {get;set;}
        [Range(1,5)]
        [Required]
        public List<string> SelectedToppings {get;set;}
        public bool SelectedTopping {get;set;}

        public List<PizzaModel> Cart {get;set;}
    }
}