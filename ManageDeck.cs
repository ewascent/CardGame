using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{

    public class ManageDeck
    {
             //byte is an economical numeric datatype that stores values up to 32,767
        //alternateWeight is usually null adn is deisgned for card games that allow one card to have two values like the ace in blackjack
        public Array makeDeck(out Array decker)
        {
            string[] deck = new string[] { "AC", "AD", "AH", "AS", "KC", "KD", "KH", "KS", "QC", "QD", "QH", "QS", "JC", "JD", "JH", "JS", "10C", "10D", "10H", "10S", "9C", "9D", "9H", "9S", "8C", "8D", "8H", "8S", "7C", "7D", "7H", "7S", "6C", "6D", "6H", "6S", "5C", "5D", "5H", "5S", "4C", "4D", "4H", "4S", "3C", "3D", "3H", "3S", "2C", "2D", "2H", "2S", };
            decker = deck;
            return decker;
        }


        public int shuffle(int CardCount)
        {
            //http://blog.codinghorror.com/shuffling/
            var cards = Enumerable.Range(0, 51);
            var shuffledcards = cards.OrderBy(a => Guid.NewGuid());

            return 1;
            
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
