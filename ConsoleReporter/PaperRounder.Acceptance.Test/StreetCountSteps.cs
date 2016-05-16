using System.Collections.Generic;
using NUnit.Framework;
using StreetReporter;
using TechTalk.SpecFlow;

namespace PaperRounder.Acceptance.Test
{
    [Binding]
    public class StreetCountSteps
    {
        private string Filename { get; set; }
        public bool IsFileValid { get; set; }
        public int NumberOfHouses { get; set; }
        private List<string> HouseList { get; set;  }

        [Given(@"I have a valid file called '(.*)'")]
        public void GivenIHaveAValidFileCalled(string fileName)
        {
            // This is undefined in the question, but would be elaborated in discussion with the town planner
            Filename = fileName;
            HouseList = new List<string>();
        }

        [When(@"it is submitted")]
        public void WhenItIsSubmitted()
        {
            IsFileValid = StreetAnalyser.IsValid(Filename);
        }


        [Then(@"I can tell it is (.*)valid")]
        public void ThenICanTellItIsValid(string not)
        {
            // Refactored the test since it's effectively the compleiment of the other
            Assert.That( IsFileValid, Is.EqualTo(not.Trim() != "not"));   
        }

        [Given(@"it contains (.*) houses")]
        public void GivenItContainsHouses(int howMany)
        {
            for(var i = 0; i < howMany; i++)
            {
                HouseList.Add("1");
            }
        }

        [When(@"checking how many houses there are")]
        public void WhenCheckingHowManyHousesThereAre()
        {
            NumberOfHouses = StreetAnalyser.CountHouses(HouseList);
        }

        [Then(@"I am told there are (.*) houses")]
        public void ThenIAmToldThereAreHouses(int howMany)
        {
            Assert.That(NumberOfHouses, Is.EqualTo(howMany));
        }
    }
}
