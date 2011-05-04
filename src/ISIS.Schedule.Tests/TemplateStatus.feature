Feature: Template Status
	As a scheduler
	I want to manage the status of templates

@domain
Scenario: New templates are pending
	Given I have created a course and template
	When I make the template pending
	Then it does nothing

@domain
Scenario: Activate a template
	Given I have created a course and template
	When I activate the template
	Then the template is activated
	And it does nothing else

@domain
Scenario: Activate an already-active template
	Given I have created a course and template and activated the template
	When I activate the template
	Then it does nothing

@domain
Scenario: Make a template pending
	Given I have created a course and template and activated the template
	When I make the template pending
	Then the template is made pending
	And it does nothing else

@domain
Scenario: Make a pending template pending
	Given I have created a course and template and activated the template
	And I have made the template pending
	When I make the template pending
	Then it does nothing

@domain
Scenario: Deactivate a pending template
	Given I have created a course and template
	When I deactivate the template
	Then the template is deactivated
	And it does nothing else

@domain
Scenario: Deactivate an active template
	Given I have created a course and template and activated the template
	When I deactivate the template
	Then the template is deactivated
	And it does nothing else

@domain 
Scenario: Deactivate a deactive template
	Given I have created a course and template
	And I have deactivated a template
	When I deactivate the template
	Then it does nothing

@domain 
Scenario: Deactivate an obsolete course
	Given I have created a course and template
	And I have made the template obsolete
	When I deactivate the template
	Then the template is deactivated
	And it does nothing else 

@domain
Scenario: Make a pending template obsolete
	Given I have created a course and template
	When I make the template obsolete
	Then the template is made obsolete
	And it does nothing else

@domain
Scenario: Make an active course obsolete
	Given I have created a course and template and activated the template
	When I make the template obsolete
	Then the template is made obsolete
	And it does nothing else

@domain 
Scenario: Make a deactive template obsolete
	Given I have created a course and template
	And I have deactivated a template
	When I make the template obsolete
	Then the template is made obsolete
	Then it does nothing else

@domain 
Scenario: Make an obsolete template obsolete
	Given I have created a course and template
	And I have made the template obsolete
	When I make the template obsolete
	Then it does nothing
