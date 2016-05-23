using System.IO;
using System.Linq;
using NUnit.Framework;
using StreetReporter;
using TechTalk.SpecFlow;

namespace PaperRounder.Acceptance.Test
{
    [Binding]
    public class DeliverySteps
    {
        private Street MyStreet;
        private Houses route;
        private IRoutePlanner _routePlanner;

        [Given(@"I am delivering to a street")]
        public void GivenIAmDeliveringToAStreet()
        {
            MyStreet = Street.Parse(File.ReadAllText("street1.txt")); 
        }

        [Given(@"I am delivering crossing the road as I find the houses")]
        public void GivenIAmDeliveringCrossingTheRoadAsIFindTheHouses()
        {
            _routePlanner = new NorthSouthRoutePlanner();
        }

        [Given(@"I am delivering west to east then east to west")]
        public void GivenIAmDeliveringWestToEastThenEastToWest()
        {
            _routePlanner = new EastToWestRoutePlanner();
        }

        [When(@"I request my delivery list")]
        public void WhenIRequestMyDeliveryList()
        {
            

            route = _routePlanner.GetRoute(MyStreet);
        }

        [Then(@"I am given the order in which they are to be delivered")]
        public void ThenIAmGivenTheOrderInWhichTheyAreToBeDelivered()
        {
            route = _routePlanner.GetRoute(MyStreet);

            var expectedRoute = new Houses();

            if (_routePlanner is EastToWestRoutePlanner)
            {
                expectedRoute.AddRange(MyStreet.NorthSide);

                var southSide = MyStreet.SouthSide.Select(i => i);

                southSide = southSide.Reverse();

                expectedRoute.AddRange(southSide);
            }
            else
            {
                expectedRoute = MyStreet.Houses;
            }
            CollectionAssert.AreEqual(expectedRoute, route);
        }

        [Then(@"I cross the road (.*) time")]
        public void ThenICrossTheRoadTime(int crossesTheRoad)
        {
            Assert.That(_routePlanner.Crossings(MyStreet), Is.EqualTo(crossesTheRoad));
        }
    }
}
