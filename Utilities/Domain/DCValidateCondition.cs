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
        public int StringSize { get; set; }
        public int IntMaxValue { get; set; }
        public int IntMinValue { get; set; }
    }
}
