Feature: CourseSetup
	As a scheduler
	I want to create new courses

@domain
Scenario: Create a new course
	When I create a new course BIOL 1301 "Introductory Biology"
	Then the course is created
	And it does nothing else
