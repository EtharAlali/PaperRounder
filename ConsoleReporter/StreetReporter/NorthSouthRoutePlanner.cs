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
            var isEven = false;
            var countCrossings = 0;

            foreach (var house in myStreet.Houses)
            {
                if (((int.Parse(house)%2 != 0) || isEven) && ((int.Parse(house)%2 == 0) || !isEven)) continue;
                countCrossings++;
                isEven = !isEven;
            }
            return countCrossings;
        }
    }
}