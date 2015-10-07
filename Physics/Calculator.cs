using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physics
{
    static class Calculator
    {
        private static ToSiConvertor toSiConvertor = new ToSiConvertor();

        private static Dictionary<BaseSi, int> Expan(Variable v)
        {
           var expanInBaseSi = new Dictionary<BaseSi, int>();
            if(!v.IsComplexDimension)
            {
                return expanInBaseSi = v.Dimension.ExpansionInBaseSi;
            }
            else
            {
                return expanInBaseSi = DimensionConvertor.Expan(v.ComplexDimension);
            }
        }

        private static Variable ReturnVariable(Variable v1, Variable v2)
        {
            var newV1 = toSiConvertor.Convert(v1);
            var newV2 = toSiConvertor.Convert(v2);
            var siDimensionV1 = Expan(newV1);
            var siDimensionV2 = Expan(newV2);

            var newValue = newV1.Value + newV2.Value;

            if (DimensionComparator.IsEquals(siDimensionV1, siDimensionV2))
            {
                if (newV1.IsComplexDimension)
                {
                    return new Variable(newValue, DimensionConvertor.Narrow(siDimensionV1));
                }

                return new Variable(newValue, newV1.Dimension);
            }

            return null;
        }
        public static Variable Plus(Variable v1, Variable v2)
        {
            return ReturnVariable(v1, v2);
        }

        public static Variable Minus(Variable v1, Variable v2)
        {
            Variable newV2;
            if(v2.IsComplexDimension)
            {
               newV2 = new Variable(v2.Value * (-1), CloneDimension.Clone(v2.ComplexDimension));
            }
            else
            {
                newV2 = new Variable(v2.Value * (-1), v2.Dimension);
            }
            return ReturnVariable(v1, newV2);
        }


        public static Variable Multiplication(Variable v1, Variable v2)
        {
            var newV1 = toSiConvertor.Convert(v1);
            var newV2 = toSiConvertor.Convert(v2);
            var siDimensionV1 = Expan(newV1);
            var siDimensionV2 = Expan(newV2);

            var compositeDimension = CloneDimension.Clone(siDimensionV1);

            foreach(var item in siDimensionV2)
            {
                if (compositeDimension.ContainsKey(item.Key))
                {
                    if (compositeDimension[item.Key] + item.Value != 0)
                    {
                        compositeDimension[item.Key] += item.Value;
                    }
                    else
                    {
                        compositeDimension.Remove(item.Key);
                    }
                }
                else
                {
                    compositeDimension.Add(item.Key, item.Value);
                }
            }

            double newValue = newV1.Value * newV2.Value;

            if (compositeDimension.Count != 0)
            {
                return new Variable(newValue, DimensionConvertor.Narrow(compositeDimension));
            }
            else
            {
                return new Variable(newValue, Si.ND);
            }
        }


        public static Variable Division(Variable v1, Variable v2)
        {
            var newV2 = Inverse(v2);
            return Multiplication(v1, newV2);
        }

        private static Variable Inverse(Variable v)
        {
            var compositeDimension = new Dictionary<Dimension, int>();

            if(v.IsComplexDimension)
            {
                foreach(var item in v.ComplexDimension)
                {
                    compositeDimension.Add(item.Key, item.Value * (-1));
                }
            }
            else
            {
                compositeDimension.Add(v.Dimension, -1);
            }
            return new Variable(1 / v.Value, compositeDimension);
        }
    }
}
