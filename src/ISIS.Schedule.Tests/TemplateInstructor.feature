Feature: Assign instructors to templates
	As a scheduler
	I want to assign instructors to templates

@domain
Scenario: Assign a instructor to a template
	Given I have set up a new instructor
	And I have set up a course and template and I have activated the template
	And I have assigned the course to the instructor
	When I assign the instructor to the template
	Then the instructor is assigned to the template
	And it does nothing else

@domain
Scenario: Unassign a instructor from a template
	Given I have set up a new instructor
	And I have set up a course and template and I have activated the template
	And I have assigned the course to the instructor
	And I have assigned the instructor to the template
	When I unassign the instructor from the template
	Then the instructor is unassigned from the template
	And it does nothing else

@domain
Scenario: Assign a instructor to a template twice does nothing
	Given I have set up a new instructor
	And I have set up a course and template and I have activated the template
	And I have assigned the course to the instructor
	And I have assigned the instructor to the template
	When I assign the instructor to the template
	Then it does nothing

@domain
Scenario: Unassign an unassigned instructor from a template
	Given I have set up a new instructor
	And I have set up a course and template and I have activated the template
	And I have assigned the course to the instructor
	When I unassign the instructor from the template
	Then it does nothing


