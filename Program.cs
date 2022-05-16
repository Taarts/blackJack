using System;
using System.Collections.Generic;


namespace blackJack
{

    class Card /* encapsulation */
    {
        public string Suit { get; set; }
        public string Face { get; set; }


        class Program
        {
            static void Main(string[] args)
            // Create a #CARD class includes suit, face
            {
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
                        Console.WriteLine($"{newCard.Face} of {newCard.Suit}");
                        // create deck
                        deck.Add(newCard);
                        // debug
                        Console.WriteLine(deck.Count);
                    }
                }
                // value

                // - Value assigns value 2 - 10 as per face, J, Q, K, == 10, A == 11
                // - if faceValue == 2 - 10 then assign face as value
                // - if Jack || Queen || King (faceValue == 10)
                // - if Ace (faceValue == 11)
                // #HAND = has to receive cards, add the  value of the cards
                // #DECK - from AllCardsOnDeck (can remain a list)
                // #SHUFFLE cards (52 cards, fisher yates) - AllCardsOnDeck (Behavior)
                // #Deal (behavior)
                //   TWO to the player
                //   TWO to the dealer
                // Ask Player if they want to "stick or hit"
                // #HIT (behavior)
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
}
/*  take values from the dictionary and add them together (Value of card/hand)
// how to reference a method from the Main method
// how to restart the game at *any* point
//  how to deal out cards from the deck
// how to avoid duplicating code */