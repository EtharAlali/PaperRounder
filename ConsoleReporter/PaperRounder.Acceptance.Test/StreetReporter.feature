Feature: StreetReporter
	As a town planner, 
	I want to display a report for streets
	So that I can keep track of the house numbers

Scenario: Given a file I can check it is valid
	Given I have a valid file called 'street1.txt'
	When it is submitted
	Then I can tell it is valid 
