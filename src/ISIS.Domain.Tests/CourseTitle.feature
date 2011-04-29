Feature: Course Title
	As a scheduler
	I want to set the course title

@domain
Scenario: Change course title
	Given I have created a new course BIOL 1301 "Introductory Biology"
	When I change the course title to "New Title"
	Then the course title is changed from "Introductory Biology" to "New Title"
	And it does nothing else

@domain
Scenario: Change course title to the same title
	Given I have created a new course BIOL 1301 "Introductory Biology"
	When I change the course title to "Introductory Biology"
	Then it does nothing

