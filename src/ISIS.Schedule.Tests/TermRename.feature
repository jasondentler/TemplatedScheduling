Feature: Term Rename
	As a scheduler
	I want to rename terms

@domain
Scenario: Rename a term
	Given I created a term 211FA "2011 Fall 16-week" from 9/1/2011 to 12/1/2011
	When I rename the term to "Fall 2011 16-week"
	Then the term is renamed from "2011 Fall 16-week" to "Fall 2011 16-week"
	And it does nothing else

@domain
Scenario: Rename a term to the same
	Given I created a term 211FA "2011 Fall 16-week" from 9/1/2011 to 12/1/2011
	When I rename the term to "2011 Fall 16-week"
	Then it does nothing
