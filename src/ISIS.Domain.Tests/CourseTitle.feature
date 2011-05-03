Feature: Course Title
	As a scheduler
	I want to set the course title

@domain
Scenario: Rename the course
	Given I have created a new course BIOL 1301
	When I rename the course to "New Title"
	Then the course is renamed to "New Title"
	And it does nothing else

@domain
Scenario: Rename the course with short title
	Given I have created a new course BIOL 1301
	When I rename the course to "Very Very Very Long New Title" with short title "Short new title"
	Then the course is renamed to "Very Very Very Long New Title" with short title "Short new title"
	And it does nothing else

@domain
Scenario: Rename the course to a different title
	Given I have created a new course BIOL 1301
	And I have renamed the course to "Introductory Biology"
	When I rename the course to "New Title"
	Then the course is renamed from "Introductory Biology" to "New Title"
	And it does nothing else

@domain
Scenario: Rename the course to a different title with short title
	Given I have created a new course BIOL 1301
	And I have renamed the course to "Introductory Biology" with short title "Intro to Biology"
	When I rename the course to "Very Very Very Long New Title" with short title "Short new title"
	Then the course is renamed from "Introductory Biology" with short title "Intro to Biology" to "Very Very Very Long New Title" with short title "Short new title"
	And it does nothing else

@domain
Scenario: Rename the course to the same
	Given I have created a new course BIOL 1301
	And I have renamed the course to "Introductory Biology"
	When I rename the course to "Introductory Biology"
	Then it does nothing

@domain
Scenario: Change only the short title
	Given I have created a new course BIOL 1301
	And I have renamed the course to "Introductory Biology" with short title "Intro to Biology"
	When I rename the course to "Introductory Biology" with short title "Short new title"
	Then the course is renamed from "Introductory Biology" with short title "Intro to Biology" to "Introductory Biology" with short title "Short new title"
	And it does nothing else

