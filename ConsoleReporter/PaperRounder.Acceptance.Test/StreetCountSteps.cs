using System;
using System.IO;
using System.Text;
using NUnit.Framework;
using StreetReporter;
using TechTalk.SpecFlow;

namespace PaperRounder.Acceptance.Test
{
    [Binding]
    public class StreetCountSteps
    {
        private string Filename { get; set; }
        private bool IsFileValid { get; set; }
        private int NumberOfHouses { get; set; }
        private int NorthFacing { get; set; }
        private string HouseList { get; set;  }

        [Given(@"I have a valid file called '(.*)'")]
        public void GivenIHaveAValidFileCalled(string fileName)
        {
            // This is undefined in the question, but would be elaborated in discussion with the town planner
            Filename = fileName;
            HouseList = "";
        }

        [When(@"it is submitted")]
        public void WhenItIsSubmitted()
        {
            IsFileValid = new Street().IsValid(Filename);
        }

        [Given(@"(.*) of them are north side")]
        public void GivenOfThemAreNorthSide(int northFacingHouses)
        {
            NorthFacing = northFacingHouses;
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
            HouseList = File.ReadAllText(Filename);
        }

        [When(@"requesting the number of north side houses")]
        public void WhenRequestingTheNumberOfNorthSideHouses()
        {
            var street = Street.Parse(HouseList);
            NumberOfHouses = street.NorthSide.Count;
        }


        [When(@"checking how many houses there are")]
        public void WhenCheckingHowManyHousesThereAre()
        {
            var street = Street.Parse(HouseList.ToString().Trim());
            NumberOfHouses = street.Houses.Count;
        }

        [Then(@"I am told there are (.*) houses")]
        public void ThenIAmToldThereAreHouses(int howMany)
        {
            Assert.That(NumberOfHouses, Is.EqualTo(howMany));
        }

        [Then(@"I am told there are (.*)")]
        public void ThenIAmToldThereAre(int numberOfHouses)
        {
            Assert.That(NumberOfHouses, Is.EqualTo(numberOfHouses));
        }
    }
}
