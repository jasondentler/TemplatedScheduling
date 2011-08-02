Feature: Scheduling Home Page 
	In order to use the scheduling system
	As a user
	I want to navigate to different areas of the scheduling system

@selenium
Scenario: Scheduling home page
	When I navigate to the scheduling area
	Then the page has breadcrumbs as follows
		| Text              | Url                            |
		| ISIS              | http://localhost:1481/         |
		| Course Scheduling | http://localhost:1481/Schedule |
		| Home				|							     |
	And the page has a link to Instructors
	And the page has a link to Templates
	And the page has a link to Sections

@selenium
Scenario: Follow breadcrumbs to the ISIS home page
	Given I navigate to the scheduling area
	When I click ISIS
	Then I navigate to ~/

@selenium
Scenario: Follow breadcrumbs to the scheduling area
	Given I navigate to the scheduling area
	When I click Course Scheduling
	Then I navigate to ~/Schedule


@selenium
Scenario: Go to instructors page
	Given I navigate to the scheduling area
	When I click Instructors
	Then I navigate to ~/Schedule/Instructor

@selenium
Scenario: Go to templates page
	Given I navigate to the scheduling area
	When I click Templates
	Then I navigate to ~/Schedule/Template

@selenium
Scenario: Go to sections page
	Given I navigate to the scheduling area
	When I click Sections
	Then I navigate to ~/Schedule/Section

