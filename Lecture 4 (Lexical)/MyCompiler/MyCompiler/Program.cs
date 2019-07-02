using System;
using System.IO;
using System.Text.RegularExpressions;

namespace MyCompiler
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            StreamReader SR = new StreamReader("file.txt");
            string inputStr = SR.ReadToEnd();
            Console.WriteLine(inputStr);
            inputStr = Regex.Replace(inputStr, @" +", " ");
            // remove empty lines
            // inputStr = Regex.Replace(inputStr, @"\n+", "\n");
            Console.WriteLine("------------------------");
            Console.WriteLine(inputStr);
            Console.WriteLine("------------------------");
            Lexical lex = new Lexical();
            lex.findTokens(inputStr);
            lex.printTokenList();
        }
    }
}
