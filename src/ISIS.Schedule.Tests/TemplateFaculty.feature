Feature: Assign faculty to templates
	As a scheduler
	I want to assign faculty to templates

@domain
Scenario: Assign a faculty member to a template
	Given I have set up a new faculty member
	And I have set up a course and template and I have activated the template
	And I have assigned the course to the faculty member
	When I assign the faculty member to the template
	Then the faculty member is assigned to the template
	And it does nothing else

@domain
Scenario: Unassign a faculty member from a template
	Given I have set up a new faculty member
	And I have set up a course and template and I have activated the template
	And I have assigned the course to the faculty member
	And I have assigned the faculty member to the template
	When I unassign the faculty member from the template
	Then the faculty member is unassigned from the template
	And it does nothing else

@domain
Scenario: Assign a faculty member to a template twice does nothing
	Given I have set up a new faculty member
	And I have set up a course and template and I have activated the template
	And I have assigned the course to the faculty member
	And I have assigned the faculty member to the template
	When I assign the faculty member to the template
	Then it does nothing

@domain
Scenario: Unassign an unassigned faculty member from a template
	Given I have set up a new faculty member
	And I have set up a course and template and I have activated the template
	And I have assigned the course to the faculty member
	When I unassign the faculty member from the template
	Then it does nothing


