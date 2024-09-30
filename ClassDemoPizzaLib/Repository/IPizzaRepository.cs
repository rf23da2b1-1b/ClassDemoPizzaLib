using ClassDemoPizzaLib.model;

namespace ClassDemoPizzaLib.Repository
{
    public interface IPizzaRepository
    {
        IPizza Delete(int id);
        List<IPizza> GetAll();
        IPizza GetById(int id);
        IPizza Opret(IPizza pizza);
        IPizza Update(int id, IPizza updatePizza);

        List<IPizza> GetSortByName();
        List<IPizza> GetByFilter(double? lowPrice = 0, double? highPrice = double.MaxValue);
    }
}