Feature: TMTests

This feature tests create, edit and delete functionality of TurnUp Portal.

@tag1
Scenario: Verify user is able to create a TM record
	Given user logs into Turn Up Portal
	And  user navigates to TM Page
	When user creates a new TM record 
	Then verify TM record is created

	Scenario: Verify user is able to edit a TM record
	Given user logs into Turn Up Portal
	And  user navigates to TM Page
	When user edits an existing record 
	Then verify TM record is edited

	Scenario: Verify user is able to delete a TM record
	Given user logs into Turn Up Portal
	And  user navigates to TM Page
	When user deletes an existing record
	Then verify TM record is created




