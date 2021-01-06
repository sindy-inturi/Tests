Feature: AddListAndCard

Background: 
Given User enters Username sindyinturi@gmail.com
And User clicks on Login with Atllasian button
And User enters password Sindy93$
When User clicks on submit

@UI @deleteTestCard
Scenario: Create a new list and add card to it
	Given User goes to a board
	And User creates a new list
	And User tries to a new card
	When user saves the card
	Then card should get added to the list