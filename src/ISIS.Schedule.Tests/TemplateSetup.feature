Feature: Template Setup
	As a scheduler
	I want to setup new section templates

@domain
Scenario: Create a template
	Given I have set up a new course
	When I create the template "Template Label Here"
	Then the template is created
	And the template label is "Template Label Here"
	And the template data matches the course data
	And it does nothing else

@domain
Scenario: Template requires course title
	Given I have created a course
	And I have set the course description to "Description goes here"
	When I create the template
	Then the aggregate state is invalid
	And the message is "Your attempt to create a template failed because the course is missing a title."

@domain
Scenario: Template requires course description
	Given I have created a course
	And I have renamed the course to "Course Title Here"
	When I create the template
	Then the aggregate state is invalid
	And the message is "Your attempt to create a template failed because the course is missing a description."

@domain
Scenario: Instructor equipment is copied from the course to the template
	Given I have set up a new course
	And I require 1 "PC" for the course
	When I create the template
	Then 1 "PC" is required for the template, for a total of 1

@domain
Scenario: Student equipment is copied from the course to the template
	Given I have set up a new course
	And I require 1 "PC" per student for the course
	When I create the template
	Then 1 "PC" per student is required for the template

