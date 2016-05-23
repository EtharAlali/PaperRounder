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
        private Street _myStreet;
        private Houses _route;
        private IRoutePlanner _routePlanner;

        [Given(@"I am delivering to a street")]
        public void GivenIAmDeliveringToAStreet()
        {
            _myStreet = Street.Parse(File.ReadAllText("street1.txt")); 
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
            _route = _routePlanner.GetRoute(_myStreet);
        }

        [Then(@"I am given the order in which they are to be delivered")]
        public void ThenIAmGivenTheOrderInWhichTheyAreToBeDelivered()
        {
            _route = _routePlanner.GetRoute(_myStreet);

            var expectedRoute = new Houses();

            if (_routePlanner is EastToWestRoutePlanner)
            {
                expectedRoute.AddRange(_myStreet.NorthSide);

                var southSide = _myStreet.SouthSide.Select(i => i);

                southSide = southSide.Reverse();

                expectedRoute.AddRange(southSide);
            }
            else
            {
                expectedRoute = _myStreet.Houses;
            }
            CollectionAssert.AreEqual(expectedRoute, _route);
        }

        [Then(@"I cross the road (.*) time")]
        [Then(@"I cross the road (.*) times")]

        public void ThenICrossTheRoadTime(int crossesTheRoad)
        {
            Assert.That(_routePlanner.Crossings(_myStreet), Is.EqualTo(crossesTheRoad));
        }
    }
}
