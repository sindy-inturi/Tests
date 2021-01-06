Feature: Login
	User should be able to log into Trello

@UI

Scenario Outline: Application login
Given User enters Username <username>
And User clicks on Login with Atllasian button
And User enters password <password>
When User clicks on submit
Then User should go to trello homepage
Examples: 
| username              | password |
| sindyinturi@gmail.com | Sindy93$ |