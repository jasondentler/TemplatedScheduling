Feature: CourseSetup
	As a scheduler
	I want to create new courses

@domain
Scenario: Create a new course
	When I create a new course BIOL 1301 "Introductory Biology"
	Then the course is created
	And it does nothing else

@domain
Scenario: Change course title
	Given I have created a new course BIOL 1301 "Introductory Biology"
	When I change the course title to "Introduction to Biology"
	Then the course title is changed from "Introductory Biology" to "Introduction to Biology"
	And it does nothing else

