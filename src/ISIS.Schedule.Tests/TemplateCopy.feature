Feature: Template Copy
	In order to reduce data entry errors
	As a scheduler
	I want to copy templates

@domain
Scenario: Copy a template
	Given I have set up a course
	And I have set up a term
	And I have created a template "Source Template"
	And I have assigned the term to the template
	And I have activated the template
	And I have created a new instructor
	And I have assigned the course to the instructor
	And I have assigned the instructor to the template
	When I copy the template "Source Template" to "New Template"
	Then the template is created
	And the template label is "New Template"
	And the template data matches the course data
	And the term is assigned to the template
	And the template's start and end dates match the term
	And the template is activated
	And the "Source Template" template is copied to "New Template"
	And the instructor is assigned to the template
	And it does nothing else

@domain
Scenario: Cant copy an obsolete template
	Given I have set up a course
	And I have set up a term
	And I have created a template "Source Template"
	And I have assigned the term to the template
	And I have made the template obsolete
	When I copy the template "Source Template" to "New Template"
	Then the aggregate state is invalid
	And the message is "Your attempt to copy the template failed. The source template is obsolete."

@domain
Scenario: Instructor equipment is copied with the template
	Given I have set up a course and template and activated the template
	And I require 1 "PC" for the template
	When I copy the template
	Then 1 "PC" is required for the template, for a total of 1

@domain
Scenario: Student equipment is copied with the template
	Given I have set up a course and template and activated the template
	And I require 1 "PC" per student for the template
	When I copy the template
	Then 1 "PC" per student is required for the template
