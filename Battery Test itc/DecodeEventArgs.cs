using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace DecodeAssemblyITC
{
    public class DecodeEventArgs
    {
        public int dummy = 0;
        public string sData = "";
        public DecodeEventArgs(string s)
        {
            sData = s;
        }
    }

}