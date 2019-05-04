using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Pizzi_CaniEGatti.Gestione
{
    [Serializable]
    public class Periodo : ISerializable
    {
        private DateTime _start;
        private DateTime _end;
        private int _box;

        public Periodo(DateTime start, DateTime end, int box)
        {
            _start = start;
            _end = end;
            _box = box;
        }

        public DateTime StartTime { get { return _start; } set { _start = value; } }   

        public DateTime EndTime { get { return _end; } set { _end = value; } }

        public int Box { get { return _box; } set { _box = value; } }

        public TimeSpan Length { get { return _end - _start; } }

        override
        public String ToString()
        {
            return "Dal giorno " + _start.ToString("dd/MM/yyyy - HH:mm") + " a " + _end.ToString("dd/MM/yyyy - HH:mm") + " box " + _box +"\n";
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("start", _start);
            info.AddValue("end", _end);
            info.AddValue("box", _box);
        }

        protected Periodo(SerializationInfo info, StreamingContext context)
        {
            _start = (DateTime)info.GetValue("start", typeof(DateTime));
            _end = (DateTime)info.GetValue("end", typeof(DateTime));
            _box = (int)info.GetValue("box", typeof(int));            
        }
    }

}
