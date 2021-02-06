# Greed Kata
 
## Description 
Greed is a press-your-luck dice rolling game. 
In the game, the roller will be rolling dice trying to earn as many points as possible. 
For the purposes of this kata, we will just be scoring a single roll of five dice.


## Requirements 
Write code which will calculate the best score based on any given roll using following set of scoring rules. 

- A single one (100) 
- A single five (50) 
- Triple ones [1,1,1] (1000) 
- Triple twos [2,2,2] (200) 
- Triple threes [3,3,3] (300) 
- Triple fours [4,4,4] (400) 
- Triple fives [5,5,5] (500) 
- Triple sixes [6,6,6] (600)

Examples 
- [1,1,1,5,1] = 1150 points 
- [2,3,4,6,2] = 0 points 
- [3,4,5,3,3] = 350 points
- [1,5,1,2,4] = 250 points 
- [5,5,5,5,5] = 600 points
 
Extra Credit 
Support these additional rules 
(these will change the scores of some of the examples above): 
- The player can throw up to six dice. 
- Four-of-a-Kind [2,2,2,2]: Multiply Triple score by 2 (4 2’s should be 400) 
- Five-of-a-Kind  [2,2,2,2,2]: Multiply Triple score by 4 (5 2’s should be 800) 
- Six-of-a-Kind [2,2,2,2,2,2]: Multiply Triple score by 8 (6 2’s should be 1600) 
- Three Pairs [2,2,3,3,4,4]: 800 - Straight [1,2,3,4,5,6]: 1200

  