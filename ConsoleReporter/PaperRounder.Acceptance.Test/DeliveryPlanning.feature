Feature: DeliveryPlanning
	As a paper-person
	I want to know the order of house numbers

Scenario: Delivering to a street with north and south sides I know the number of times I need to cross the road
	Given I am delivering to a street
		And I am delivering west to east then east to west 
	When I request my delivery list
	Then I am given the order in which they are to be delivered
		And I cross the road 1 time
