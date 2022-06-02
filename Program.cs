using System;
using System.Collections.Generic;
// follow along GSTARK version

class Card /* encapsulation */
{
    public string Suit { get; set; }
    public string Face { get; set; }

    public int Value()
    {
        //  this can be done constructing a dictionary for "values"
        // var values = new Dictionary<string, int>();
        // for (var number = 2; number <= 10; number++)
        // {
        // values.Add($"{number}", number);
        // }
        // values.Add("Jack", 10);
        // values.Add("Queen", 10);
        // values.Add("King", 10);
        // values.Add("Ace", 11);

        // foreach(var entry in values)
        // {
        // var face = entry.Key;
        // var value = entry.Value;
        // }

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
    public void PrintCardsAndTotal(string handName)
    {
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine($"{handName}, your cards are: ");
        Console.WriteLine(String.Join(", ", CurrentCards));

        //  the TotalValue of their Hand
        Console.WriteLine($"The total value of your hand is: {TotalValue()}");
        Console.WriteLine();
        Console.WriteLine();
    }
}
class Deck
{
    public List<Card> Cards { get; set; } = new List<Card>();
    // Behavior
    // Initialize a list of 52cards
    public void Initialize()
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
                Cards.Add(newCard);
                // shuffle
                // deal a single card to hand
            }
        }
    }
    // shuffle
    public void Shuffle()
    {
        // #SHUFFLE cards (fisher yates) - AllCardsOnDeck (Behavior)
        var numberOfCards = Cards.Count;

        for (var rightIndex = numberOfCards - 1; rightIndex >= 1; rightIndex--)
        {
            //  // leftIndex = random integer that is greater than or equal to 0 and LESS than rightIndex. 
            var randomNumberGenerator = new Random();
            var leftIndex = randomNumberGenerator.Next(rightIndex);
            var leftCard = Cards[leftIndex];
            var rightCard = Cards[rightIndex];
            Cards[rightIndex] = leftCard;
            Cards[leftIndex] = rightCard;
        }
    }
    // Deal Cards
    public Card Deal()

    {
        var card = Cards[0];
        // - remove that card from the Cards list
        Cards.Remove(card);
        // player.AddCard(card);
        return card;
    }
}


namespace blackJack
{

    class Program
    {
        static void GamePlay()
        {
            // make a blank list of cards
            var temporaryDeck = new Deck();
            temporaryDeck.Initialize();
            temporaryDeck.Shuffle();

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

            // foreach (var card in player.CurrentCards)
            // {
            //     Console.WriteLine(card);
            // }
            // for every card, print out
            // to the user the description of the card

            // 10. If they have BUSTED (hand TotalValue is > 21), then goto step 15
            var answer = "";

            while (player.TotalValue() < 21 && answer != "STAND")
            {
                // 9.  Show the player the cards in their hand  
                // - loop through the list of cards in the player hand 
                player.PrintCardsAndTotal("Player");
                // 11. Ask the player if they want to HIT or STAND
                Console.WriteLine("Do you want to HIT or STAND? ");
                answer = Console.ReadLine().ToUpper();
                // 12. If HIT
                if (answer == "HIT")
                {
                    //     - Ask the deck for a card and place it in the player hand, repeat step 10
                    var newCard = deck[0];
                    deck.Remove(newCard);

                    player.AddCard(newCard);
                }

                // 13. If STAND then continue on
            }
            player.PrintCardsAndTotal("Player");
            // 14. If the dealer's hand TotalValue is more than 21 then goto step 17
            // 15. If the dealer's hand TotalValue is less than 17
            while (player.TotalValue() <= 21 && dealer.TotalValue() <= 17)
            {
                var newCard = deck[0];
                deck.Remove(newCard);

                dealer.AddCard(newCard);
                //     - Add a card to the dealer hand and go back to 14

            }
            // 16. Show the dealer's hand TotalValue
            dealer.PrintCardsAndTotal("Dealer");

            //  the TotalValue of their Hand

            // 17. If the player's hand TotalValue > 21 show "DEALER WINS"
            if (player.TotalValue() > 21)
            {
                Console.WriteLine("DEALER WINS");
            }
            else
            // 18. If the dealer's hand TotalValue > 21 show "PLAYER WINS"
            if (dealer.TotalValue() > 21)
            {
                Console.WriteLine("PLAYER WINS");
            }
            else
            // 19. If the dealer's hand TotalValue is more than the player's hand TotalValue then show "DEALER WINS", else show "PLAYER WINS"
            if (dealer.TotalValue() > player.TotalValue())
            {
                Console.WriteLine("DEALER WINS");
            }
            // 20. If the value of the hands are even, show "DEALER WINS"
            else
            if (player.TotalValue() > dealer.TotalValue())
            {
                Console.WriteLine("PLAYER WINS");
            }
            else
            {
                Console.WriteLine("DEALER WINS");
            }


            /*  take values from the dictionary and add them together (Value of card/hand)
            // how to reference a method from the Main method
            // how to restart the game at *any* point
            //  how to deal out cards from the deck
            // how to avoid duplicating code */
        }

        static void Main(string[] args)
        // Create a #CARD class includes suit, face
        {
            while (true)
            {
                GamePlay();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Would you like to play again? ");
                var answer = Console.ReadLine().ToUpper();

                if (answer == "NO")
                {
                    Console.WriteLine("So long....");
                    break;
                }
            }
        }
    }
}