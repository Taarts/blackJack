using System;
using System.Collections.Generic;
// follow along GSTARK version

class Card /* encapsulation */
{
    public string Suit { get; set; }
    public string Face { get; set; }

}
class Hand
{
    // List of individual cards

    //      data type                            neat instance of list
    public List<Card> FreshHand { get; set; } /* = new List<Card>(); */
    // method 
    // this uses the constructor to initialize the list of cards
    public Hand()
    {
        FreshHand = new List<Card>();
    }
    // Behaviors
    //  TotalValue representing the sum of the cards in the hand
    //  start with a Total  = 0
    // Foreach card in the hand DO THIS:
    //    Add the amount of that card's value to the total
    //    return Total as the result
    //  Add card to the hand
    public void AddCard(Card cardToAdd) /* doesn't return any information back to the person requesting it */
    {
        //  adds the additional card to the list of  cards, that the hand has
        FreshHand.Add(cardToAdd);
    }
}

namespace blackJack
{

    class Program
    {
        static void Main(string[] args)
        // Create a #CARD class includes suit, face
        {
            // make a blank list of cards
            var deck = new List<Card>();
            var suits = new List<string>() { "Hearts", "Spades", "Diamonds", "Clubs" };
            var faces = new List<string>() { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };

            foreach (var suit in suits)
            {
                foreach (var face in faces)
                {
                    var newCard = new Card()
                    {
                        Suit = suit,
                        Face = face,
                    };
                    // Console.WriteLine($"{newCard.Face} of {newCard.Suit}");

                    // create deck
                    deck.Add(newCard);
                }
            }
            // #SHUFFLE cards (fisher yates) - AllCardsOnDeck (Behavior)
            var numberOfCards = deck.Count;

            for (var rightIndex = numberOfCards - 1; rightIndex >= 1; rightIndex--)
            {
                //  // leftIndex = random integer that is greater than or equal to 0 and LESS than rightIndex. 
                var randomNumberGenerator = new Random();
                var leftIndex = randomNumberGenerator.Next(rightIndex);
                var leftCard = deck[leftIndex];
                var rightCard = deck[rightIndex];
                deck[rightIndex] = leftCard;
                deck[leftIndex] = rightCard;
            }
            // debug
            // #HAND = has to receive cards, add the  value of the cards
            var player = new Hand();

            var dealer = new Hand();

            // #Deal (behavior)

            //      - add one card
            //      - add another card
            // breakdown:
            // - the card is equal to 0 index of the deck
            for (var numberOfCardsToDeal = 0; numberOfCardsToDeal < 2; numberOfCardsToDeal++)
            {
                var card = deck[0];
                // - remove that card from the deck list
                deck.Remove(card);
                player.AddCard(card);
            }

            for (var numberOfCardsToDeal = 0; numberOfCardsToDeal < 2; numberOfCardsToDeal++)
            {
                var card = deck[0];
                // - remove that card from the deck list
                deck.Remove(card);
                dealer.AddCard(card);
            }

            Console.WriteLine(player.FreshHand.Count);
            // Console.WriteLine(deck.Count);
            // - call the "add card" behavior of the hand and pass it this newCard


            // value
            // - Value assigns value 2 - 10 as per face, J, Q, K, == 10, A == 11
            // - if faceValue == 2 - 10 then assign face as value
            // - if Jack || Queen || King (faceValue == 10)
            // - if Ace (faceValue == 11)
            // #DECK - from AllCardsOnDeck (can remain a list)

            //   TWO to the dealer
            // Ask Player if they want to "stick or hit"

            // #HIT (behavior)
            // - the card is equal to 0 index of the deck
            // - remove that card from the deck list
            // - call the "add card" behavior of the hand and pass it this newCard
            // 
            // - player gets a new card
            //   - card ++
            // - <= 21 && > 16

            // #STICK (behavior)
            // - decides to stay with current hand

            // Dealer: (state)
            // - turns face down cards, up
            // - if < 16 dealer must take another card
            // - If #DEALERHAND >= 17, it must stand.

            // #PLAYERWIN
            // - if > DEALERHAND <= 21

            // #DEALERWIN
            // - if >= 17 && <=21 && > #PLAYERHAND
            // - else if #DEALERHAND == #PLAYERHAND
        }
    }
}



/*  take values from the dictionary and add them together (Value of card/hand)
// how to reference a method from the Main method
// how to restart the game at *any* point
//  how to deal out cards from the deck
// how to avoid duplicating code */