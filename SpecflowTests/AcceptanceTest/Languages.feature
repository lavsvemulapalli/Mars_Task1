Feature: Languages
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

	@mytag
Scenario Outline: Check if user could able to add a language for different iterarions
	Given I click on the Language tab in profile
	When I addded a new language "<Languages>"
	Then that language should be displayed on my listing
	Examples: 
	| Languages |
	| Hindi     |
	| Telugu    |
	| English    |
