using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Domain
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DCValidateCondition : Attribute
    {
        public Boolean IsRequired { get; set; }
        public int StringMinSize { get; set; }
        public int StringMaxSize { get; set; }
        public int IntMaxValue { get; set; }
        public int IntMinValue { get; set; }
    }
}
