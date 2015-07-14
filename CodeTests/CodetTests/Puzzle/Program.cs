using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puzzle
{
    class Program
    {
        static Dictionary<char, int> indexes = new Dictionary<char, int>();
        static void Main(string[] args)
        {
            Console.WriteLine(x1.d.egg.ToString());

        }
        static void FindSimilar()
        {

            string s = "sometextcanbedevidedtosomeextend";
            string match = "some";
            for (int i = 0; i < s.Length; i++)
            {
                for (int j = 0; j < match.Length; j++)
                {
                    if (match[j] == s[i])
                    {
                        if (!indexes.Keys.Contains(s[i]))
                            indexes.Add(s[i], i);
                        else
                            indexes[s[i]]++;
                    }
                }
            }
        }
        static void ArrangeTo100()
        {
            int[] x = new int[] { 20, 4, 9, 11, 5, 2, 7 };
            int result = x.Sum();
            var y = x.Max();
            var z = x.Min();
            var diff = 100 - result;

        }


    }
    public class x1
    {
        public x1()
        {
            Console.WriteLine("test");
        }
        public enum d
        {
            egg, ppp
        }
    }
}
