using System;
using System.Collections.Generic;
using System.Text;

namespace MyCompiler
{
    class Parser
    {
        Error EL;
        Lexical lex;
        int index;
        List<string> values = new List<string>();
        SymbolTable ST;

        public Parser(string inputStr)
        {
            values.Add("int");
            values.Add("double");
            values.Add("char");
            values.Add("string");
            values.Add("bool");
            EL = new Error();
            lex = new Lexical();
            ST = new SymbolTable();
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
                                    else
                                    {
                                        EL.addError("Error: I am expecting to find } but I found " + lex.tokenList[index].value + " at line " + lex.tokenList[index].line);
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

        bool DecStmt()
        {
            int getType = Type();
            if (getType!=-1)
            {
                index++;
                if (lex.tokenList[index].type == Language.identifier)
                {
                    if (Assign(getType))
                    {
                        if (lex.tokenList[index].value == ";")
                        {
                            //ST.addSymbol(new Symbol())
                            index++;
                            return true;
                        }
                    }
                }
                
            }
            return false;
        }

        int Type()
        {
            if (lex.tokenList[index].value == "int")
            {
                return 0;
            }
            else if (lex.tokenList[index].value == "double")
            {
                return 1;
            }
            else if(lex.tokenList[index].value == "char")
            {
                return 2;
            }
            else if(lex.tokenList[index].value == "string")
            {
                return 3;
            }
            else if(lex.tokenList[index].value == "bool")
            {
                return 4;
            }
            else
            {
                return -1;
            }
        }

        bool Assign(int myType)
        {
            if (lex.tokenList[index].type == Language.identifier)
            {
                index++;
                if (lex.tokenList[index].value == "=")
                {
                    index++;
                    if (lex.tokenList[index].value==values[myType])
                    {
                        index++;
                        return true;
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
