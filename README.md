# Project Title :
## LP1 Project 2 | Tragic : The Reckoning


## Done by :
Pedro Silva 22001798
Bruno Rodrigues 22103346
Nuno Matias 22104821


### Pedro Silva :
- Created program class and MVC
- Created both Classes and Interfaces
- Created Deck Creator
- Commented the code

### Bruno Rodrigues :

- Nuno Matias :
Created the report and wrote the explanations for the code
Reviewed the code and pointed mistakes to be changed ( dead code & spelling)

## Git Repository:
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


-Interface
What the Interface of the game presents to the players is created using two classes, IView & View that are part of the View section of MVC.
Starting with our IView class this class has methods that will be used as references for our View class that will be the one cointainning the actual code for each method.



Moving on into our Controller class, that´s part of the Controller section of MVC, this is where the main cicle of the game is and will also manage the inputs of the players. This one will call a lot of classes that have not yet been explained so when they are mentioned we will give a small ideia of what they do and later on explain them more in detail.

We start by calling the IView, DeckCreator & a list of the IPlayer classes as well as creating some variables, two of type int and one of type bool. The int variables are maxCard that we equal to 20 since that´s the 
maximum number of card in the deck and turn that we equal to 0 that represents the turn number we are on, this is important because during the game the turn number determinates how much mana each player
is able to use on the respective turn. The bool variable is named gameOver and it starts on False and will change to True if one of the players meets the conditions to lose the game.

We than have our first method, in this case a constructor, inside the Controller class called Controller that calls for the DeckCreator class to access the deck as well as creating a playerList variable that creates
a new list of players by calling the IPlayer class

## References
- Possible null treatments and possible empty strings = StackExchange and ChatGPT
- Logic behing Attack Stage = Talk with colleagues
