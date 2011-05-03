Feature: Template Course Type
	As a scheduler
	I want to manage the course types of templates

@domain
Scenario: Cant set course type on a CE template
	Given I have created a CE course and template
	When I change the template's course type to "General Academic"
	Then the aggregate state is invalid
	And the message is "Your attempt to change the course type failed because this is a continuing education course."
	
@domain
Scenario: Cant set CE course type on a template
	Given I have created a course and template
	When I change the template's course type to "Continuing Education"
	Then the aggregate state is invalid
	And the message is "Your attempt to change the course type failed. This course type is reserved for continuing education courses only."

@domain
Scenario: Cant set CWECM course type on a template
	Given I have created a course and template
	When I change the template's course type to "Continuing Education WECM"
	Then the aggregate state is invalid
	And the message is "Your attempt to change the course type failed. This course type is reserved for continuing education courses only."

@domain
Scenario: Set course type on a template
	Given I have created a course and template
	When I change the template's course type to "General Academic"
	Then the template's course type is changed to "General Academic"
	And it does nothing else

@domain
Scenario: Set course type to the same
	Given I have created a course and template
	And I have changed the template's course type to "General Academic"
	When I change the template's course type to "General Academic"
	Then it does nothing

