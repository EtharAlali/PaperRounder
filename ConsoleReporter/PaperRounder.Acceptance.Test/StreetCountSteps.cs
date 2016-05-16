using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using StreetReporter;
using TechTalk.SpecFlow;

namespace PaperRounder.Acceptance.Test
{
    [Binding]
    public class StreetCountSteps
    {
        private string TestStreets{ get; set; }
        private string Filename { get; set; }
        public bool IsFileValid { get; set; }

        [Given(@"I have a valid file called '(.*)'")]
        public void GivenIHaveAValidFileCalled(string fileName)
        {
            // This is undefined in the question, but would be elaborated in discussion with the town planner
            Filename = fileName;
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
    }
}
