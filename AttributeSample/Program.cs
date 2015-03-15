using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributeSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Print("i am obsolete");

            Console.ReadLine();
        }

        /*
         * Compile.Time Attribute: Compiler emits 1 warning that this method is obsolete.
         * */
        [Obsolete]
        public static void Print(string text)
        {
            Console.WriteLine(text);
        }
    }
}
