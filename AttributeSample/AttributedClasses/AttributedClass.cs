using AttributeSample.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributeSample.AttributedClasses
{
    [EBTestFixture("Attributedclass Testcases", Version = "V 2.0")]
    //[EBTestFixture] // uncomment to get 'duplicate attribute' error. AllowMultiple=false in Attribute.
    class AttributedClass
    {
        [EBTestMethod]
        public void ATestMethod()
        {
            Console.WriteLine("Testmethod: ATestMethod invoked.");
        }
    }
}
