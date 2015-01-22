using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace CardGame
{
    ///<summary>
    /// Helper class to create a list that can store and sort a set of 5-tuples. 
    /// This supports storing a set of records where each item in the reecord consists of heterogenous datatpes.
    /// This allows an in memory table like structure with the ability to sort on a defined key. 
    /// Typing and nullability is defined by the envoking class.
    ///</summary>
    public class TupleList<T1, T2, T3, T4, T5> : List<Tuple<T1, T2, T3, T4, T5>>
    {
        public void Add(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5)
        {
            Add(new Tuple<T1, T2, T3, T4, T5>(item1, item2, item3, item4, item5));
        }
    }


    public static class ThreadSafeRandom
    {
        [ThreadStatic]
        private static Random Local;

        public static Random ThisThreadsRandom
        {
            get { return Local ?? (Local = new Random(unchecked(Environment.TickCount * 31 + Thread.CurrentThread.ManagedThreadId))); }
        }
    }
      static class MyExtensions
      {
        public static void Shuffle<T>(this IList<T> list)
        {
          int n = list.Count;
          while (n > 1)
          {
            n--;
            int k = ThreadSafeRandom.ThisThreadsRandom.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
          }
        }
      }
 }
