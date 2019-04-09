Feature: AddingSameLanguageWithDifferntLanguageLevel
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: AddingSameLanguageWithDifferntLanguageLevel
	Given I click on the Language tab under Profile 
	And I have enter same language and with differnt language level
	When I press add
	Then check if user is able to add the same language or not
