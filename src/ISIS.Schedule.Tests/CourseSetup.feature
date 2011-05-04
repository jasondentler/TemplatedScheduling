Feature: New Course Setup
	As a scheduler
	I want to setup new courses

@domain
Scenario: Create a new course
	When I create a new course BIOL 1301
	Then the course is created
	And it does nothing else

@domain
Scenario: Create a new CE course
	When I create a new course BIOL 1001
	Then the CE course is created
	And it does nothing else