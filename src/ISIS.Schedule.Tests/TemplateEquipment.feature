Feature: Template Equipment
	As a department chair
	I want to track the equipment required to properly teach a template

@domain
Scenario: Add required instructor equipment for template
	Given I have set up a course and template and activated the template
	When I require 1 "whiteboard" for the template
	Then 1 "whiteboard" is required for the template, for a total of 1
	And it does nothing else

@domain
Scenario: Add required student equipement for template
	Given I have set up a course and template and activated the template
	When I require 1 "PC" per student for the template
	Then 1 "PC" per student is required for the template
	And it does nothing else

@domain
Scenario: Add required shared student equipement for template
	Given I have set up a course and template and activated the template
	When I require 1 "lab sink" per 2 students for the template
	Then 1 "lab sink" per 2 students is required for the template
	And it does nothing else

@domain
Scenario: Remove required instructor equipment for template
	Given I have set up a course and template and activated the template
	And I require 1 "whiteboard" for the template 
	When I no longer require 1 "whiteboard" for the template
	Then 1 "whiteboard" is no longer required for the template, for a total of 0
	And it does nothing else

@domain
Scenario: Remove required student equipement for template
	Given I have set up a course and template and activated the template
	When I no longer require 1 "PC" per student for the template
	Then 1 "PC" per student is no longer required for the template
	And it does nothing else

@domain
Scenario: Remove required shared student equipement for template
	Given I have set up a course and template and activated the template
	When I no longer require 1 "lab sink" per 2 students for the template
	Then 1 "lab sink" per 2 students is no longer required for the template
	And it does nothing else

@domain
Scenario: Add additional student equipment
	Given I have set up a course and template and activated the template
	And I require 1 "PC" per 2 students for the template
	When I require 1 "PC" per student for the template
	Then 1 "PC" per student is required for the template
	And it does nothing else

@domain
Scenario: Add additional instructor equipment
	Given I have set up a course and template and activated the template
	And I require 1 "PC" for the template
	When I require 2 "PC" for the template
	Then 2 "PC" is required for the template, for a total of 3
	And it does nothing else

@domain
Scenario: Instructor equipment doesnt affect student equipment
	Given I have set up a course and template and activated the template
	And I require 1 "PC" per student for the template
	When I require 1 "PC" for the template
	Then 1 "PC" is required for the template, for a total of 1
	And it does nothing else
