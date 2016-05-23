using System.Linq;

namespace StreetReporter
{
    public class EastToWestRoutePlanner
    {
        public Houses GetRoute(Street myStreet)
        {
            var result = new Houses();

            result.AddRange(myStreet.NorthSide);
            var southSide = myStreet.SouthSide.Select(i => i);
            
            southSide = southSide.Reverse();
            result.AddRange(southSide);

            return result;
        }

        public int Crossings(Street myStreet)
        {
            return 1;
        }
    }
}