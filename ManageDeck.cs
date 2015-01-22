using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace CardGame

{


    /// <summary>
    /// Class allows you to add cards to a sorted deck. The deck is represented as a set of tuples.
    /// Suittype is a list used to validate you are using valid suits in your deck.
    /// Card type is the same, but for cards.
    /// </summary>

    public class ManageDeck
    {
        List<string> suitType = new List<string>();
        List<string> cardType = new List<string>();
        public TupleList<byte,string, string, byte, byte?> deck = new TupleList<byte,string, string, byte, byte?>();
        RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
  
        /// <summary>
        ///byte is an economical numeric datatype that stores values up to 32,767
        ///alternateWeight is usually null and is deisgned for card games that allow one card to have two values like the ace in blackjack
        /// Class allows you to add cards to a sorted deck. The deck is represented as a set of tuples.
        /// Suittype is a list used to validate you are using valid suits in your deck.
        /// Card type is the same, but for cards.
        /// </summary>
        /// 
        /// <param name="sortOrder">a byte value used as an index for sorting the deck in default order prior to shuffling</param>
        /// <param name="cardVal">The value of a card you want to add. Must match cardType list.</param>
        /// <param name="suitVal">The suit of a card you want to add. Must match suitType list.</param>
        /// <param name="weight">Attribute of a card that indicates value relative to other cards. Customizable by game. A king and 10 are the same weight in black jack, but the king has a higher weight in poker.</param>
        /// <param name="alternateWeight">In some games a card can have more than one value. In blackjack the Ace has a value of 11 or 1.</param>
        /// <param name="sortDeck">boolean to indicate if deck should be sorted. Shuffling will superscede sorting if both are set to true.</param>
        /// <param name="shuffleDeck">boolean to indicate if deck should be shuffled. Shuffling will superscede sorting if both are set to true.</param>
        /// <example>
        /// var game = new ManageDeck();
        /// game.makeDeck(2, "2", "Clubs", 1, null,false,false);
        /// game.makeDeck(3, "Ace", "Hearts", 11, 1);
        /// game.makeDeck(1, "Ace", "Clubs", 11, 1);
        /// </example>
        public string makeDeck(byte sortOrder,string cardVal, string suitVal, byte weight, byte? alternateWeight, bool sortDeck, bool shuffleDeck)
        {
            var format = new ArgumentException("Use a conventional card and suit.");

            try
            {
                //start adding valid suits to suitType list
                suitType.Add("Clubs");
                suitType.Add("Diamonds");
                suitType.Add("Hearts");
                suitType.Add("Spades");

                //start adding valid suits to cardType list
                cardType.Add("Ace");
                cardType.Add("King");
                cardType.Add("Queen");
                cardType.Add("Jack");
                cardType.Add("10");
                cardType.Add("9");
                cardType.Add("8");
                cardType.Add("7");
                cardType.Add("6");
                cardType.Add("5");
                cardType.Add("4");
                cardType.Add("3");
                cardType.Add("2");

                //validate cards ad suits based on lsit values
                if (cardType.Contains(cardVal))
                {
                    //add card and sort deck
                    if (suitType.Contains(suitVal))
                    {
                        deck.Add(sortOrder, cardVal, suitVal, weight, alternateWeight);
                        
                        if(sortDeck == true && shuffleDeck  == false)
                        { 
                            deck.Sort();
                        }

                        if (shuffleDeck  ==  true)
                        {        
                            int n = deck.Count;
                            while (n > 1)
                            {
                                var box = new byte[1];
                                do provider.GetBytes(box);
                                while (!(box[0] < n * (Byte.MaxValue / n)));
                                var k = (box[0] % n);
                                n--;
                                var value = deck[k];
                                deck[k] =   deck[n];
                                deck[n] = value;
                            }  
                        }

                        return "Success";
                    }
                    else throw format;
                }
                else throw format;
            }
            catch
            {
                throw format;
            }
        }

     /// <summary>
     /// Really, a summary of the main method. Well it is an interview. This is just sample code used to deomostrat the deck and shuffling. 
     /// </summary>
     /// <param name="args">Unsed here, but feel free to throw some args in there.</param>
        private static void Main(string[] args)
        {
            var make = new ManageDeck();

            make.makeDeck(10,"2", "Hearts", 2, null,false,false);
            make.makeDeck(1,"Ace", "Clubs", 11, 1,false,false);
            make.makeDeck(2,"10", "Clubs", 10, null,false,false);
            make.makeDeck(3,"9", "Diamonds", 9, null,false,false);
            make.makeDeck(2,"King", "Clubs", 10, null,false,false);
            make.makeDeck(2,"King", "Diamonds", 10, null,false,false);
            make.makeDeck(10, "2", "Spades", 2, null,false,false);
            make.makeDeck(2, "King", "Hearts", 10, null,false,false);
            make.makeDeck(2,"Queen", "Diamonds",10, null,false,false);
            make.makeDeck(2,"King", "Spades", 10, null,false,false);
            make.makeDeck(2,"Queen", "Clubs", 10, null,false,false);
            make.makeDeck(2,"Jack", "Clubs", 10, null,false,false);
            make.makeDeck(2,"Jack", "Diamonds", 10, null,false,false);
            make.makeDeck(2,"Jack", "Hearts",   10, null,false,false);
            make.makeDeck(1,"Ace", "Diamonds", 11, 1,false,false);
            make.makeDeck(1,"Ace", "Hearts", 11, 1,false,false);
            make.makeDeck(2,"Jack", "Spades", 10, null,false,false);
            make.makeDeck(2,"10", "Diamonds",   10, null,false,false);
            make.makeDeck(2,"10", "Hearts",     10, null,false,false);
            make.makeDeck(2,"10", "Spades",     10, null,false,false);
            make.makeDeck(3,"9", "Clubs",        9, null,false,false);
            make.makeDeck(3,"9", "Hearts",       9, null,false,false);
            make.makeDeck(3,"9", "Spades",       9, null,false,false);
            make.makeDeck(4,"8", "Clubs", 8, null,false,false);
            make.makeDeck(4,"8", "Diamonds", 8, null,false,false);
            make.makeDeck(5,"7", "Diamonds", 7, null,false,false);
            make.makeDeck(5,"7", "Hearts", 7, null,false,false);
            make.makeDeck(4,"8", "Hearts", 8, null,false,false);
            make.makeDeck(1,"Ace", "Spades", 11, 1,false,false);
            make.makeDeck(4,"8", "Spades", 8, null,false,false);
            make.makeDeck(5,"7", "Clubs", 7, null,false,false);
            make.makeDeck(5,"7", "Spades", 7, null,false,false);
            make.makeDeck(6,"6", "Clubs", 6, null,false,false);
            make.makeDeck(6,"6", "Diamonds", 6, null,false,false);
            make.makeDeck(2, "Queen", "Hearts", 10, null,false,false);
            make.makeDeck(2, "Queen", "Spades", 10, null,false,false);
            make.makeDeck(6, "6", "Hearts", 6, null,false,false);
            make.makeDeck(6,"6", "Spades", 6, null,false,false);
            make.makeDeck(7,"5", "Clubs", 5, null,false,false);
            make.makeDeck(7,"5", "Diamonds", 5, null,false,false);
            make.makeDeck(7,"5", "Hearts", 5, null,false,false);
            make.makeDeck(7,"5", "Spades", 5, null,false,false);
            make.makeDeck(8,"4", "Clubs", 4, null,false,false);
            make.makeDeck(8,"4", "Diamonds", 4, null,false,false);
            make.makeDeck(8,"4", "Hearts", 4, null,false,false);
            make.makeDeck(8,"4", "Spades", 4, null,false,false);
            make.makeDeck(9,"3", "Clubs", 3, null,false,false);
            make.makeDeck(9,"3", "Diamonds", 3, null,false,false);
            make.makeDeck(9,"3", "Hearts", 3, null,false,false);
            make.makeDeck(9,"3", "Spades", 3, null,false,false);
            make.makeDeck(10,"2", "Clubs", 2, null,false,false);
            make.makeDeck(10,"2", "Diamonds", 2, null, true, false);

            int counter = make.deck.Count();

            string cardTypefirstCard = make.deck[0].Item2;
            string suitfirstCard = make.deck[0].Item3;
            string weightfirstCard = make.deck[1].Item4.ToString();
            string altWeightfirstCard = make.deck[1].Item5.ToString();
            string cardTypeSecondCard = make.deck[1].Item2;
            string suitSecondCard = make.deck[1].Item3;
            string weightSecondCard = make.deck[1].Item4.ToString();
            string altWeightSecondCard = make.deck[1].Item5.ToString();

            string cardTypeTwentiethCard = make.deck[19].Item2;
            string suitTwentiethCard = make.deck[19].Item3;
            string weightTwentiethCard = make.deck[19].Item4.ToString();
            string altWeightTwentiethCard = make.deck[19].Item5.ToString();
            
            Console.WriteLine("Deck contains " + counter.ToString() + " cards.");
            Console.WriteLine("First card in deck is " + cardTypefirstCard + " of " + suitfirstCard);
            Console.WriteLine("Second card in deck is " + cardTypeSecondCard + " of " + suitSecondCard);
            Console.WriteLine("Weight of first card in deck is " + weightfirstCard);
            Console.WriteLine("Alternate weight of first card in deck is " + altWeightfirstCard);
            Console.WriteLine("Card type of 20th card in deck is " + cardTypeTwentiethCard + " of " + suitTwentiethCard);
            Console.WriteLine("Weight of 20th card in deck is " + weightTwentiethCard);
            Console.WriteLine("Alternate weight of 20th card in deck is " + altWeightTwentiethCard);


            make.deck.Remove(make.deck[0]);
            counter = make.deck.Count();
            Console.WriteLine("Deck contains " + counter.ToString() + " cards after dealing one.");

            make.makeDeck(10, "2", "Hearts", 2, null, false, true);
            counter = make.deck.Count();
            cardTypefirstCard = make.deck[0].Item2;
            suitfirstCard = make.deck[0].Item3;
            Console.WriteLine("Deck contains " + counter.ToString() + " cards after adding one and shuffling.");
            Console.WriteLine("First card in deck is " + cardTypefirstCard + " of " + suitfirstCard);
            
            Console.ReadLine();
            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit."); 
            Console.ReadKey();
        }
    }
}