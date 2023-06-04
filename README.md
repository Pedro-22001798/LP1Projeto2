- Project Title:
LP1 Project 2 | Tragic : The Reckoning

- Done by:
Pedro Silva 22001798
Bruno Rodrigues 22103346
Nuno Matias 22104821

- Pedro Silva:

- Bruno Rodrigues:

- Nuno Matias:

- Git Repository:
https://github.com/Pedro-22001798/LP1Projeto2

- Solution Structure:
The project was created following the MVC structure meanning we devided our classes in the
Model - View - Controller perspective

We start by creating our class Program that contains the Main method.
Inside of it we created the class deckCreator that´s part of our Model and is responsable for creating and shuffling the deck.
Another one called controller that represents our Controller, receives information from the DeckCreator class and is used as the game engine
controlling every phase of the game from the start to the finish.
And finnaly one called view for our View that receives information from the Controller about what things changed in the Model and than displays
them in the interface for the players to see.
We will go more in death in each one of these later on.

Before our Controller class starts running the game we have to create the card deck, we can´t play cards without one.
For this we have three different classes, ICard, Card & DeckCreator

We start with the ICard method which is responsable for getting the different basic variables of each card this ones being Name, type string , Cost Attack & Defense, type int
as well as creating 2 methods for them, TakeDamage & ReduceDamage with a type int variable called damage

Than we have our Card class where the basic variables from ICard are received and, using a public constructor named Card, they will be set to different Names and Values when this method is called by the DeckCreator class
in order to create a new card to had to the deck
The previously mentioned methods of TakeDamage & ReduceDamage are also in this class.TakeDamage is where the calculation between the damage a card takes - their Defense happens and if the Defense is lower
than 0 than it´s changed to always be 0 as it´s minimum value since the Defense value of a card works as their HP.

Lastly we have the DeckCreator class where, before the method, we create a int variable called initialHand and assign 6 to it. This variable is the number of cards each player will have in their hand when the game
starts.
After that we have our public method called CreateDeck where everysingle card from the deck will be created. This is possible by creating a new Card by calling the Card class and assining the respective Name and Values to it. This needs to be repeated everysingle time for every new card.
The different cards that are created will be seperated from eachother using for loops. Each new card will have one before the card is created and they also are used to determine the amount of cards of that type exists in the deck. For example, the "Flying Wand" card has 4 copies of it in the deck so the for loop starts at a value of 0 and will increase by 1 everytime the for loop runs creating 1 copy of that card each time. When the number of copies reachs 4 the for loop ends for that card and the next one for the next card will start, repeating this process for every card until the completed deck of a total of 20 cards is created.
Inside each for loop for each card is where we are going to place the Name and Values to the corresponding card so when we have | new Card("Flying Wand", 1 1 1) | we create a new card named Flying Wand that has a Cost, Attack & Defense of 1 in that order. If for example we changed the values to 1 2 1, than the Flying Wand card would now have 2 Attack instead of 1.
