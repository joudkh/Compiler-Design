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
        List<KeyValuePair<Language, int>> languageToValue=new List<KeyValuePair<Language, int>>();
        SymbolTable ST;
        int Scope = -1;

        public Parser(string inputStr)
        {

            languageToValue.Add(new KeyValuePair<Language, int>(Language.Int, 0));
            languageToValue.Add(new KeyValuePair<Language, int>(Language.Double, 1));
            languageToValue.Add(new KeyValuePair<Language, int>(Language.Char, 2));
            languageToValue.Add(new KeyValuePair<Language, int>(Language.String, 3));
            languageToValue.Add(new KeyValuePair<Language, int>(Language.Bool, 4));

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
                                Scope++;
                                index++;
                                if(InputStmt())
                                {

                                    if (lex.tokenList[index].value == "}")
                                    {
                                        Scope--;
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
                if (!ST.search(lex.tokenList[index].value))
                {
                    return false;
                }
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
                    string varName = Assign(getType);
                    if (varName != "")
                    {
                        if (lex.tokenList[index].value == ";")
                        {
                            ST.addSymbol(new Symbol(varName, getType, Scope));
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

        string Assign(int myType)
        {
            if (lex.tokenList[index].type == Language.identifier)
            {
                string variableName = lex.tokenList[index].value;
                index++;
                if (lex.tokenList[index].value == "=")
                {
                    index++;
                    if (getLanguageValue(lex.tokenList[index].type) == myType)
                    {
                        index++;
                        return variableName;
                    }
                }
                else
                {
                    return variableName;
                }
            }
            return "";
        }

        int getLanguageValue(Language ln)
        {
            for(int i=0;i<languageToValue.Count;i++)
            {
                if(languageToValue[i].Key==ln)
                {
                    return languageToValue[i].Value;
                }
            }
            return -1;
        }
    }
}
