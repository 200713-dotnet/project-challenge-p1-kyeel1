using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaStore.Domain.Factory;
using PizzaStore.Domain.Models;

namespace PizzaStore.Storing
{
    public class PizzaRepository : ARepository<PizzaModel>
    {
        PizzaStoreDBContext _db;
        public PizzaRepository(PizzaStoreDBContext dbContext)
        {
            
            _db = dbContext;
        }
        public void Add(PizzaModel t)
        {
            
            _db.Pizzas.Add(t);
            _db.SaveChanges();

        }

        public PizzaModel Get(string name)
        {
            var pizzaList = _db.Pizzas.Include(size => _db.Sizes.ToList()).Include(crust => _db.Crusts.ToList()).Include(toppings => _db.Toppings.ToList());
            var query = pizzaList.First(pizza => pizza.Name ==name);
            return query;
        }

        public PizzaModel Get(int id)
        {
            var pizzaList = _db.Pizzas.Include(size => _db.Sizes.ToList()).Include(crust => _db.Crusts.ToList()).Include(toppings => _db.Toppings.ToList());

            return pizzaList.FirstOrDefault(pizza => pizza.Id == id);
        }
        public List<PizzaModel> GetAllSpecialty()
        {
            return _db.Pizzas.Include(size => _db.Sizes.ToList()).Include(crust => _db.Crusts.ToList()).Include(toppings => _db.Toppings.ToList()).Where(isSpecial => isSpecial.SpecialPizza == true).ToList();
        }
        public List<PizzaModel> GetAll()
        {
            return _db.Pizzas.Include(size => _db.Sizes.ToList()).Include(crust => _db.Crusts.ToList()).Include(toppings => _db.Toppings.ToList()).ToList();

        }
        public void Remove(int id){
            var pizza = Get(id);
            if(pizza.Toppings != null){
            foreach(ToppingsModel t in pizza.Toppings)
            {
                _db.Toppings.Remove(t);
            }
            }
            _db.Pizzas.Remove(pizza);
            _db.SaveChanges();
        }
        public void Remove(string name)
        {
            var pizza = Get(name);
            foreach(ToppingsModel t in pizza.Toppings)
            {
                _db.Toppings.Remove(t);
            }
            _db.Pizzas.Remove(pizza);
            _db.SaveChanges();

        }

    }
}