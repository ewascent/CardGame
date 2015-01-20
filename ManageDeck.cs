using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CardGame
{
    //Create a helper class to simplify the creation of a list of tuples.
    //Each card will be represented as a tuple and the list will represent the deck
    public class TupleList<T1, T2, T3, T4, T5> : List<Tuple<T1, T2, T3, T4,T5>>
    {
        public void Add(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5)
        {
            Add(new Tuple<T1, T2, T3, T4, T5>(item1, item2, item3, item4, item5));
        }
    }
    public class ManageDeck
    {
        List<string> suitType = new List<string>();
        List<string> cardType = new List<string>();
        TupleList<byte,string, string, byte, byte?> deck = new TupleList<byte,string, string, byte, byte?>();
        //byte is an economical numeric datatype that stores values up to 32,767
        //alternateWeight is usually null adn is deisgned for card games that allow one card to have two values like the ace in blackjack
        public string addCards(byte sortOrder,string cardVal, string suitVal, byte weight, byte? alternateWeight)
        {
            var format = new FormatException();
            try
            {
                suitType.Add("Clubs");
                suitType.Add("Diamonds");
                suitType.Add("Hearts");
                suitType.Add("Spades");
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
                if (cardType.Contains(cardVal))
                {
                    if (suitType.Contains(suitVal))
                    {
                        deck.Add(sortOrder, cardVal, suitVal, weight, alternateWeight);
                        return "Eric does not know how to return a tuplelist";
                    }
                    else throw format;
                }
                else throw format;
            }
            catch
            {
                throw format;
                //return "Exception 100: Card could not be added";
            }
        }

        public void shuffleDeck(int CardCount)
        {
            Console.WriteLine("I am dead to the world. fix me");
        }

        private static void Main(string[] args)
        {
            var make = new ManageDeck();

            make.addCards(10,"2", "Hearts", 2, null);
            make.addCards(1,"Ace", "Clubs", 11, 1);
            make.addCards(2,"10", "Clubs", 10, null);
            make.addCards(3,"9", "Diamonds", 9, null);
            make.addCards(2,"King", "Clubs", 10, null);
            make.addCards(2,"King", "Diamonds", 10, null);
            make.addCards(10, "2", "Spades", 2, null);
            make.addCards(2, "King", "Hearts", 10, null);
            make.addCards(2,"Queen", "Diamonds",10, null);
            make.addCards(2,"Queen", "Hearts",  10, null);
            make.addCards(2,"Queen", "Spades",  10, null);
            make.addCards(6,"6", "Clubs", 6, null);
            make.addCards(6,"6", "Diamonds", 6, null);
            make.addCards(2,"King", "Spades", 10, null);
            make.addCards(2,"Queen", "Clubs", 10, null);
            make.addCards(2,"Jack", "Clubs", 10, null);
            make.addCards(2,"Jack", "Diamonds", 10, null);
            make.addCards(2,"Jack", "Hearts",   10, null);
            make.addCards(1,"Ace", "Diamonds", 11, 1);
            make.addCards(1,"Ace", "Hearts", 11, 1);
            make.addCards(2,"Jack", "Spades", 10, null);
            make.addCards(2,"10", "Diamonds",   10, null);
            make.addCards(2,"10", "Hearts",     10, null);
            make.addCards(2,"10", "Spades",     10, null);
            make.addCards(3,"9", "Clubs",        9, null);
            make.addCards(3,"9", "Hearts",       9, null);
            make.addCards(3,"9", "Spades",       9, null);
            make.addCards(4,"8", "Clubs", 8, null);
            make.addCards(4,"8", "Diamonds", 8, null);
            make.addCards(5,"7", "Diamonds", 7, null);
            make.addCards(5,"7", "Hearts", 7, null);
            make.addCards(4,"8", "Hearts", 8, null);
            make.addCards(1,"Ace", "Spades", 11, 1);
            make.addCards(4,"8", "Spades", 8, null);
            make.addCards(5,"7", "Clubs", 7, null);
            make.addCards(5,"7", "Spades", 7, null);
            make.addCards(6,"6", "Clubs", 6, null);
            make.addCards(6,"6", "Diamonds", 6, null);
            make.addCards(6,"6", "Hearts", 6, null);
            make.addCards(6,"6", "Spades", 6, null);
            make.addCards(7,"5", "Clubs", 5, null);
            make.addCards(7,"5", "Diamonds", 5, null);
            make.addCards(7,"5", "Hearts", 5, null);
            make.addCards(7,"5", "Spades", 5, null);
            make.addCards(8,"4", "Clubs", 4, null);
            make.addCards(8,"4", "Diamonds", 4, null);
            make.addCards(8,"4", "Hearts", 4, null);
            make.addCards(8,"4", "Spades", 4, null);
            make.addCards(9,"3", "Clubs", 3, null);
            make.addCards(9,"3", "Diamonds", 3, null);
            make.addCards(9,"3", "Hearts", 3, null);
            make.addCards(9,"3", "Spades", 3, null);
            make.addCards(10,"2", "Clubs", 2, null);
            make.addCards(10,"2", "Diamonds", 2, null);
            
            
            int counter = make.deck.Count();
            string cardTypeSecondCard = make.deck[1].Item2;
            string suitSecondCard = make.deck[1].Item3;
            string weightSecondCard = make.deck[1].Item4.ToString();
            string altWeightSecondCard = make.deck[1].Item5.ToString();

            string cardTypeTwentiethCard = make.deck[19].Item2;
            string suitTwentiethCard = make.deck[19].Item3;
            string weightTwentiethCard = make.deck[19].Item4.ToString();
            string altWeightTwentiethCard = make.deck[19].Item5.ToString();
            
            Console.WriteLine("Deck contains " + counter.ToString() + " cards.");
            Console.WriteLine("Second card in deck is " + cardTypeSecondCard + " of " + suitSecondCard);
            Console.WriteLine("Weight of second card in deck is " + weightSecondCard);
            Console.WriteLine("Alternate weight of second card in deck is " + altWeightSecondCard);
            Console.WriteLine("Card type of 20th card in deck is " + cardTypeTwentiethCard + " of " + suitTwentiethCard);
            Console.WriteLine("Weight of 20th card in deck is " + weightTwentiethCard);
            Console.WriteLine("Alternate weight of 20th card in deck is " + altWeightTwentiethCard);


            make.deck.Sort();
            //var sorter = from element in make.deck
            //              orderby element.Item2, element.Item1
            //              select element;

            cardTypeSecondCard = make.deck[1].Item2;
            suitSecondCard = make.deck[1].Item3;
            Console.WriteLine("After sort, second card in deck is " + cardTypeSecondCard + " of " + suitSecondCard);
            

            make.deck.Remove(make.deck[0]);
            counter = make.deck.Count();

            Console.WriteLine("After dealing one card, deck contains " + counter.ToString() + " cards.");

            Console.ReadLine();
            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}