using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.ILS.Common;

namespace tests
{
    class Program
    {
        static void Main(string[] args)
        {
            string smth = "once upон a///%!#@\\ time ин the west.html".ToValidLatinFileName();
            smth = smth.GetFileExtension();
        }
    }
}
