using System;
using PizzaStore.Domain.Models;
using PizzaStore.Storing;
using Xunit;
using Microsoft.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace PizzaStore.Testing
{
    public class RepositoryTests
    {
        private static readonly SqliteConnection _connection = new SqliteConnection("Data Source=:memory:");
        private static readonly DbContextOptions<PizzaStoreDBContext> _options = new DbContextOptionsBuilder<PizzaStoreDBContext>().UseSqlite(_connection).Options;
        PizzaStoreDBContext dbo = new PizzaStoreDBContext(_options);
        [Fact]
        public async void TestPizzaRepositoryAdd()
        {   
            await _connection.OpenAsync();
            await dbo.Database.EnsureCreatedAsync();
            PizzaModel tempPizza = new PizzaModel(){Crust = new CrustModel{Name="garlic",Description="delicousness"},Size = new SizeModel{Name = "large",Diameter = 16},Toppings = new System.Collections.Generic.List<ToppingsModel>{new ToppingsModel{Name = "onions",Description= "they have layers"}},Name = "shrek",Description="right form the swamp",SpecialPizza = true};
            PizzaRepository PR = new PizzaRepository(dbo);
            PR.Add(tempPizza);
            Assert.NotNull(dbo.Pizzas.FirstOrDefaultAsync(pizza => pizza.Name == tempPizza.Name));
        }
        [Fact]
        public async void TestPizzaRepositoryGetString()
        {   
            await _connection.OpenAsync();
            await dbo.Database.EnsureCreatedAsync();
            PizzaModel tempPizza = new PizzaModel(){Crust = new CrustModel{Name="garlic",Description="delicousness"},Size = new SizeModel{Name = "large",Diameter = 16},Toppings = new System.Collections.Generic.List<ToppingsModel>{new ToppingsModel{Name = "onions",Description= "they have layers"}},Name = "shrek",Description="right form the swamp",SpecialPizza = true};
            dbo.Pizzas.Add(tempPizza);
            dbo.SaveChanges();
            PizzaRepository PR = new PizzaRepository(dbo);
            
            Assert.NotNull(PR.Get(tempPizza.Name));
        }
        [Fact]
        public async void TestPizzaRepositoryGetID()
        {   
            await _connection.OpenAsync();
            await dbo.Database.EnsureCreatedAsync();
            PizzaModel tempPizza = new PizzaModel(){Crust = new CrustModel{Name="garlic",Description="delicousness"},Size = new SizeModel{Name = "large",Diameter = 16},Toppings = new System.Collections.Generic.List<ToppingsModel>{new ToppingsModel{Name = "onions",Description= "they have layers"}},Name = "shrek",Description="right form the swamp",SpecialPizza = true};
            dbo.Pizzas.Add(tempPizza);
            dbo.SaveChanges();
            PizzaRepository PR = new PizzaRepository(dbo);
            
            Assert.NotNull(PR.Get(tempPizza.Id));
        }
        [Fact]
        public async void TestPizzaRepositoryGetAll()
        {   
            await _connection.OpenAsync();
            await dbo.Database.EnsureCreatedAsync();
            PizzaModel tempPizza = new PizzaModel(){Crust = new CrustModel{Name="garlic",Description="delicousness"},Size = new SizeModel{Name = "large",Diameter = 16},Toppings = new System.Collections.Generic.List<ToppingsModel>{new ToppingsModel{Name = "onions",Description= "they have layers"}},Name = "shrek",Description="right form the swamp",SpecialPizza = true};
            dbo.Pizzas.Add(tempPizza);
            dbo.SaveChanges();
            PizzaRepository PR = new PizzaRepository(dbo);
            
            Assert.NotNull(PR.GetAll());
        }
        [Fact]
        public async void TestPizzaRepositoryGetAllSpecialty()
        {   
            await _connection.OpenAsync();
            await dbo.Database.EnsureCreatedAsync();
            PizzaModel tempPizza = new PizzaModel(){Crust = new CrustModel{Name="garlic",Description="delicousness"},Size = new SizeModel{Name = "large",Diameter = 16},Toppings = new System.Collections.Generic.List<ToppingsModel>{new ToppingsModel{Name = "onions",Description= "they have layers"}},Name = "shrek",Description="right form the swamp",SpecialPizza = true};
            dbo.Pizzas.Add(tempPizza);
            dbo.SaveChanges();
            PizzaRepository PR = new PizzaRepository(dbo);
            
            Assert.NotNull(PR.GetAllSpecialty());
        }
        
        /*
        T Get(int id);
        T Get(string name);
        List<T> GetAll();
        T Find(string name);
        T Find(int id);
        void Add(T t);
        void Add(int id, string name);
        */
    }
}
