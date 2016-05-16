Feature: StreetReporter
	As a town planner, 
	I want to display a report for streets
	So that I can keep track of the house numbers

Scenario: Given a file I can check it is valid
	Given I have a valid file called 'street1.txt'
	When it is submitted
	Then I can tell it is valid 

# Let's now change this internally, as the code is poor, since the test isn't real code!
Scenario: Given a non-existent file I am prompted that it is not valid
	Given I have a valid file called 'street3.txt'
	When it is submitted
	Then I can tell it is not valid 