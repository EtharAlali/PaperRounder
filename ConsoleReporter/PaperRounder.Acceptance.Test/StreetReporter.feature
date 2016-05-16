Feature: StreetReporter
	As a town planner, 
	I want to display a report for streets
	So that I can keep track of the house numbers

Scenario: Given a file I can check it is valid
	Given I have a valid file called 'street1.txt'
	When it is submitted
	Then I can tell it is valid 


Scenario: Given a non-existent file I am prompted that it is not valid
	Given I have a valid file called 'street3.txt'
	When it is submitted
	Then I can tell it is not valid 

Scenario: Given I have a file with 14 houses in it I am told there are 14 houses
	Given I have a valid file called 'street1.txt'
		And it contains 14 houses
	When checking how many houses there are
	Then I am told there are 14 houses 