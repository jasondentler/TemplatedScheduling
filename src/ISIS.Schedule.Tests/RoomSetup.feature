Feature: Room Setup
	As a scheduler
	I want to set up rooms

@domain
Scenario: Create a room
	When I create the room A-123
	Then the room A-123 is created
	And it does nothing else

@domain
Scenario: Add new equipment to room
	Given I have created a room
	When I add 15 student PCs to the room
	Then 15 student PCs are added to the room for a total of 15
	And it does nothing else

@domain
Scenario: Add additional equipment to room
	Given I have created a room
	And I have added 15 student PCs to the room for a total of 15
	When I add 5 student PCs to the room
	Then 5 student PCs are added to the room for a total of 20
	And it does nothing else

@domain
Scenario: Remove some equipment from room
	Given I have created a room
	And I have added 15 student PCs to the room for a total of 15
	When I remove 5 student PCs from the room
	Then 5 student PCs are removed from the room for a total of 10
	And it does nothing else

@domain
Scenario: Remove all equipment from room
	Given I have created a room
	And I have added 15 student PCs to the room for a total of 15
	When I remove 15 student PCs from the room
	Then 15 student PCs are removed from the room for a total of 0
	And it does nothing else

@domain
Scenario: Remove equipment that doesnt exist
	Given I have created a room
	When I remove 15 student PCs from the room
	Then the aggregate state is invalid 
	And the message is "Your attempt to equipment failed. This room doesn't have 15 student PCs."