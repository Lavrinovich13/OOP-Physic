using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physics
{
    class Convertors
    {
        public static Variable GtoKG(Variable v)
        {
            double coefficient = Math.Pow(1000, -1);
            Dimension si = Si.kg;
            Dimension notSi = NotSi.g;

            return Convert(v, coefficient, si, notSi);
        }

        public static Variable KMtoM(Variable v)
        {
            double coefficient = 1000;
            Dimension si = Si.m;
            Dimension notSi = NotSi.km;

            return Convert(v, coefficient, si, notSi);
        }

        public static Variable HtoS(Variable v)
        {
            double coefficient = 3600;
            Dimension si = Si.s;
            Dimension notSi = NotSi.h;

            return Convert(v, coefficient, si, notSi);
        }

        public static Variable MINtoS(Variable v)
        {
            double coefficient = 60;
            Dimension si = Si.s;
            Dimension notSi = NotSi.min;

            return Convert(v, coefficient, si, notSi);
        }



        private static Variable Convert(Variable v, double coefficient, Dimension si, Dimension notSi)
        {
            if (!v.IsComplexDimension)
            {
                return new Variable(v.Value * coefficient, si);
            }
            else
            {
                var dimension = CloneDimension.Clone(v.ComplexDimension);
                var power = dimension[notSi];

                dimension.Remove(notSi);
                dimension.Add(si, power);

                if (power > 0)
                {
                    return new Variable(v.Value * Math.Pow(coefficient, power), dimension);
                }
                else
                {
                    return new Variable(v.Value / Math.Pow(coefficient, power * (-1)) , dimension);
                }
            }
        }
    }
}
