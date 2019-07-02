using System;

namespace MyCompiler
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Lexical lex = new Lexical();
            lex.findTokens("int x1,x2,x3;");
            lex.printTokenList();
        }
    }
}
