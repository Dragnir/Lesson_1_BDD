Feature: MailRuIncorrectPasswordTest
	In order to verify incorrect password
	As a existing user
	I want be able to see error message after emter incorrect password

@smoke
Scenario: Enter incorrect password should be shows error message
	Given I open official mail ru site
	And Click on Login button
	When I set User Navme 'vadim.kuryan.vka' start add password
	And Type 'IncorrectPassword' and click on login
	Then Page shows error message that 'Password is Incorrect'