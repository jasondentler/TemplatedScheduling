Feature: Section Instructor
	As a scheduler
	I want to assign instructors to sections

@domain
Scenario: Assign a instructor to a section
	Given I have set up a new course, template, instructor, and section
	When I assign the instructor to the section
	Then the instructor is assigned to the section
	And it does nothing else

@domain
Scenario: Unassign a instructor from a section
	Given I have set up a new course, template, instructor, and section
	And I have assigned the instructor to the section
	When I unassign the instructor from the section
	Then the instructor is unassigned from the section
	And it does nothing else

@domain
Scenario: Assign a instructor to a section twice does nothing
	Given I have set up a new course, template, instructor, and section
	And I have assigned the instructor to the section
	When I assign the instructor to the section
	Then it does nothing

@domain
Scenario: Cant assign instructors to a section when the course isnt assigned
	Given I have set up a new course, template, instructor, and section
	And I have unassigned the course from the instructor
	When I assign the instructor to the section
	Then the aggregate state is invalid
	And the message is "Your attempt to assign an instructor to this section failed. This instructor isn't assigned this course."