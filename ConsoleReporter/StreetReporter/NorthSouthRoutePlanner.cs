namespace StreetReporter
{
    public class NorthSouthRoutePlanner : IRoutePlanner
    {
        public Houses GetRoute(Street myStreet)
        {
            return myStreet.Houses;
        }

        public int Crossings(Street myStreet)
        {
            throw new System.NotImplementedException();
        }
    }
}