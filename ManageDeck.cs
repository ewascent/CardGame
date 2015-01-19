using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{

    //Create a helper class to simplify the creation of a list of tuples.
    //Each card will be represented as a tuple and the list will represent the deck
    public class TupleList<T1, T2, T3, T4> : List<Tuple<T1, T2, T3, T4>>
    {
        public void Add(T1 item1, T2 item2, T3 item3, T4 item4)
        {
            Add(new Tuple<T1, T2, T3, T4>(item1, item2,item3,item4));
        }
    }
    
    
    
    public class ManageDeck
    {
        List<string> suitType = new List<string>();
        List<string> cardType = new List<string>();
        TupleList<string, string, byte, byte?> deck = new TupleList<string,string,byte,byte?>();

        //byte is an economical numeric datatype that stores values up to 32,767
        //alternateWeight is usually null adn is deisgned for card games that allow one card to have two values like the ace in blackjack
        public string addCards(string cardVal, string suitVal, byte weight, byte? alternateWeight)
        {
            var format = new FormatException();

            try
            {
                suitType.Add("Club");
                suitType.Add("Diamond");
                suitType.Add("Heart");
                suitType.Add("Spade");

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
                        deck.Add(cardVal, suitVal, weight, alternateWeight);
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

        public void checkDeck() 
        { 
        }

        public void shuffleDeck(int CardCount)
        {

            
            Console.WriteLine("I am dead to the world. fix me");
        }


        private static void Main(string[] args)
        {
            //addCards = new addCards();

            //addCards("Ace", "Hearts", 11, 1);
            //addCards("King", "Hearts", 10, 0);

             Console.WriteLine("No args to fill the val, oh dispair.");
             Console.ReadLine();
            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

            
    }

}
