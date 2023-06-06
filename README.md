# Project Title :
## LP1 Project 2 | Tragic : The Reckoning


## Done by :
Pedro Silva 22001798
Bruno Rodrigues 22103346
Nuno Matias 22104821


###  Pedro Silva :
- Created program class and MVC
- Created both Classes and Interfaces
- Created Deck Creator
- Commented the code

### Bruno Rodrigues :
-Created View User Interface
-Worked on AttackPhase 
-Buf fixing
-Created UML

###  Nuno Matias :
- Created the report and wrote the explanations for the code
- Reviewed the code and pointed mistakes to be changed ( dead code & spelling)

- Git Repository:
https://github.com/Pedro-22001798/LP1Projeto2


## Solution Structure:
The project was created following the MVC structure meanning we devided our classes in the
Model - View - Controller perspective

## Program
We start by creating our class Program that contains the Main method.
Inside of it we created the class deckCreator that´s part of our Model and is responsable for creating and shuffling the deck.

Another one called controller that represents our Controller, receives information from the DeckCreator class and is used as the game engine
controlling every phase of the game from start to finish.

And finally one called view for our View that receives information from the Controller about what things changed in the Model and than displays
them in the interface for the players to see.

We will go more in depth in each one of these later on.

## Cards
Before our Controller class starts running the game we have to create other classes that will set up certain things needed for it, the cards/deck, the players and the interface.
Starting with the ones responsible for creating the cards and the deck we have three different classes, ICard, Card & DeckCreator that are part of the Model section of MVC.


We start with the ICard class which is responsable for getting the different basic variables of each card, being Name, type string , Cost Attack & Defense, type int
as well as creating 2 methods for them, TakeDamage & ReduceDamage with a type int variable called damage.

Than we have our Card class where the basic variables from ICard are received and, using a public constructor named Card, they will be set to different Names and Values when this method is called by the DeckCreator class
in order to create a new card to had to the deck.

The previously mentioned methods of TakeDamage & ReduceDamage are also in this class. TakeDamage is where the calculation between the damage a card takes - their Defense happens and if the Defense is lower
than 0 than it´s changed to always be 0 as it´s minimum value since the Defense value of a card works as their HP and when it´s 0 the card is destroyed.

Lastly we have the DeckCreator class where, before the method, we create a int variable called initialHand and assign 6 to it. This variable is the number of cards each player will have in their hand when the game
starts.

After that we have our public Enumerable method called CreateDeck where everysingle card from the deck will be created. This is possible by calling the Card class and assining the respective Name and Values to it. This needs to be repeated everysingle time for every new card.

The different cards that are created will be seperated from eachother using for loops. Each new card will have one before the card is created and they also are used to determine the amount of cards of that type that exist in the deck. For example, the "Flying Wand" card has 4 copies of it in the deck so the for loop starts at a value of 0 and will increase by 1 everytime the for loop runs creating 1 copy of that card each time. When the number of copies reachs 4 the for loop of that that card will no longer run and the one for the next card will start. We repeat this process for every card until the completed deck of a total of 20 cards is created.

Inside each for loop for each card is where we are going to place the Name and Values to the corresponding card so when we have | new Card("Flying Wand", 1 1 1) | we created a new card named Flying Wand that has a Cost, Attack & Defense of 1 in that order. If for example we changed the values to 1 2 1, than the Flying Wand card would now have 2 Attack instead of 1.


## Players
To play a game we also need players and to create them we have two classes, IPlayer & Player that are also part of the Model section of MVC.
Just like in ICard class that gets the basic variables for the cards, IPlayer gets the variables and methods for the player. Each one has three variables, Name, type string, Health and Mana, type int.
After, we have three enumerable methods from ICard, named Hand, that will get what cards the player has on his hand, Deck that will get the cards remaining on the player´s deck and PlayingHand which gets what card(s) the player is playing during the AttackPhase.

The rest of the IPlayer class is full of methods related to various things about the player´s ressources and actions. A more detailed explanation for each one will be provided later when the detailed code for them appears. For now here´s the name of all of them with a small resume.

