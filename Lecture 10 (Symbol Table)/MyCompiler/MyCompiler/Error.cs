using System;
using System.Collections.Generic;
using System.Text;

namespace MyCompiler
{
    class Error
    {
        List<string> errorList;

        public Error()
        {
            errorList = new List<string>();
        }

        public void addError(string str)
        {
            errorList.Add(str);
        }

        public void printErrors()
        {
            for(int i=0;i<errorList.Count;i++)
            {
                Console.WriteLine(errorList[i]);
            }
        }
    }
}
