Feature: Course Description
	As a scheduler
	I want to set the course description
	
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