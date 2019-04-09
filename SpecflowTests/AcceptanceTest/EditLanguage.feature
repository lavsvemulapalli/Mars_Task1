Feature: EditLanguage
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Check if user able to Edit the language
	Given I have Click on Edit button corresponding language
	And I have select the update details
	When I press update button
	Then the verifiying language is updated correctly or not
