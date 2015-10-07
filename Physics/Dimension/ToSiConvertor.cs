using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physics
{
    class ToSiConvertor
    {
        private  Dictionary<Dimension, Func<Variable, Variable>> convertors =
            new Dictionary<Dimension, Func<Variable, Variable>> 
            {
                {NotSi.g, Convertors.GtoKG},
                {NotSi.km, Convertors.KMtoM},
                {NotSi.min, Convertors.MINtoS},
                {NotSi.h, Convertors.HtoS}
            };

        public Variable Convert(Variable v)
        {
            if(!v.IsComplexDimension && !v.Dimension.IsSi)
            {
                return convertors[v.Dimension](v);
            }
            else if (v.IsComplexDimension)
            {
                var newV = new Variable
                    (v.Value,
                     CloneDimension.Clone(v.ComplexDimension));

                foreach(var item in v.ComplexDimension)
                {
                    if(!item.Key.IsSi)
                    {
                        newV = convertors[item.Key](newV);
                    }
                }

                return newV;
            }
            return v;
        }
    }
}
