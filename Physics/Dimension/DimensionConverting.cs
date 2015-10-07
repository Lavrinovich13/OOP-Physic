using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physics
{
    static class DimensionConvertor
    {
        private static List<Dimension> si = new List<Dimension> 
        {
            Si.A,
            Si.cd,
            Si.N,
            Si.K,
            Si.kg,
            Si.m,
            Si.mol,
            Si.s,
            Si.J,
            Si.W
        };

        public static Dictionary<BaseSi, int> Expan(Dictionary<Dimension, int> dimension)
        {
                return ExpanComplexDimension(dimension);
        }

        public static Dictionary<Dimension, int> Narrow(Dictionary<BaseSi, int> expanDimension)
        {
            Dictionary<Dimension, int> newDimension = new Dictionary<Dimension, int>();
            si.Sort((x, y) => y.ExpansionInBaseSi.Count.CompareTo(x.ExpansionInBaseSi.Count));
            double power;
            bool flag;
            bool first;

            foreach(var item in si)
            {
                power = 0;
                flag = true;
                first = true;
                foreach(var subitem in item.ExpansionInBaseSi)
                {
                    if (expanDimension.ContainsKey(subitem.Key) && first)
                    {
                        power = expanDimension[subitem.Key] / subitem.Value;
                        first = false;
                    }

                    if (!expanDimension.ContainsKey(subitem.Key) || 
                        (double)expanDimension[subitem.Key] / (double)subitem.Value != power)
                    {
                        flag = false;
                        break;
                    }
                }
                
                if(flag)
                {
                    double newPower = (power == 0)?1:power;
                    newDimension.Add(item,(int)newPower);

                    foreach (var subitem in item.ExpansionInBaseSi)
                    {
                        expanDimension.Remove(subitem.Key);
                    }
                }
                
            }
            return newDimension;
        }


        private static Dictionary<BaseSi, int> ExpanComplexDimension(Dictionary<Dimension, int> compositeDimension)
        {
            var siDimention = new Dictionary<BaseSi, int>();
            int power;

            foreach (var item in si)
            {
               if(compositeDimension.ContainsKey(item))
               {
                   power = compositeDimension[item];

                   foreach(var subitem in item.ExpansionInBaseSi)
                   {
                       siDimention.Add(subitem.Key, subitem.Value * power);
                   }
               }
            }

            return siDimention;
        }
    }
}
