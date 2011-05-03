Feature: Template Credit Type
	As a scheduler
	I want to manage the credit types of templates

@domain
Scenario: Cant set credit type on a non-CE course
	Given I have created a course and template
	When I change the template's credit type to "Contract Training Funded"
	Then the aggregate state is invalid
	And the message is "Your attempt to change the credit type failed because this is not a continuing education course."
	

@domain
Scenario: Set the credit type to Contract Training Funded
	Given I have created a CE course and template
	When I change the template's credit type to "Contract Training Funded"
	Then the template's credit type is changed to "Contract Training Funded"
	And the template's course type is changed to "Continuing Education WECM"
	And it does nothing else

@domain
Scenario: Set the credit type to Grant Funded
	Given I have created a CE course and template
	When I change the template's credit type to "Grant Funded"
	Then the template's credit type is changed to "Grant Funded"
	And the template's course type is changed to "Continuing Education WECM"
	And it does nothing else

@domain
Scenario: Set the credit type to Workforce Funded
	Given I have created a CE course and template
	When I change the template's credit type to "Workforce Funded"
	Then the template's credit type is changed to "Workforce Funded"
	And the template's course type is changed to "Continuing Education WECM"
	And it does nothing else

@domain
Scenario: Set the credit type to Contract Training Non-Funded
	Given I have created a CE course and template
	When I change the template's credit type to "Contract Training Non-Funded"
	Then the template's credit type is changed to "Contract Training Non-Funded"
	And the template's course type is changed to "Continuing Education"
	And it does nothing else

@domain
Scenario: Set the credit type to Special Interests
	Given I have created a CE course and template
	When I change the template's credit type to "Special Interests"
	Then the template's credit type is changed to "Special Interests"
	And the template's course type is changed to "Continuing Education"
	And it does nothing else

@domain
Scenario: Set the credit type to Grant Non-Funded
	Given I have created a CE course and template
	When I change the template's credit type to "Grant Non-Funded"
	Then the template's credit type is changed to "Grant Non-Funded"
	And the template's course type is changed to "Continuing Education"
	And it does nothing else

@domain
Scenario: Set the credit type to Workforce Non-Funded
	Given I have created a CE course and template
	When I change the template's credit type to "Workforce Non-Funded"
	Then the template's credit type is changed to "Workforce Non-Funded"
	And the template's course type is changed to "Continuing Education"
	And it does nothing else

@domain
Scenario: Change the credit type from one funded to another
	Given I have created a CE course and template
	And I have changed the template's credit type to "Workforce Funded"
	And I have changed the template's course type to "Continuing Education WECM"
	When I change the template's credit type to "Grant Funded"
	Then the template's credit type is changed to "Grant Funded"
	And it does nothing else

@domain
Scenario: Change the credit type from one non-funded to another
	Given I have created a CE course and template
	And I have changed the template's credit type to "Workforce Non-Funded"
	And I have changed the template's course type to "Continuing Education"
	When I change the template's credit type to "Grant Non-Funded"
	Then the template's credit type is changed to "Grant Non-Funded"
	And it does nothing else

@domain
Scenario: Change the credit type from funded to non-funded
	Given I have created a CE course and template
	And I have changed the template's credit type to "Workforce Funded"
	And I have changed the template's course type to "Continuing Education WECM"
	When I change the template's credit type to "Workforce Non-Funded"
	Then the template's credit type is changed to "Workforce Non-Funded"
	And the template's course type is changed to "Continuing Education"
	And it does nothing else

@domain
Scenario: Change the credit type from non-funded to funded
	Given I have created a CE course and template
	And I have changed the template's credit type to "Workforce Non-Funded"
	And I have changed the template's course type to "Continuing Education"
	When I change the template's credit type to "Workforce Funded"
	Then the template's credit type is changed to "Workforce Funded"
	And the template's course type is changed to "Continuing Education WECM"
	And it does nothing else

@domain
Scenario: Change the credit type to the same
	Given I have created a CE course and template
	And I have changed the template's credit type to "Workforce Non-Funded"
	And I have changed the template's course type to "Continuing Education"
	When I change the template's credit type to "Workforce Non-Funded"
	Then it does nothing
