using System;
using System.Collections.Generic;
using System.Text;

namespace MyCompiler
{
    class Parser
    {
        Lexical lex = new Lexical();
        int index;

        public Parser(string inputStr)
        {
            index = 0;
            lex.findTokens(inputStr);
            lex.printTokenList();

            bool result = MainProgram();
            if(result)
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");

            }
        }

        bool MainProgram()
        {
            if(lex.tokenList[index].value=="void")
            {
                index++;
                if(lex.tokenList[index].value=="main")
                {
                    index++;
                    if (lex.tokenList[index].value == "(")
                    {
                        index++;
                        if (lex.tokenList[index].value == ")")
                        {
                            index++;
                            if (lex.tokenList[index].value == "{")
                            {
                                index++;
                                if(InputStmt())
                                {

                                    if (lex.tokenList[index].value == "}")
                                    {
                                        index++;
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }

        bool InputStmt()
        {
            if (lex.tokenList[index].value == "cin")
            {
                index++;
                if (lex.tokenList[index].value == ">")
                {
                    index++;
                    if (lex.tokenList[index].value == ">")
                    {
                        index++;
                        if(ReadVar())
                        {
                            if (lex.tokenList[index].value == ";")
                            {
                                index++;
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        bool ReadVar()
        {
            if(lex.tokenList[index].type==Language.identifier)
            {
                index++;
                if(lex.tokenList[index].value==">")
                {
                    index++;
                    if (lex.tokenList[index].value == ">")
                    {
                        index++;
                        if (ReadVar())
                        {
                            return true;
                        }
                    }
                }
                else
                {
                    return true;
                }
            }
            return false;
        }

    }
}
