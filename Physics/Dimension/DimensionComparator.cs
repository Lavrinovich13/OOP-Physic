using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physics
{
    class DimensionComparator
    {
        public static bool IsEquals (Dictionary<BaseSi, int> d1, Dictionary<BaseSi, int> d2)
        {
            if(d1.Count == d2.Count)
            {
                foreach(var item in d1)
                {
                    if(!d2.Contains(item))
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }

            return true;
        }
    }
}
