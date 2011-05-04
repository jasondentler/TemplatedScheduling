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

