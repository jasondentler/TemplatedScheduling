Feature: Instructor Setup
	As a scheduler
	I want to set up new instructors

@domain
Scenario: Set up a new instructor
	When I create a new instructor with first name "John" and last name "Smith"
	Then the instructor is created
	And the instructor's first name is "John"
	And the instructor's last name is "Smith"
	And it does nothing else

@domain
Scenario: Change instructor name
	Given I create a new instructor with first name "James" and last name "Smith"
	When I change the instructor's name to "Jimmy" "Smit"
	Then the instructor's first name is changed from "James" to "Jimmy"
	And the instructor's last name is changed from "Smith" to "Smit"
	And it does nothing else 

@domain
Scenario: Change instructor name to the same
	Given I create a new instructor with first name "James" and last name "Smith"
	When I change the instructor's name to "James" "Smith"
	Then it does nothing

@domain
Scenario: Assign a course to a instructor
	Given I have created a new instructor
	And I have set up a new course
	When I assign the course to the instructor
	Then the course is assigned to the instructor
	And it does nothing else

@domain
Scenario: Unassign a course from a instructor
	Given I have created a new instructor
	And I have set up a new course
	And I have assigned the course to the instructor
	When I unassign the course from the instructor
	Then the course is unassigned from the instructor
	And it does nothing else

@domain
Scenario: Assign an already-assigned course to a instructor
	Given I have created a new instructor
	And I have set up a new course
	And I have assigned the course to the instructor
	When I assign the course to the instructor
	Then it does nothing

@domain
Scenario: Unassign an unassigned course from a instructor
	Given I have created a new instructor
	And I have set up a new course
	When I unassign the course from the instructor
	Then it does nothing
