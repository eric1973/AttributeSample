using AttributeSample.Attributes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace AttributeSample
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Build in attribute Obsolete
             * */
            Print("i am obsolete");

            /*
             * Print custom attribute of current assembly
             * Look for EBTestAssembly in AssemblyInfo.cs (Properties Folder)
             * */
            PrintCustomAssemblyAttribute();



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

        public static void PrintCustomAssemblyAttribute()
        {
            Assembly assemblyToInspect = typeof(Program).Assembly;

            foreach (var assemblyAttribute in assemblyToInspect.GetCustomAttributes())
            {
                EBTestAssemblyAttribute customAttribute = assemblyAttribute as EBTestAssemblyAttribute;

                if (customAttribute != null)
                {
                    Console.WriteLine("Description of assembly {0}:" + 
                                       Environment.NewLine + 
                                       "Attributename: {1}" +
                                       Environment.NewLine + 
                                       "AttributeDesc: {2}",
                                       assemblyToInspect.FullName,
                                       customAttribute.GetType().Name,
                                       customAttribute.Description);
                }
            }
        }
    }
}
