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

Scenario: Given a file with 14 houses in I am told how many are on the north side
	Given I have a valid file called 'street1.txt'
		And it contains 14 houses
		And 8 of them are north side
	When requesting the number of north side houses
	Then I am told there are 8


Scenario: Given a file with 14 houses in I am told how many are on the south side
	Given I have a valid file called 'street1.txt'
		And it contains 14 houses
		And 6 of them are south side
	When requesting the number of south side houses
	Then I am told there are 6