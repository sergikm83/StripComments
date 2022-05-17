using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace StripComments
{
    class Program
    {
        // https://www.codewars.com/kata/51c8e37cee245da6b40000bd/train/csharp
        static void Main(string[] args)
        {
            string text = "apples, pears # and bananas\ngrapes\nbananas !apples";
            string[] commentSymbols = new string[] { "#", "!" };
            Console.WriteLine(StripCommentsSolution.StripComments(text,commentSymbols));
        }
    }
    public class StripCommentsSolution
    {
        public static string StripComments(string text, string[] commentSymbols)
        {
            return "";
        }
    }
}
