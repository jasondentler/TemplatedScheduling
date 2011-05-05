Feature: Faculty Setup
	As a scheduler
	I want to set up new faculty members

@domain
Scenario: Set up a new faculty member
	When I create a new faculty member with first name "John" and last name "Smith"
	Then the faculty member is created
	And the faculty member's first name is "John"
	And the faculty member's last name is "Smith"
	And it does nothing else

@domain
Scenario: Change faculty name
	Given I create a new faculty member with first name "James" and last name "Smith"
	When I change the faculty name to "Jimmy" "Smit"
	Then the faculty first name is changed from "James" to "Jimmy"
	And the faculty last name is changed from "Smith" to "Smit"
	And it does nothing else 

@domain
Scenario: Change faculty name to the same
	Given I create a new faculty member with first name "James" and last name "Smith"
	When I change the faculty name to "James" "Smith"
	Then it does nothing

@domain
Scenario: Assign a course to a faculty member
	Given I have created a new faculty member
	And I have set up a new course
	When I assign the course to the faculty member
	Then the course is assigned to the faculty member
	And it does nothing else

@domain
Scenario: Unassign a course from a faculty member
	Given I have created a new faculty member
	And I have set up a new course
	And I have assigned the course to the faculty member
	When I unassign the course from the faculty member
	Then the course is unassigned from the faculty member
	And it does nothing else

@domain
Scenario: Assign an already-assigned course to a faculty member
	Given I have created a new faculty member
	And I have set up a new course
	And I have assigned the course to the faculty member
	When I assign the course to the faculty member
	Then it does nothing

@domain
Scenario: Unassign an unassigned course from a faculty member
	Given I have created a new faculty member
	And I have set up a new course
	When I unassign the course from the faculty member
	Then it does nothing
