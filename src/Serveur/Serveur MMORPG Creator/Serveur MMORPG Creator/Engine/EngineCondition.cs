using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MmorpgEngine.Engine
{
    public class EngineCondition
    {

        private List<Condition> _Conditions = new List<Condition>();


        public List<Condition> Condition
        {
            get
            {
                return _Conditions;
            }

            set
            {
                _Conditions = value;
            }
        }
    }
}
