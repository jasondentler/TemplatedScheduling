Feature: Template Label
	As a scheduler
	I want to manage the labels of the templates


@domain
Scenario: Change the template label
	Given I have set up a new course
	And I have created the template "Template Label Here"
	When I rename the template to "New template label"
	Then the template is renamed from "Template Label Here" to "New template label"
	And it does nothing else

@domain
Scenario: Change the template label to the same 
	Given I have set up a new course
	And I have created the template "Template Label Here"
	When I rename the template to "Template Label Here"
	Then it does nothing