- DefineDeck is a enumerable method that defines the deck of the player at the start of the game;
- DefineHand is a enumerable method that defines what six cards the player has on his first hand;
- DefinePlayingHand is a enumerable method that defines what cards can be played during the turn of the player;
- UseMana that is related to the mana used by the player when playing a card;
- DefineMana at the start of every round, defines the maximum mana of the player based on what turn the game is on;
- RemoveCardFromDeck removes the first card of the deck and gives it to the player;
- RemoveCardFromHand removes a card from the player hand after it has been played and the mana cost for it paid;
- AddCardToHand adds a card to the players hand from the deck;
- GetMana player loses a card but gets the mana cost of it;
- TakeDamage damage that player takes when attack by a card;
- GetCardFromTopOfDeck related to AddCardToHand to make sure the card taken from the deck is the first one;

Talking about the Player class now, this will take the components that IPlayer got and set them. There´s is also a constructor called Player that is called by the Controller class everytime a new player is created
and it has the variables for it´s Name, Health equal to 10 and Mana equal to 0 since every player starts with 0 mana cause this ressource is dependant on turn number.

The next part of the Player class contains the DefineHand, DefinePlayingHand, DefineMana, UseMana & GetMana methods from IPlayer and sets them accordingly to the respective player.
The RemoveCardFromDeck, RemoveCardFromHand & AddCardToHand have an update function on them, remove card for the first two and add card to the third, as well as a variable that equals the Deck in order to update it after 
removing a card for the RemoveCardFromDeck method and one to update the Hand of the player when either removing a card with RemoveCardFromHand method or adding a card with the AddCardToHand method.

Following that we have the TakeDamage method, where we calculate the Health that the player has remaining after taking damage by subtracting to the current Health the damage the player took and equaling it to 0 in case it falls below it since at 0 the player is dead and has lost.

Finally to conclude our Player class and the two classes used to create players we have the GetCardFromTopOfDeck method where if the amount of cards in the deck is 0 than nothing will happen otherwise the player takes the first card from the top of the deck thanks to the code | Deck.First() |.


##  Interface
What the Interface of the game presents to the players is created using two classes, IView & View that are part of the View section of MVC.
Starting with our IView class, it contains methods that will be used as references for our View class where the actual prints on the interface will be coded.
When we talk about the View class later we will go more in dept on them and exactly what they print as well as their conditions.
These methods are:
- BeginGame that references the writeline for the start of the game;
- ListPlayers that is a Enumerable with the names of the players;
- Turn that tells what player´s turn is it;
- ShowGamePhase referencing what phase of the turn the player is on, spell or attack;
- ShowPlayingCards shows what cards are being played
- ShowPlayerStats refers to the current stats of the player at the start of a turn;
- ShowSpellPhaseSelection that presents options to the player during his turn;
- ShowHand shows the player what cards he has on his hand;
- AskForSurrender calls for a surrender;
- ShowPlayingCardsToRemove shows what card the player is playing from his hand removing them from it;
- CantGetCardFromDeck tells the player he can´t get any cards from his deck;

We start our View class with a constructor for a view that is called everytime a new view is create to do so. After that we the code for the previsouly mention methods from IView.
- BeginGame we have a bunch of WriteLines in order to both welcome the players to the game and give some instructions on how the game is played before clearing it once the enter key is pressed.
- The ListPlayers enumerable asks the first player to enter a name and stores it on a variable named name1. If the entered string is empty than we are going to call a new method named ReadNonEmptyString. After the first
name is valid it will ask for the second player for one and stores it in a variable named name2 while also doing the exact same check with the ReadNonEmptyString method. It also clears the text after both names have been stored;
- ReadNonEmptyString the method responsable for checking if the names the players entered are valid in order to avoid the existance of empty names. In case the name is not valid a message will be printed on the console
informing to please enter a non empty name;
- Turn using a WriteLine informs both players which player´s turn is it;
- ShowPlayerInformation
- ShowGamePhase informs which phase of the turn the player is on by printing if the player is on spell or attack phase;
- ShowPlayingCards shows the card along with it´s name and stats ( cost, attack, defense), as well an informing the player to press enter to leave that screen and clear it;
- ShowHand prints on the console the cards the player has in his hand with every variable of them as well. The player can scroll though his cards using the index numbers from 1 to number of cards on his hand. He than gets asked which card he wants to choose to play. From here there´s 4 possible situations.

