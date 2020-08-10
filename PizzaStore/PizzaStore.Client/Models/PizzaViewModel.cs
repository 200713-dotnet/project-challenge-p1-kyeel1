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
        
        public List<CheckBoxTopping> SelectedToppings { get; set; }
        [Required]
        public string User {get;set;}
        [Required]
        public string Store{get;set;}
        public string SelectedPizza{get;set;}
        public string Topping{get;set;}

        public PizzaViewModel(PizzaStoreDBContext dbo)
        {
            var cRepo = new CrustRepository(dbo);
            Crusts = cRepo.GetAll();
            var sRepo = new SizeRepository(dbo);
            Sizes = sRepo.GetAll();
            var tRepo = new ToppingRepository(dbo);
            Toppings = new List<ToppingsModel>();
            Toppings2 = new List<CheckBoxTopping>();
            foreach(ToppingsModel t in tRepo.GetAll()){
                Toppings.Add(t);
            }
            foreach(var t in Toppings){
                Toppings2.Add(new CheckBoxTopping() {Name = t.Name, Id = t.Id,Description = t.Description, Text = t.Name, IsSelected = false});
            }
            var uRepo = new UserRepository(dbo);
            Users = uRepo.GetAll();
            var stRepo = new StoreRepository(dbo);
            Stores = stRepo.GetAll();
            var pRepo = new PizzaRepository(dbo);
            SpecialtyPizzas = pRepo.GetAllSpecialty();
            
        }
        public PizzaViewModel(){}
        public void ConvertRegular(PizzaViewModel pizzaViewModel,PizzaStoreDBContext _db)
        {
            var UR = new UserRepository(_db);
            var STR = new StoreRepository(_db);
            var OR = new OrderRepository(_db);
            var CR = new CrustRepository(_db);
            var SR = new SizeRepository(_db);
            var PR = new PizzaRepository(_db);
            var TR = new ToppingRepository(_db);
            var PF = new PizzaFactory();
            List<ToppingsModel> TM = new List<ToppingsModel>();
            SelectedToppings = new List<CheckBoxTopping>();
            
            foreach(var t in Toppings2)
            {
                if(t.IsSelected)
                {
                    SelectedToppings.Add(t);
                }
            }
            foreach(var t in SelectedToppings){
                var throwaway = TR.Get(t.Text);
                var tempTopping = new ToppingsModel(){Name = throwaway.Name, Description = throwaway.Description};
                TM.Add(tempTopping);
            }
            
            //TM.Add(TR.Get(Topping));
            var tempPizza = PF.Create();
            tempPizza.Name ="custom";
            tempPizza.Description = "custom";
            tempPizza.Size = SR.Get(pizzaViewModel.Size);
            tempPizza.Crust= CR.Get(pizzaViewModel.Crust);
            tempPizza.Toppings = new List<ToppingsModel>();
            tempPizza.Toppings = TM;
            tempPizza.SpecialPizza = false;
            var cart =OR.GetCurrentOrder();
            var OF = new OrderFactory();
            if(cart != null)
            {
                OR.AddPizza(cart.Id,tempPizza);
            }
            else
            {
                cart = OF.Create();
                var tempUser = UR.Get(User);
                UR.AddOrder(tempUser.Id,cart);
                var tempStore = STR.Get(Store);
                STR.AddOrder(tempStore.Id,cart);
                cart.Pizzas = new List<PizzaModel>();
                cart.Pizzas.Add(tempPizza);
                OR.UpdateCurrentOrder(cart);
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
            var UR = new UserRepository(_db);
            var STR = new StoreRepository(_db);
            var PF = new PizzaFactory();
            var tempSpecialty = PF.Create();
            tempSpecialty = PR.Get(SelectedPizza);
            var tempPizza = PF.Create();
            tempPizza.Name = SelectedPizza ;
            tempPizza.Description = tempSpecialty.Description;
            tempPizza.Size = SR.Get(pizzaViewModel.Size);
            tempPizza.Crust= CR.Get(pizzaViewModel.Crust);
            tempPizza.Toppings = new List<ToppingsModel>();
            tempPizza.SpecialPizza = true;
            
            foreach(var t in tempSpecialty.Toppings)
            {
                var tempTopping = new ToppingsModel(){Name = t.Name, Description = t.Description};
                tempPizza.Toppings.Add(tempTopping);
                TR.Add(tempTopping);
            }
            
            var cart =OR.GetCurrentOrder();
            var OF = new OrderFactory();
            if(cart != null)
            {
                OR.AddPizza(cart.Id,tempPizza);
            }
            else
            {
                cart = OF.Create();
                var tempUser = UR.Get(User);
                UR.AddOrder(tempUser.Id,cart);
                var tempStore = STR.Get(Store);
                STR.AddOrder(tempStore.Id,cart);
                cart.Pizzas.Add(tempPizza);
                OR.UpdateCurrentOrder(cart);
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
        public void FinishOrder(PizzaStoreDBContext _db)
        {
            GetCart(_db);
            Cart.CurrentOrder =false;

        }
        
    }

    public class CheckBoxTopping : ToppingsModel
    {
        public string Text { get; set; }
        public bool IsSelected { get; set; }
        public override string ToString() 
        {
            return $"{Name}";
        }
    }
}