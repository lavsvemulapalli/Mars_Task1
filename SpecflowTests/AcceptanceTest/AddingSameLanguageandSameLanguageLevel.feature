Feature: AddingSameLanguageandSameLanguageLevel
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers


	@mytag
Scenario: AddingSameLanguageandSameLanguageLevel
	Given I click on the Languages tab under Profile 
	And I have enter same language and with Same language level
	When I press add button
	Then check if same language is added with same language level or not 