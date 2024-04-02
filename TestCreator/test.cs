using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCreator
{
    internal class test
    {
        public string name { get; set; }
        public string disc { get; set; }
        public string aFirst { get; set; }
        public string aSecond { get; set; }
        public string aThird { get; set; }
        public truSIU trueAnswer { get; set; }
    }

    public enum truSIU
        {
        First,
        Second,
        Third
    }
}
