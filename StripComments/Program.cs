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
            string text= "apples, pears # and bananas\ngrapes\nbananas !apples";

            Console.WriteLine(StripCommentsSolution.StripComments(text,new string[] { "#", "!" }));
        }
    }

    public class StripCommentsSolution
    {
        public static string StripComments(string text, string[] commentSymbols)
        {
            string pattern = string.Empty;
            foreach (var symbol in commentSymbols)
                pattern += string.Format($"{symbol}.+|");
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
