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
            Print("Method Print() is obsolete");

            /*
             * Print custom attribute of current assembly
             * Look for EBTestAssembly in AssemblyInfo.cs (Properties Folder)
             * */
            PrintCustomAssemblyAttribute();
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();

            PrintAllAssemblyAttributes();
            Console.WriteLine("Press any key to continue..."); 
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

        public static void PrintAllAssemblyAttributes()
        {
            Assembly assemblyToInspect = typeof(Program).Assembly;

            Console.WriteLine(Environment.NewLine + 
                              "Custom Attributes of assembly {0}:",                               
                              assemblyToInspect.FullName);

            foreach (var assemblyAttribute in assemblyToInspect.GetCustomAttributes())
            {
                string assemblydesc = assemblyAttribute.ToString();

                AssemblyCopyrightAttribute copyright = assemblyAttribute as AssemblyCopyrightAttribute;

                if (copyright != null)
                {
                    assemblydesc = copyright.Copyright;
                }

                Console.WriteLine(Environment.NewLine +
                                  "Attributename: {1}" +
                                  Environment.NewLine +
                                  "AttributeDesc: {2}",
                                  assemblyToInspect.FullName,
                                  assemblyAttribute.GetType().Name,
                                  assemblydesc);
            }
        }
    }
}
