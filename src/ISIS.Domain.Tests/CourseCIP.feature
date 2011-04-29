Feature: Course CIP
	As a scheduler
	I want to set the course CIP

@domain
Scenario: Set the course CIP
	Given I have created a new course
	When I change the course CIP to 12.3456
	Then the course CIP is set to 12.3456
	And it does nothing else

@domain
Scenario: Set the course 10-digit CIP
	Given I have created a new course
	When I change the course CIP to 1234567890
	Then the course CIP is set to 1234567890
	And it does nothing else

@domain
Scenario: Set the course CIP to the same thing
	Given I have created a new course
	And I have changed the course CIP to 12.3456
	When I change the course CIP to 12.3456
	Then it does nothing
