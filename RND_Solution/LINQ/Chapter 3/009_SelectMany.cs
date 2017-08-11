using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LINQ.SampleData;
using LINQ.Common;

namespace LINQ.Chapter_3
{
    class _009_SelectMany
    {
        public static void Main1(string[] agru)
        {
            string[] sentence = new string[] { "The quick brown","fox jumps over", "the lazy dog."};

            "Option 1: using Select Clause".Output();
            "###################### Select Clause Extension Method ######################".Output();
            IEnumerable<string[]> words1 = sentence.Select(w => w.Split(' '));
            foreach (var arr in words1)
            {
                foreach (string word in arr)
                {
                    word.Output();
                }
            }

            "".Output();
            "###################### Select Clause Query Method ######################".Output();
            IEnumerable<string[]> words2 = from w in sentence
                                           select w.Split(' ');
            foreach (var arr in words2)
            {
                foreach (string word in arr)
                {
                    word.Output();
                }
            }


            "".Output();
            "Option 2: using Select Many Clause".Output();
            "###################### Select Many Clause Extension Method ######################".Output();
            IEnumerable<string> words3 = sentence.SelectMany(w=> w.Split(' '));
            foreach (var arr in words3)
            {
                arr.Output();
            }

            "".Output();
            "###################### Select Many Clause Query Method ######################".Output();
            IEnumerable<string> words4 = from arr in sentence
                                         from word in arr.Split(' ')
                                         select word;
            foreach (var arr in words4)
            {
                arr.Output();
            }

            Console.ReadLine();
        }
    }
}
