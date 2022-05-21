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
                Console.WriteLine("default text: {0}\nresult text:  {1}\n",
                    word,
                    StripCommentsSolution.StripComments(word, new string[] { "#", "!" }));
            }
        }
    }

    public class StripCommentsSolution
    {
        public static string StripComments(string text, string[] commentSymbols)
        {
            string pattern = "";
            string exceptionsSymbols = @".+|\/$#^*()";
            for (int symbol=0;symbol<commentSymbols.Length;symbol++)
            {
                string validSymbol = exceptionsSymbols.IndexOf(commentSymbols[symbol]) != -1 ?
                    string.Format($"\\{commentSymbols[symbol]}") : commentSymbols[symbol];
                pattern += string.Format($"{validSymbol}.+|{validSymbol}");
                pattern += symbol != commentSymbols.Length - 1 ? "|" : "";
            }

            var textArray = text.Split("\n");
            string result = string.Empty;
            for (int idx=0;idx<textArray.Length;idx++)
            {
                result += Regex.Replace(textArray[idx], pattern, string.Empty).Trim();
                result += idx != textArray.Length - 1 ? "\n" : string.Empty;
            }
            return result;
        }
    }
}
