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


        [Given(@"I am delivering to a street")]
        public void GivenIAmDeliveringToAStreet()
        {
            MyStreet = Street.Parse(File.ReadAllText("street1.txt")); 
        }

        [Given(@"I am delivering west to east then east to west")]
        public void GivenIAmDeliveringWestToEastThenEastToWest()
        {
        }

        [When(@"I request my delivery list")]
        public void WhenIRequestMyDeliveryList()
        {
            route = DeliveryPlanner.GetRoute(MyStreet);
        }

        [Then(@"I am given the order in which they are to be delivered")]
        public void ThenIAmGivenTheOrderInWhichTheyAreToBeDelivered()
        {
            route = DeliveryPlanner.GetRoute(MyStreet);

            var expectedRoute = new Houses();

            expectedRoute.AddRange(MyStreet.NorthSide);

            var southSide = MyStreet.SouthSide.Select( i => i);
            
            southSide = southSide.Reverse();

            expectedRoute.AddRange(southSide);

            CollectionAssert.AreEqual(expectedRoute, route);
        }
    }
}
