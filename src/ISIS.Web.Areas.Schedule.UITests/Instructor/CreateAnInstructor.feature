Feature: Create an instructor
	In order to have instructors available to teach
	As a department chair
	I want to enter new instructors
	
@selenium
Scenario: Dialog displays
	Given I navigate to ~/Schedule/Instructor
	When I click Create an instructor
	Then the Create Instructor dialog is displayed

@selenium
Scenario: Enter instructor name and click cancel
	Given I navigate to ~/Schedule/Instructor
	When I click Create an instructor
	And I enter the first name "John"
	And I enter the last name "Smith"
	And I click "Cancel"
	Then the Create Instructor dialog is not displayed

@selenium
Scenario: Enter instructor name and click Create Instructor
	Given I navigate to ~/Schedule/Instructor
	When I click Create an instructor
	And I enter the first name "John"
	And I enter the last name "Smith"
	And I click "Create Instructor"
	Then I navigate to an instructor detail page
	And the instructor is "John Smith"