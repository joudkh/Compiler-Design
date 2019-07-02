using System;
using System.Collections.Generic;
using System.Text;

namespace MyCompiler
{
    public class Lexical
    {
        // list of keywords
        // list of datatype
        public List<Token> tokenList;
        int lineNumber = 1;

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
                    int tmpIndex = i;
                    while (Char.IsLetter(ch) || Char.IsDigit(ch))
                    {
                        tmp += ch;
                        tmpIndex++;
                        if (tmpIndex < str.Length)
                        {
                            ch = str[tmpIndex];
                        }
                        else
                        {
                            break;
                        }

                    }
                    //Console.WriteLine(tmp);
                    // if keyword or datatype or id
                    Token tmpToken = new Token(Language.identifier, tmp, lineNumber);
                    tokenList.Add(tmpToken);
                    i = tmpIndex - 1;
                }
                else if (Char.IsDigit(ch))
                {
                    // int
                    // double
                    string tmp = "";
                    int tmpIndex = i;
                    while (Char.IsDigit(ch))
                    {
                        tmp += ch;
                        tmpIndex++;
                        if (tmpIndex < str.Length)
                        {
                            ch = str[tmpIndex];
                        }
                        else
                        {
                            break;
                        }
                    }
                    Token tmpToken = new Token(Language.digit, tmp, lineNumber);
                    tokenList.Add(tmpToken);
                    i = tmpIndex - 1;

                }
                else if (ch == '=' || ch == ';' || ch == ',' || ch == ')' || ch == '(' || ch == '{' || ch == '}' || ch == '>' || ch == '<')
                {
                    string tmp = "";
                    tmp += ch;
                    Token tmpToken = new Token(Language.symbol, tmp, lineNumber);
                    tokenList.Add(tmpToken);
                }
                else if (ch == '\n')
                {
                    lineNumber++;
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
