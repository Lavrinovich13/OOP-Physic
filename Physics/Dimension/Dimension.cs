using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physics
{
    class Dimension
    {
        private string name;

        private Dictionary<BaseSi, int> expansionInBaseSi;

        private bool isSi;

        public string Name { get { return name; } }
        public Dictionary<BaseSi, int> ExpansionInBaseSi { get { return expansionInBaseSi; } }
        public bool IsSi { get { return isSi; } }

        public Dimension(string name, Dictionary<BaseSi, int> expansionInSi)
        {
            this.name = name;
            this.expansionInBaseSi = expansionInSi;
            this.isSi = true;
        }

        public Dimension(string name)
        {
            this.name = name;
            this.isSi = false;
        }
    }
}
