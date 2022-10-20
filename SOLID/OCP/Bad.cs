using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace solid_OCP_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // OCP Bad ex
        }
        public class Report1
        {
            public bool GenerateReport()
            {
                //Code to generate report in HTML Format
                return true;
            }
        }

        public class Report2
        {
            public bool GenerateReport()
            {
                //Code to generate report in HTML Format
                //Code to generate report in JSON Format
                return true;
            }
        }
    }
}
