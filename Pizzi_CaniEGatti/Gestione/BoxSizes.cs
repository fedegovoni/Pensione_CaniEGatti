using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pensione_CaniEGatti.Gestione
{
    class BoxSizes
    {
        private int _cats = 12;
        private int _dogs = 24;

        public BoxSizes()
        {
        }

        public BoxSizes(int dogs, int cats)
        {
            _cats = cats;
            _dogs = dogs;
        }

        public int NumBoxCani {get { return _dogs; } set { _dogs = value; } }

        public int NumBoxGatti { get { return _cats; }set { _cats = value; } }
    }
}
