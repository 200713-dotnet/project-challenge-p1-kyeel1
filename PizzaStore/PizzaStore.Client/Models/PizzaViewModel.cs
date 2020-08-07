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
        public List<UserModel> Users{get;set;}
        public List<StoreModel> Stores{get;set;}
        public List<PizzaModel> SpecialtyPizzas {get;set;}
        public OrderModel Cart {get;set;}




        // in from the client
        [Required]
        public string Crust { get; set; }
        [Required]
        public string Size { get; set; }
        
        public List<string> SelectedToppings { get; set; }
        [MinLength (1)]
        [MaxLength(5)]
        public List<string> SelectedToppings2 { get; set; }
        [Required]
        public UserModel User {get;set;}
        [Required]
        public StoreModel Store{get;set;}
        public PizzaModel SelectedPizza{get;set;}

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
            var uRepo = new UserRepository(dbo);
            Users = uRepo.GetAll();
            var stRepo = new StoreRepository(dbo);
            Stores = stRepo.GetAll();
            var pRepo = new PizzaRepository(dbo);
            SpecialtyPizzas = pRepo.GetAllSpecialty();
        }
        public void ConvertRegular(PizzaViewModel pizzaViewModel,PizzaStoreDBContext _db)
        {
            var OR = new OrderRepository(_db);
            var CR = new CrustRepository(_db);
            var SR = new SizeRepository(_db);
            var PR = new PizzaRepository(_db);
            var TR = new ToppingRepository(_db);
            List<ToppingsModel> TM = new List<ToppingsModel>();
            foreach(var t in pizzaViewModel.SelectedToppings2){
                TM.Add(TR.Get(t));
            }
            var tempPizza = new PizzaModel(){Name = "custom",Description = "custom",Size = SR.Get(pizzaViewModel.Size),Crust= CR.Get(pizzaViewModel.Crust),Toppings = TM,SpecialPizza = false};
            var cart =OR.GetCurrentOrder();
            var OF = new OrderFactory();
            if(cart != null)
            {
                cart.Pizzas.Add(tempPizza);
            }
            else
            {
                cart = OF.Create();
                cart.Pizzas.Add(tempPizza);
                OR.Add(cart);
            }
            PR.Add(tempPizza);
        }
        public void ConvertSpecial(PizzaViewModel pizzaViewModel,PizzaStoreDBContext _db)
        {
            var CR = new CrustRepository(_db);
            var SR = new SizeRepository(_db);
            var PR = new PizzaRepository(_db);
            var TR = new ToppingRepository(_db);
            var OR = new OrderRepository(_db);
            var tempPizza = new PizzaModel(){Name = SelectedPizza.Name,Description = SelectedPizza.Description,Size = SR.Get(pizzaViewModel.Size),Crust= CR.Get(pizzaViewModel.Crust),Toppings = SelectedPizza.Toppings,SpecialPizza = true};
            var cart =OR.GetCurrentOrder();
            var OF = new OrderFactory();
            if(cart != null)
            {
                cart.Pizzas.Add(tempPizza);
            }
            else
            {
                cart = OF.Create();
                cart.Pizzas.Add(tempPizza);
                OR.Add(cart);
            }
            PR.Add(tempPizza);
        }
        public void GetCart(PizzaStoreDBContext _db)
        {
            var OF = new OrderFactory();
            var OR = new OrderRepository(_db);
            var cart =OR.GetCurrentOrder();
            if(cart != null)
            {
                Cart = cart;
            }
            else
            {
                Cart = OF.Create();
                OR.Add(Cart);
            }
        }
    }

    public class CheckBoxTopping : ToppingsModel
    {
        public string Text { get; set; }
        public bool IsSelected { get; set; }
    }
}