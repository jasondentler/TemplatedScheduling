Feature: CourseSetup
	As a scheduler
	I want to setup new courses

@domain
Scenario: Create a new course
	When I create a new course BIOL 1301 "Introductory Biology"
	Then the course is created
	And it does nothing else

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

@domain
Scenario: Set the course description
	Given I have created a new course
	When I change the course description to "Description goes here"
	Then the course description is set to "Description goes here"
	And it does nothing else

@domain
Scenario: Change the course description
	Given I have created a new course
	And I have changed the course description to "Description goes here"
	When I change the course description to "New description goes here"
	Then the course description is changed from "Description goes here" to "New description goes here"
	And it does nothing else

@domain 
Scenario: Change the course description to the same thing
	Given I have created a new course
	And I have changed the course description to "Description goes here"
	When I change the course description to "Description goes here"
	Then it does nothing