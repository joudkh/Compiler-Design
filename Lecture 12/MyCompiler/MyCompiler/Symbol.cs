using System;
using System.Collections.Generic;
using System.Text;

namespace MyCompiler
{
    class Symbol
    {
        public string name;
        public int type;
        public int scope;

        public Symbol(string name, int type,int scope)
        {
            this.name = name;
            this.type = type;
            this.scope = scope;
        }

        public void print()
        {
            Console.WriteLine("Name: " + name + " Type: " + type + " Scope: " + scope);
        }
    }
}
