Feature: DeleteingLanguage
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: check if user is able to delete the language
	Given I click on the Language tab under Profile page
	When I click on Delete option in language list 
	Then I check if language is deleted or not
