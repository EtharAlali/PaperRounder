namespace StreetReporter
{
    public interface IRoutePlanner
    {
        Houses GetRoute(Street myStreet);
        int Crossings(Street myStreet);
    }
}