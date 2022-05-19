using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;

namespace StripComments
{
    // https://www.codewars.com/kata/51c8e37cee245da6b40000bd/train/csharp
    class Program
    {
        static void Main(string[] args)
        {
            string[] text = new string[]
            {
                "apples, pears # and bananas\ngrapes\nbananas !apples",
                "a #b\nc\nd $e f g",
                "a #b\n c\nd $e f g"
            };

            foreach (var word in text)
            {
                Console.WriteLine("default text: {0}\nresult text:  {1}\n",word,StripCommentsSolution.StripComments(word, new string[] { "#", "!","$" }));
            }
        }
    }

    public class StripCommentsSolution
    {
        public static string StripComments(string text, string[] commentSymbols)
        {
            string pattern = string.Empty;
            foreach (var symbol in commentSymbols)
                pattern += string.Format($"\\s\\{symbol}.+|");
            var textArray = text.Split("\n");
            string result = string.Empty;
            for (int i=0;i<textArray.Length;i++)
            {

                result += Regex.Replace(textArray[i], pattern, string.Empty).Trim();
                result += i != textArray.Length - 1 ? "\n" : string.Empty;
            }
            return result;
        }
    }
}
