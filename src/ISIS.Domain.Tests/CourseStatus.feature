Feature: Course Status
	As a scheduler
	I want to manage the status of courses

@domain
Scenario: Activate a course
	Given I have created a course
	And I have set the course CIP to 12.3456
	And I have set the course description to "Description goes here"
	When I activate the course
	Then the course is activated
	And it does nothing else

@domain
Scenario: Can't activate a course without a CIP
	Given I have created a course
	And I have set the course description to "Description goes here"
	When I activate the course
	Then the aggregate state is invalid
	And the message is "Your attempt to activate the course failed because the course is missing a CIP."

@domain
Scenario: Can't activate a course without a description
	Given I have created a course
	And I have set the course CIP to 12.3456
	When I activate the course
	Then the aggregate state is invalid
	And the message is "Your attempt to activate the course failed because the course is missing a description."
