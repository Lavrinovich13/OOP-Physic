using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physics
{
    class Variable
    {
        private bool isComplexDimension = false;

        private double value;
        private Dimension dimension;
        private Dictionary<Dimension, int> complexDimension;

        public double Value { get { return value; } }
        public Dimension Dimension { get { return dimension; } }
        public Dictionary<Dimension, int> ComplexDimension { get { return complexDimension; } }
        public bool IsComplexDimension { get { return isComplexDimension; } }

        public Variable(double value, Dimension dimension) 
        {
            this.value = value;
            this.dimension = dimension;
        }

        public Variable(double value, Dictionary<Dimension, int> compositeDimension)
        {
            this.value = value;
            this.complexDimension = compositeDimension;
            this.isComplexDimension = true;
        }

        private Variable
            (double value,
             Dictionary<Dimension, int> compositeDimension,
             Dimension dimension, 
             bool isCompositeDimension)
        {
            this.value = value;
            this.complexDimension = compositeDimension;
            this.dimension = dimension;
            this.isComplexDimension = isCompositeDimension;
        }

        public static Variable operator *(Variable v, double d)
        {
            var value = v.Value * d;

            return new Variable(value, v.complexDimension, v.dimension, v.isComplexDimension);
        }

        public static Variable operator *( double d, Variable v)
        {
            return v * d;
        }

        public static Variable operator /(Variable v, double d)
        {
            var value = v.Value / d;

            return new Variable(value, v.complexDimension, v.dimension, v.isComplexDimension);
        }

        public static Variable operator /(double d, Variable v)
        {
            var value = v.Value / d;

            return new Variable(value, v.complexDimension, v.dimension, v.isComplexDimension);
        }

        public static Variable operator +(Variable v1, Variable v2)
        {
            return Calculator.Plus(v1, v2);
        }

        public static Variable operator -(Variable v1, Variable v2)
        {
            return Calculator.Minus(v1, v2);
        }

        public static Variable operator *(Variable v1, Variable v2)
        {
            return Calculator.Multiplication(v1, v2);
        }

        public static Variable operator /(Variable v1, Variable v2)
        {
            return Calculator.Division(v1, v2);
        }
    }
}
