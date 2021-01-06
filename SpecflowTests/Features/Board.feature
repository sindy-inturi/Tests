Feature: Board
Create a board and update the description

@API
Scenario Outline: Create a board and update the description
	Given A board is created with <name>
	And user updates board description using PUT method
	Then The description should updated
	Examples: 
	| name      |
	| RestSharpTest_|