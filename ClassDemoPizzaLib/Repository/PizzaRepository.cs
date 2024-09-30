using ClassDemoPizzaLib.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDemoPizzaLib.Repository
{
    public class PizzaRepository : IPizzaRepository
    {
        private readonly List<IPizza> _data;

        public PizzaRepository(bool mockData)
        {
            _data = new List<IPizza>();

            if (mockData)
            {
                PopulateList();
            }
        }

        private void PopulateList()
        {

            _data.Add(new Pizza1(1, "peter", "den gode pizza", 45));
            _data.Add(new Pizza1(2, "martin", "valhal pizza", 56));
            _data.Add(new Pizza1(3, "jesper", "greve pizza", 35));
            _data.Add(new Pizza1(4, "anders", "balders pizza", 46));
            _data.Add(new Pizza1(5, "vibeke", "vanløse pizza", 55));

        }

        /*
         * CRUD
         */
        public List<IPizza> GetAll()
        {
            return new List<IPizza>(_data);
        }

        public IPizza GetById(int id)
        {
            IPizza? pizza = _data.Find(p => p.Id == id);
            if (pizza == null)
            {
                throw new KeyNotFoundException();
            }
            return pizza;
        }

        public IPizza Opret(IPizza pizza)
        {
            pizza.Id = GenNextId();
            _data.Add(pizza);
            return pizza;
        }

        public IPizza Delete(int id)
        {
            IPizza pizza = GetById(id);
            _data.Remove(pizza);
            return pizza;
        }

        public IPizza Update(int id, IPizza updatePizza)
        {
            IPizza pizza = GetById(id);
            int ixOfPizza = _data.IndexOf(pizza);
            _data[ixOfPizza] = updatePizza;
            return updatePizza;
        }


        private int GenNextId()
        {
            return (_data.Count == 0) ? 1 : _data.Max(p => p.Id) + 1;
        }

        public List<IPizza> GetSortByName()
        {
            List<IPizza> pizzas = new List<IPizza>(_data);
            pizzas.Sort(SortByName);
            return pizzas;
        }

        private int SortByName(IPizza x, IPizza y)
        {
            return x.Name.CompareTo(y.Name);
        }

        public List<IPizza> GetByFilter(double? lowPrice = 0, double? highPrice = double.MaxValue)
        {
            List<IPizza> pizzas = new List<IPizza>(_data);
            if (lowPrice is null) lowPrice = 0;
            if (highPrice is null) highPrice = double.MaxValue;
            return pizzas.Where(p => lowPrice <= p.Price && p.Price <= highPrice).ToList(); 
        }
    }
}
