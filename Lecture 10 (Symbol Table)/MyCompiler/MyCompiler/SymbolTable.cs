using System;
using System.Collections.Generic;
using System.Text;

namespace MyCompiler
{
    class SymbolTable
    {
        public List<Symbol> symbolList = new List<Symbol>();

        public void addSymbol(Symbol s)
        {
            symbolList.Add(s);
        }

        public void print()
        {
            for(int i=0;i<symbolList.Count;i++)
            {
                symbolList[i].print();
            }
        }

        public void removeScope(int scope)
        {
            for (int i = symbolList.Count; i >=0; i--)
            {
                if (symbolList[i].scope == scope)
                {
                    symbolList.Remove(symbolList[i]);
                }
            }
        }

        public bool search(string vName)
        {
            for (int i = symbolList.Count; i >= 0; i--)
            {
                if (symbolList[i].name == vName)
                {
                    return true;
                }
            }
            return false;
        }

        public int searchAndGetType(string vName)
        {
            for (int i = symbolList.Count; i >= 0; i--)
            {
                if (symbolList[i].name == vName)
                {
                    return symbolList[i].type;
                }
            }
            return -1;
        }

        public bool isEmpty()
        {
            if (symbolList.Count == 0)
                return true;
            else
                return false;
        }


    }
}
