using System.Linq;

namespace StreetReporter
{
    public class DeliveryPlanner
    {
        public static Houses GetRoute(Street myStreet)
        {
            var result = new Houses();

            result.AddRange(myStreet.NorthSide);
            var southSide = myStreet.SouthSide.Select(i => i);
            
            southSide = southSide.Reverse();
            result.AddRange(southSide);

            return result;
        }

        public static int Crossings(Street myStreet)
        {
            return 1;
        }
    }
}