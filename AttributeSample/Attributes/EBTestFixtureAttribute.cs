using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AttributeSample.Attributes
{
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = false)]
    public class EBTestAssemblyAttribute: System.Attribute
    {
        public EBTestAssemblyAttribute(String Description_in)
        {
            //
            // TODO: Add constructor logic here
            this.description = Description_in;
            //
        }
        protected String description;
        public String Description
        {
            get 
            {
                return this.description;
                 
            }            
        }    
    }

    [AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class EBTestFixtureAttribute : System.Attribute
    {
        protected string description;
        public string Description
        {
            get
            {
                return description;
            }
        }

        protected string version;
        public string Version
        {
            get
            {
                return this.version;
            }
            set
            {
                this.version = value;
            }
        }

        public EBTestFixtureAttribute(string description)
        {
            this.description = description;
            this.version = "V 1.0";
        }
    }
}
