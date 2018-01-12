# CodeKata.CSharp

##Scoring Bowling

The game consists of 10 frames as shown above.  In each frame the player has
two opportunities to knock down 10 pins.  The score for the frame is the total
number of pins knocked down, plus bonuses for strikes and spares.

A spare is when the player knocks down all 10 pins in two tries.  The bonus for
that frame is the number of pins knocked down by the next roll.  So in frame 3
above, the score is 10 (the total number knocked down) plus a bonus of 5 (the
number of pins knocked down on the next roll.)

A strike is when the player knocks down all 10 pins on his first try.  The bonus
for that frame is the value of the next two balls rolled.

In the tenth frame a player who rolls a spare or strike is allowed to roll the extra
balls to complete the frame.  However no more than three balls can be rolled in
tenth frame.


## String Calculator

The following is a TDD Kata- an exercise in coding, refactoring and test-first, that you should apply daily for at least 15 minutes (I do 30).3

Before you start: 
Try not to read ahead1.
Do one task at a time. The trick is to learn to work incrementally.
Make sure you only test for correct inputs. there is no need to test for invalid inputs for this kata
String Calculator

Create a simple String calculator with a method int Add(string numbers)
1. The method can take 0, 1 or 2 numbers, and will return their sum (for an empty string it will return 0) for example “” or “1” or “1,2”
Start with the simplest test case of an empty string and move to 1 and two numbers
Remember to solve things as simply as possible so that you force yourself to write tests you did not think about
Remember to refactor after each passing test
1. Allow the Add method to handle an unknown amount of numbers1
1. Allow the Add method to handle new lines between numbers (instead of commas).
the following input is ok:  “1\n2,3”  (will equal 6)
the following input is NOT ok:  “1,\n” (not need to prove it - just clarifying)
1. Support different delimiters
to change a delimiter, the beginning of the string will contain a separate line that looks like this:   “/1/[delimiter]\n[numbers…]” for example “//;\n1;2” should return three where the default delimiter is ‘;’ .
the first line is optional. all existing scenarios should still be supported
1. Calling Add with a negative number will throw an exception “negatives not allowed” - and the negative that was passed.if there are multiple negatives, show all of them in the exception message
