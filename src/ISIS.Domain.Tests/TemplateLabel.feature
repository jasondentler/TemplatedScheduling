Feature: Template Label
	As a scheduler
	I want to manage the labels of the templates


@domain
Scenario: Change the template label
	Given I have created a course
	And I have set the course CIP to 12.3456
	And I have set the course description to "Description goes here"
	And I have created the template "Template Label Here"
	When I rename the template to "New template label"
	Then the template label is changed
	And it does nothing else

@domain
Scenario: Change the template label to the same 
	Given I have created a course
	And I have set the course CIP to 12.3456
	And I have set the course description to "Description goes here"
	And I have created the template "Template Label Here"
	When I rename the template to "Template Label Here"
	Then it does nothing

