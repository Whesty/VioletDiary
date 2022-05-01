using Microsoft.Analytics.Interfaces;
using Microsoft.Analytics.Interfaces.Streaming;
using Microsoft.Analytics.Types.Sql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace USQLCSharpProject1
{
    public class MyService : IMyService
    {
        public string Method1(string x)
        {
            string s = $"1 You entered: {x} = = = 1";
            return s;
        }

        public string Method2(string x)
        {
            string s = $"2 you entered: {x} = = = 2";
            return s;
        }
    }
}