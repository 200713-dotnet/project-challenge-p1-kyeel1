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
            return _db.Pizzas.Find(id);
        }
        public List<PizzaModel> GetAllSpecialty()
        {
            return _db.Pizzas.Include(size => _db.Sizes.ToList()).Include(crust => _db.Crusts.ToList()).Include(toppings => _db.Toppings.ToList()).Where(isSpecial => isSpecial.SpecialPizza == true).ToList();
        }
        public List<PizzaModel> GetAll()
        {
            return _db.Pizzas.Include(size => _db.Sizes.ToList()).Include(crust => _db.Crusts.ToList()).Include(toppings => _db.Toppings.ToList()).ToList();

        }
    }
}