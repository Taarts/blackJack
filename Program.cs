﻿using System;
using System.Collections.Generic;
// follow along GSTARK version

class Card /* encapsulation */
{
    public string Suit { get; set; }
    public string Face { get; set; }

    public int Value()
    {
        //  this can be done constructing a dictionary for "values"
        switch (Face)
        {
            case "2":
            case "3":
            case "4":
            case "5":
            case "6":
            case "7":

            // case "8": /* repetitive method */
            case "8":
            //     return 8;
            case "9":
            case "10":
                return int.Parse(Face);

            case "Jack":
            case "Queen":
            case "King":
                return 10;

            // "if" for each instance in the deck shown below
            // if (Face == "Jack")
            // {
            //     return 10;
            // }

            // if (Face == "Queen")
            // {
            //     return 10;
            // }


            // if (Face == "King")
            // {
            //     return 10;
            // }

            case "Ace":
                return 11;

            default:
                return 0;
        }
    }
    public override string ToString()
    {
        return $"The {Face} of {Suit}";
    }
}
class Hand
{
    // List of individual cards

    //      data type                            neat instance of list
    public List<Card> CurrentCards { get; set; } /* = new List<Card>(); */
    // method 
    // this uses the constructor to initialize the list of cards
    public Hand()
    {
        CurrentCards = new List<Card>();
    }
    // Behaviors
    //  TotalValue representing the sum of the cards in the hand
    public int TotalValue()
    {
        //  start with a Total  = 0
        var total = 0;
        //  Foreach card in the hand DO THIS:
        foreach (var card in CurrentCards)
        {
            total = total + card.Value();
        }
        //  Add the amount of that card's value to the total
        //    return Total as the result
        return total;
    }
    //  Add card to the hand
    public void AddCard(Card cardToAdd) /* doesn't return any information back to the person requesting it */
    {
        //  adds the additional card to the list of  cards, that the hand has
        CurrentCards.Add(cardToAdd);
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

            Console.WriteLine(player.CurrentCards.Count);
            // Console.WriteLine(deck.Count);
            // 9.  Show the player the cards in their hand  
            // - loop through the list of cards in the player hand 
            Console.WriteLine("player, your cards are: ");
            Console.WriteLine(String.Join(", ", player.CurrentCards));
            // foreach (var card in player.CurrentCards)
            // {
            //     Console.WriteLine(card);
            // }
            // for every card, print out
            // to the user the description of the card

            //  the TotalValue of their Hand
            Console.WriteLine($"The total value of your hand is: {player.TotalValue()}");
            // 10. If they have BUSTED (hand TotalValue is > 21), then goto step 15
            // 11. Ask the player if they want to HIT or STAND
            // 12. If HIT
            //     - Ask the deck for a card and place it in the player hand, repeat step 10
            // 13. If STAND then continue on
            // 14. If the dealer's hand TotalValue is more than 21 then goto step 17
            // 15. If the dealer's hand TotalValue is less than 17
            //     - Add a card to the dealer hand and go back to 14
            // 16. Show the dealer's hand TotalValue
            // 17. If the player's hand TotalValue > 21 show "DEALER WINS"
            // 18. If the dealer's hand TotalValue > 21 show "PLAYER WINS"
            // 19. If the dealer's hand TotalValue is more than the player's hand TotalValue then show "DEALER WINS", else show "PLAYER WINS"
            // 20. If the value of the hands are even, show "DEALER WINS"


            /*  take values from the dictionary and add them together (Value of card/hand)
            // how to reference a method from the Main method
            // how to restart the game at *any* point
            //  how to deal out cards from the deck
            // how to avoid duplicating code */
        }
    }
}