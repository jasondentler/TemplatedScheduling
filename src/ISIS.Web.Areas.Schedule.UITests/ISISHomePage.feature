Feature: ISIS Home Page
	In order to navigate the application
	As a user
	I want to navigate to the different areas of the application
	
@selenium
Scenario: ISIS home page
	When I navigate to the ISIS home page
	Then the page has breadcrumbs as follows
		| Text			| Url							|
		| ISIS			| http://localhost:1481/		|
		| Home			|								|
	And the page has a link to Course Scheduling
	And the page has a link to Facilities

@selenium
Scenario: Link to scheduling
	Given I have navigated to the ISIS home page
	When I click Course Scheduling
	Then I navigate to the Scheduling area

@selenium
Scenario: Link to facilities
	Given I have navigated to the ISIS home page
	When I click Facilities
	Then I navigate to the Facilities area

@selenium
Scenario: Link to ISIS home page
	Given I have navigated to the ISIS home page
	When I click ISIS
	Then I navigate to the ISIS home page

