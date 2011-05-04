Feature: Section setup
	As a scheduler or department chair
	I want to create sections from templates

@domain
Scenario: Create a section from a template
	Given I have set up a course and template and activated the template
	When I create a section 01 from the template
	Then section 01 is created
	And the section data matches the basic template data
	And it does nothing else

@domain
Scenario: Cant create a section from a non-active template
	Given I have set up a course and template
	And I have set up a term
	And I have assigned the term to the template
	And I have made the template pending
	When I create a section 01 from the template
	Then the aggregate state is invalid
	And the message is "Your attempt to create a section failed. The template is not active."