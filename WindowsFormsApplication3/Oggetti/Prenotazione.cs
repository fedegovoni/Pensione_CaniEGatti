using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication3
{

    class Prenotazione
    {
        public readonly int BOX_CANI = 24;
        public readonly int BOX_GATTI = 12;

        private int _id;
        private String _nome;
        private String _cognome;
        private List<int> _boxes;
        private DateTime _start;
        private DateTime _end;
             

        public Prenotazione(String nome, String cognome, List<int> boxes, DateTime start, DateTime end)
        {

           foreach (int box in boxes) {
                if (box > BOX_CANI) throw new IndexOutOfRangeException();   //valore di range dei box
            }

            _id = 0; //imposta il valore;
            _nome = nome;
            _cognome = cognome;
            _boxes = boxes;
            _start = start;
            _end = end;
        }

        public int Id { get { return _id; } }

        public String Nome { get { return _nome;  } set { _nome = value; } }

        public String Cognome { get { return _nome; } set { _nome = value; } }

        public List<int> Boxes { get { return _boxes; } set { _boxes = value; } }

        public DateTime StartTime { get { return _start;  } set { _start = value;  } }

        public DateTime EndTime { get { return _end; } set { _end = value; } }

        public TimeSpan GetPeriodLength()
        {
            return EndTime - StartTime;
        }
    }
}
