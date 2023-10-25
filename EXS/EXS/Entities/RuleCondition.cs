using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXS.Entities
{
    public class RuleCondition
    {
        public string Variable { get; set; }
        public string Operator { get; set; }
        public string Value { get; set; }
        public string CondOp { get; set; }
    }
}