Nº1 - the player enters an index that is invalid because it´s not a number. In this case a message informingthe player to choose a valid index is printed;
Nº2 - the player enters an index that is invalid because it´s either lower than 1 or high than the current number of card he has on his hand. In this case a message informing the player to choose an index between 1 and 
the current number of cards he has on his hand is printed;
Nº3 - The player doesn´t have enough mana to choose the card he wanted to, a message telling him that he doesn´t have enough mana is than printed;
Nº4 - the card choosen by the player is valid, nothing gets printed and his option is returned;

- ShowPlayerStats on the console shows the player name followed by his Health and Mana;
- ShowSpellhaseSelection shows the available options from 0 - 5 that the player can choose, these being:
0 - End his turn;
1 - View current cards on the table;
2 - Choose card;
3 - Remove a cards from the table;
4 - Get a card from the deck;
5 - Surrender;

We will than check if the input of the user is valid and 3 options can happens.

Nº1 - the player enters an invalid option because it´s not a number. This will cause the code to write on the console that the number is invalid.
Nº2 - the payer enters an invalid option because it´s a number but it´s either lower than 0 or higher than 5. This will cause the code to write informing the player to input a number between 0 - 5;
Nº3 - the user input is valid and the console text will clear;

- AskForSurrender when the player chooses the surrender option a text will print asking if he´s sure he wants to do it and to confirm it or not by typing Yes or No. Yes will return true and the player surrenders while no 
return false and the game resumes. If the user input was not Yes or No than a message will appear on the console that the input was invalid and to please only use Yes or No;
- ShowPlayingCardsToRemove prints the card along with it´s name, cost, attack and defense values and asks which card index does the player want to remove. The player can scroll though his cards using the index numbers from 1 to number of cards on his hand. He than gets asked which card he wants to choose to play. From here there´s 3 possible options.

Nº1 - the player enters an index that is invalid because it´s not a number. In this case a message informingthe player to choose a valid index is printed;
Nº2 - the player enters an index that is invalid because it´s either lower than 1 or high than the current number of card he has on his hand. In this case a message informing the player to choose an index between 1 and 
the current number of cards he has on his hand is printed;
Nº3 - the card choosen by the player is valid, nothing gets printed and his option is returned;
When the option is valid the console will clear and return it.

- CantGetCardFromDeck has 2 WriteLines. One prints if the player doesn´t have any remaining cards in his deck | !deck | and informs him that he has 0 cards left on it. The second one happens when the player does have cards in his deck but already has 6 on his hand which is the maximum amount, so a message informing him of this is printed onto the console.


## Controller
The last part of our MVC code structure is the Controller which is done in the Controller class of the code.

We start by calling the IView, DeckCreator & a list of the IPlayer classes as well as creating 2 variables, one of type int named turn thats starts at 0. The int variables are maxCard that we equal to 20 since that´s the 
maximum number of card in the deck and turn that we equal to 0 that represents the turn number we are on, this is important because during the game the turn number determinates how much mana each player
is able to use on the respective turn. The bool variable is named gameOver and it starts on False and will change to True if one of the players meets the conditions to lose the game.

We than have our first method, in this case a constructor, inside the Controller class called Controller that calls for the DeckCreator class to access the deck as well as creating a playerList variable that creates
a new list of players by calling the IPlayer class

## References
- Possible null treatments and possible empty strings = StackExchange and ChatGPT
- Logic behing Attack Stage = Talk with colleagues
- use of ChatGPT to help solve bugs
