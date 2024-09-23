namespace ClassDemoPizzaLib.model
{
    public interface IPizza
    {
        string Description { get; set; }
        int Id { get; set; }
        string Name { get; set; }
        double Price { get; set; }
    }
}