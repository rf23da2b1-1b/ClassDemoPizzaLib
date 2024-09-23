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
    }
}