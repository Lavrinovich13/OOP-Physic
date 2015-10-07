using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physics
{
    class Si
    {
        public static Dimension ND
            = new Dimension("notDetermined", null);
        public static Dimension m 
            = new Dimension("metre", new Dictionary<BaseSi, int> { {BaseSi.m, 1} });
        public static Dimension s
            = new Dimension("second", new Dictionary<BaseSi, int> { { BaseSi.s, 1 } });
        public static Dimension kg
            = new Dimension("kilogram", new Dictionary<BaseSi, int> { { BaseSi.kg, 1 } });
        public static Dimension A
            = new Dimension("ampere", new Dictionary<BaseSi, int> { { BaseSi.A, 1 } });
        public static Dimension K 
            = new Dimension("kelvin", new Dictionary<BaseSi, int> { { BaseSi.K, 1 } });
        public static Dimension mol
            = new Dimension("mole", new Dictionary<BaseSi, int> { { BaseSi.mol, 1 } });
        public static Dimension cd 
            = new Dimension("candela", new Dictionary<BaseSi, int> { { BaseSi.cd, 1 } });
        public static Dimension N
            = new Dimension("newton", new Dictionary<BaseSi, int>
            {
                {BaseSi.m, 1},
                {BaseSi.kg, 1},
                {BaseSi.s, -2}
            });
        public static Dimension J
            = new Dimension("joule", new Dictionary<BaseSi, int>
            {
                {BaseSi.m, 2},
                {BaseSi.kg, 1},
                {BaseSi.s, -2}
            });
        public static Dimension W
            = new Dimension("watt", new Dictionary<BaseSi, int>
            {
                {BaseSi.m, 2},
                {BaseSi.kg, 1},
                {BaseSi.s, -3}
            });
        
    }
}
