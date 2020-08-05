using System.Collections.Generic;

namespace PizzaStore.Storing
{
    public interface ARepository<T>
    {
        T Get(int id);
        T Get(string name);
        List<T> GetAll();
        T Find(string name);
        T Find(int id);
        void Add(T t);
        void Add(int id, string name);

        
    }
}