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
            _data.Add(new Pizza1(1, "peters", "den gode pizza", 45));
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
    }
}
