


Feature: Peform Operation On Calculator


@closeAllInstances
    Scenario Outline: Check calculator operation in two modes
	Given  Open the Calculator Application 
	And   : Select the Mode '<SpecificMode>'
	Then  : I Enter '<Numb1>' '<numb2>' and perform add operation
	And   : Then I Click M+
	And   : Use square root if its scientific '<numb3>'
	And   : The Result should be '<numb4>'
	

	Examples: 
				| SpecificMode	| Numb1 | numb2 | numb3 | numb4 |
				| Standard		|   12  | 999   | 19    | 1030  |
				|Scientific		|  12   | 999   | 19    | 361   |
	