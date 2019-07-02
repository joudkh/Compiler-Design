using System;
using System.Collections.Generic;
using System.Text;

namespace MyCompiler
{
    public class Lexical
    {
        // list of keywords
        // list of datatype
        List<Token> tokenList;

        public Lexical()
        {
            tokenList = new List<Token>();
        }

        public void findTokens(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                char ch = str[i];
                if (Char.IsLetter(ch))
                {
                    string tmp = "";
                    while (Char.IsLetter(ch) || Char.IsDigit(ch))
                    {
                        tmp += ch;
                        i++;
                        if (i < str.Length)
                        {
                            ch = str[i];
                        }
                        else
                        {
                            break;
                        }

                    }
                    //Console.WriteLine(tmp);
                    // if datatype or id
                    Token tmpToken = new Token(Language.datatype, tmp, 0);
                    tokenList.Add(tmpToken);

                }
                else if (Char.IsDigit(ch))
                {
                    // int
                    // double
                }
                else if (ch == '=')
                {

                }
            }
        }

        public void printTokenList()
        {
            for (int i = 0; i < tokenList.Count; i++)
            {
                tokenList[i].printToken();
            }
        }

    }
}
