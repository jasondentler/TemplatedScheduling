Feature: Instructors page
	In order to maintain a list of instructors
	As a department chair
	I want to navigate the links of the instructor page
	
@selenium
Scenario: Instructors page
	When I navigate to ~/Schedule/Instructor
	Then the page has breadcrumbs as follows
		| Text              | Url                            |
		| ISIS              | http://localhost:1481/         |
		| Course Scheduling | http://localhost:1481/Schedule |
		| Instructors       |                                |
	And the page has a list of instructors
	And the page has a hint "Choose an instructor from the left"

@selenium
Scenario: Follow breadcrumbs to the ISIS home page
	Given I navigate to ~/Schedule/Instructor
	When I click ISIS
	Then I navigate to ~/

@selenium
Scenario: Follow breadcrumbs to the scheduling area
	Given I navigate to ~/Schedule/Instructor
	When I click Course Scheduling
	Then I navigate to ~/Schedule
