Feature: Template Term
	As a scheduler
	I want to assign terms to templates

@domain
Scenario: Assign a credit term to a credit template
	Given I have set up a course and template
	And I have created a term
	When I assign the term to the template
	Then the term is assigned to the template
	And the template's start and end dates match the term
	And it does nothing else

@domain
Scenario: Assign a CE term to a CE template
	Given I have set up a CE course and template
	And I have created a CE term
	When I assign the term to the template
	Then the term is assigned to the template
	And the template's start and end dates are blank
	And it does nothing else

@domain
Scenario: Cant assign a CE term to a credit template
	Given I have created a course and template
	And I have created a CE term
	When I assign the term to the template
	Then the aggregate state is invalid
	And the message is "Your attempt to assign the term failed. The term is for continuing education only."

@domain
Scenario: Cant assign a credit term to a CE template
	Given I have created a CE course and template
	And I have created a term
	When I assign the term to the template
	Then the aggregate state is invalid
	And the message is "Your attempt to assign the term failed. The term is not for continuing education."

