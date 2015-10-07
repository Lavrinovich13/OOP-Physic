using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physics
{
    class CloneDimension
    {
        public static Dictionary<Dimension, int> Clone(Dictionary<Dimension, int> dimension)
        {
            var newDimension = new Dictionary<Dimension, int>();

            foreach (var item in dimension)
            {
                newDimension.Add(item.Key, item.Value);
            }

            return newDimension;
        }

        public static Dictionary<BaseSi, int> Clone(Dictionary<BaseSi, int> dimension)
        {
            var newDimension = new Dictionary<BaseSi, int>();

            foreach (var item in dimension)
            {
                newDimension.Add(item.Key, item.Value);
            }

            return newDimension;
        }
    }
}
