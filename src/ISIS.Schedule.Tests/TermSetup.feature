Feature: Term Setup
	As a scheduler
	I want to set up new terms

@domain
Scenario: Create a term
	When I create a term 211FA "2011 Fall 16-week" from 9/1/2011 to 12/1/2011
	Then the term is created
	And the term abbreviation is 211FA
	And the term name is "2011 Fall 16-week"
	And the term start date is 9/1/2011
	And the term end date is 12/1/2011
	And it does nothing else

