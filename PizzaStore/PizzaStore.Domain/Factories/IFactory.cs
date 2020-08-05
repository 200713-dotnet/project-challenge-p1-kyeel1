using System.Collections.Generic;
using PizzaStore.Domain.Models;
namespace PizzaStore.Domain.Factory
{
    public interface IFactory<T> where T: class,new()
    {
        T Create();
    }
}