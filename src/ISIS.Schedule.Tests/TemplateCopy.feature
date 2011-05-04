Feature: Template Copy
	In order to reduce data entry errors
	As a scheduler
	I want to copy templates

@domain
Scenario: Copy a template
	Given I have set up a course
	And I have set up a term
	And I have created a template "Source Template"
	When I copy the template "Source Template" to "New Template"
	Then the template "Source Template" is copied to "New Template"
	And it does nothing else