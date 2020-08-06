using PizzaStore.Domain.Factory;
using PizzaStore.Domain.Models;
using PizzaStore.Storing;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PizzaStore.Client.Models
{
    public class PizzaViewModel
    {
        // out to the client
        public List<CrustModel> Crusts { get; set; }
        public List<SizeModel> Sizes { get; set; }
        public List<ToppingsModel> Toppings { get; set; }
        public List<CheckBoxTopping> Toppings2 { get; set; }


        // in from the client
        [Required(ErrorMessage = "Better select Crust")]
        public string Crust { get; set; }
        [Required]
        public string Size { get; set; }
        [MinLength (1)]
        [MaxLength(5)]
        public List<string> SelectedToppings { get; set; }
        public List<string> SelectedToppings2 { get; set; }
        public List<PizzaModel> Cart {get;set;}

        public PizzaViewModel(PizzaStoreDBContext dbo)
        {
            var cRepo = new CrustRepository(dbo);
            Crusts = cRepo.GetAll();
            var sRepo = new SizeRepository(dbo);
            Sizes = sRepo.GetAll();
            var tRepo = new ToppingRepository(dbo);
            Toppings = tRepo.GetAll();
            Toppings2 = new List<CheckBoxTopping>();
            foreach(var t in Toppings){
                Toppings2.Add(new CheckBoxTopping() {Name = t.Name, Id = t.Id,Description = t.Description, Text = t.Name});
            }
            Cart = new List<PizzaModel>();
        }
        public PizzaViewModel()
        {
            
        }
        public void Convert(PizzaViewModel pizzaViewModel,PizzaStoreDBContext _db)
        {
            var CR = new CrustRepository(_db);
            var SR = new SizeRepository(_db);
            var PR = new PizzaRepository(_db);
            var TR = new ToppingRepository(_db);
            List<ToppingsModel> TM = new List<ToppingsModel>();
            foreach(var t in pizzaViewModel.SelectedToppings2){
                TM.Add(TR.Get(t));
            }
            var tempPizza = new PizzaModel(){Name = "custom",Description = "custom",Size = SR.Get(pizzaViewModel.Size),Crust= CR.Get(pizzaViewModel.Crust),Toppings = TM};
            pizzaViewModel.Cart.Add(tempPizza);
            PR.Add(tempPizza);
        }
    }

    public class CheckBoxTopping : ToppingsModel
    {
        public string Text { get; set; }
        public bool IsSelected { get; set; }
    }
}