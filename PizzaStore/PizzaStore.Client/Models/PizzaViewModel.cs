using PizzaStore.Domain.Factory;
using PizzaStore.Domain.Models;
using PizzaStore.Storing;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PizzaStore.Client.Models
{
    public class PizzaViewModel
    {
        public List<CrustModel> Crusts {get;set;}
        public List<SizeModel> Sizes {get;set;}
        public List<ToppingsModel> Toppings {get;set;} 
        public PizzaViewModel(PizzaStoreDBContext dbo)
        {
            var cRepo = new CrustRepository(dbo);
            Crusts = cRepo.GetAll();
            var sRepo = new SizeRepository(dbo);
            Sizes = sRepo.GetAll();
            var tRepo = new ToppingRepository(dbo);
            Toppings = tRepo.GetAll();
        }
        [Required]
        public string Crust {get;set;}
        [Required]
        public string Size {get;set;}
        [Range(1,5)]
        [Required]
        public List<string> SelectedToppings { get; set; }
        public bool SelectedTopping {get;set;}

        public List<PizzaModel> Cart {get;set;}
    }
}