using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physics
{
    class Program
    {
        static void Main(string[] args)
        {
            Variable v1 = new Variable(3, new Dictionary<Dimension, int>() 
            {
                {Si.m, 2},
                {Si.s, -4},
                {Si.kg, 2}
            });

            Variable v2 = new Variable(3, new Dictionary<Dimension, int>() 
            {
                {Si.N, -1}
            });

            var v3 = v1 / v2;

            var m = new Variable(5, Si.kg);
            var a = new Variable(2, new Dictionary<Dimension, int> 
            {
                 {Si.m, 1},
                 {Si.s, -2}
            });

            var F = m * a;

            var S = new Variable(10, Si.m);

            var A = F * S;
            
            var unknown = A / (m * a);

            var t = new Variable(2, Si.s);

            var P = (m * a * S) / t;

            A = P * t;
            var v0 = new Variable(10, new Dictionary<Dimension, int>
                {
                    {Si.m, 1},
                    {Si.s, -1}
                });
            var v = new Variable(30, new Dictionary<Dimension, int>
                {
                    {Si.m, 1},
                    {Si.s, -1}
                });

            F = ((v0 - v) / t) * m;

            v = new Variable(100, new Dictionary<Dimension, int> 
            {
                {NotSi.km, 1},
                {NotSi.h, -1}
            });

            t = new Variable(30, Si.s);

            a = (v - v0) / t;

            m = new Variable(5000, NotSi.g);

            S = new Variable(1, NotSi.km);

            P = ((m / 2) * S * a) / t;
        }
    }
}
