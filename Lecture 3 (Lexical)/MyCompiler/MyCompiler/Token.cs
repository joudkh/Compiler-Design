using System;
using System.Collections.Generic;
using System.Text;

namespace MyCompiler
{
    public enum Language { datatype, identifier, symbol, op, keyword, digit, error }

    class Token
    {
        public Language type;
        public string value;
        public int line;

        public Token()
        {
            value = "";
            line = -1;
        }

        public Token(Language t,string v,int l)
        {
            type = t;
            value = v;
            line = l;
        }

        public void printToken()
        {
            Console.WriteLine("Type: " + type + " \t| Value: " + value + " \t| Line: " + line);
        }
    }
}
